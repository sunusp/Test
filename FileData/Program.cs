
using FileDataService.Service;
using System;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write($"Functionality to perform : {args[0]}\n----------------------------\n\n");

            // read parameters
            var requiredFunctionality = args[0];
            var filePath = args[1];

            // Invoke file service 
            IFileService fileService = new FileService(new FileDetailsClient());
            var metaData = fileService.GetFileMetaData(requiredFunctionality, filePath);

            Console.Write(
                $"File Data output (Version or Size) : " +
                $"{metaData ?? "File Metadata not found"}" +
                $"\n----------------------------\n\n");

            Console.ReadLine();
        }
    }
}
