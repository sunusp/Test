using ThirdPartyTools;

namespace FileDataService.Service
{
    /// <summary>
    ///  File details client 
    /// </summary>
    public class FileDetailsClient : FileDetails
    {
        public new virtual string Version(string filePath)
        {
            return base.Version(filePath);
        }

        public new virtual int Size(string filePath)
        {
            return base.Size(filePath);
        }
    }
}
