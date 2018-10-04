using FileDataService.Utility;

namespace FileDataService.Adapter
{
    public class DefaultFileDataAdapter : IFileDataTarget
    {
        public string[] GetFileSizeInput()
            => Constants.FileSizes;        

        public string[] GetFileVersionInput()
            => Constants.FileVersions;        
    }
}
