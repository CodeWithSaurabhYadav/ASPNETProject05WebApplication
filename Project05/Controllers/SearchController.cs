using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Project05.Data;
using Project05.Models;

namespace Project05.Controllers
{

    public class DriveServiceHelper
    {
        private readonly DriveService _service;

        public DriveServiceHelper(DriveService service)
        {
            _service = service;
        }
        public static DriveService Authenticate()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(@"./bin/Debug/net7.0/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });

            return service;
        }
        public string FolderID(string folderName)
        {
            var folders = _service.Files.List();
            folders.Q = "mimeType='application/vnd.google-apps.folder' and trashed=false";
            folders.Fields = "nextPageToken, files(id, name)";
            var result = folders.Execute();
            var folder = result.Files.FirstOrDefault(x => x.Name == folderName);
            return folder.Id;
        }

        public IList<Google.Apis.Drive.v3.Data.File> GetEmployeeFiles(string folderId, string employeeID)
        {
            var files = _service.Files.List();
            files.Q = $"'{folderId}' in parents and trashed=false";
            files.Fields = "nextPageToken, files(id, name)";
            var result = files.Execute();
            var fileList = result.Files;

            foreach (var file in fileList)
            {
                if (employeeID == file.Name)
                {
                    var filelist2 = GetFiles(file.Id);
                    return filelist2;
                }
            }
            return fileList;
        }
        public IList<Google.Apis.Drive.v3.Data.File> GetFiles(string folderId)
        {
            var files = _service.Files.List();
            files.Q = $"'{folderId}' in parents and trashed=false";
            files.Fields = "nextPageToken, files(id, name)";
            var result = files.Execute();
            var fileList = result.Files;

            return fileList;
        }

    }


    public class SearchController : Controller
    {
        private EmployeeContext _employeeContext;

        public SearchController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        [HttpPost]
        public IActionResult Index()
        {
            string employeeId = Request.Form["search"];
            ViewBag.Message = employeeId;

            IEnumerable<EmployeeModel> Employees = _employeeContext.Employees;

            var service = DriveServiceHelper.Authenticate();
            var helper = new DriveServiceHelper(service);
            string folderId = helper.FolderID("Employee");
            
            string newEmployeeID;
            newEmployeeID = employeeId.ToString();

            var fileList = helper.GetEmployeeFiles(folderId, newEmployeeID);
            List<string> fileTypes = new List<string>();
            foreach (var file in fileList)
            {
                string fileType = Path.GetExtension(file.Name);
                fileTypes.Add(fileType);
            }
            string[] array = fileTypes.ToArray();
            ViewBag.array = array;
            ViewBag.Files = fileList;

            return View(Employees);
        }
    }
}
