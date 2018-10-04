
namespace FileDataService.Adapter
{
    interface IFileDataTarget
    {
        string[] GetFileVersionInput();

        string[] GetFileSizeInput();
    }
}
