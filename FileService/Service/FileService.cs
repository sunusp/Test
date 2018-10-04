using FileDataService.Adapter;
using System.Linq;

namespace FileDataService.Service
{
    public class FileService : IFileService
    {
        private readonly IFileDataTarget fileDataTarget;
        private readonly FileDetailsClient _fileDetailsClient;

        public FileService(FileDetailsClient fileDetailsClient)
        {
            fileDataTarget = new DefaultFileDataAdapter();
            _fileDetailsClient = fileDetailsClient;
        }

        public string GetFileMetaData(string requiredFunctionality, string filePath)
        {
            string fileMetaData = null;

            if (!string.IsNullOrEmpty(requiredFunctionality))
            {
                // Get global functionality list 
                string[] fileSizes = GetFileSizeInput();
                string[] fileVersions = GetFileVersionInput();

                // check file version or size
                if (fileVersions.Any(requiredFunctionality.Equals))
                {
                    fileMetaData = _fileDetailsClient.Version(filePath);
                }
                else if (fileSizes.Any(requiredFunctionality.Equals))
                {
                    fileMetaData = _fileDetailsClient.Size(filePath).ToString();
                }
            }

            return fileMetaData;
        }

        private string[] GetFileSizeInput()
            => fileDataTarget.GetFileSizeInput();

        private string[] GetFileVersionInput()
            => fileDataTarget.GetFileVersionInput();
    }
}
