using FileDataService.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FileDataService.UnitTest
{
    [TestClass]
    public class FileMetaDataInputTest
    {
        private readonly Mock<FileDetailsClient> fileDetailsMock;
        private IFileService fileService;

        public FileMetaDataInputTest()
        {
            fileDetailsMock = new Mock<FileDetailsClient>();
        }

        [DataTestMethod]
        [DataRow("c:/test.txt", "-v", "1.1.1")]
        [DataRow("d:/test.txt", "--v", "1.1.1")]
        [DataRow("e:/test.txt", "/v", "1.1.1")]
        [DataRow("f:/test.txt", "--version", "1.1.1")]
        [DataRow(null, "-v", null)]
        [DataRow(null, "--v", null)]
        [DataRow(null, "/v", null)]
        [DataRow(null, "--version", null)]
        [DataRow("c:/test.txt", "-VERSION", null)]
        [DataRow(null, "-VERSION", null)]
        [DataRow("c:/test.txt", "-VERSION--V", null)]
        [DataRow(null, "-VERSION--V", null)]
        [DataRow("d:/test.txt", "-newver", null)]
        [DataRow("e:/test.txt", "--ver", null)]
        [DataRow(null, "--ver", null)]
        [DataRow("f:/test.txt", "--v/v", null)]
        [DataRow("f:/test.txt", null, null)]
        [DataRow(null, "--v/v", null)]
        [DataRow(null, null, null)]
        public void GetFileVersion_Test(string filePath, string fileVersionInput, string expectedResult)
        {
            // Arrange           
            string mockFileVersion = "1.1.1";
            fileDetailsMock
                .Setup(fileData => fileData.Version(filePath))
                .Returns(mockFileVersion);

            // Act
            fileService = new FileService(fileDetailsMock.Object);
            string actualResult = fileService.GetFileMetaData(fileVersionInput, filePath);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [DataTestMethod]
        [DataRow("c:/test.txt", "-s", "1024")]
        [DataRow("d:/test.txt", "--s", "1024")]
        [DataRow("e:/test.txt", "/s", "1024")]
        [DataRow("f:/test.txt", "--size", "1024")]
        [DataRow(null, "-s", null)]
        [DataRow(null, "--s", null)]
        [DataRow(null, "/s", null)]
        [DataRow(null, "--size", null)]
        [DataRow("c:/test.txt", "-filesize", null)]
        [DataRow("d:/test.txt", "-SIZE", null)]
        [DataRow(null, "-SIZE", null)]
        [DataRow("d:/test.txt", "-SIZE/S", null)]
        [DataRow(null, "-SIZE/S", null)]
        [DataRow("e:/test.txt", "bytes", null)]
        [DataRow("f:/test.txt", "/s-s", null)]
        [DataRow("f:/test.txt", null, null)]
        [DataRow(null, "/s-s", null)]
        [DataRow(null, null, null)]
        public void GetFileSize_Test(string filePath, string fileSizeInput, string expectedResult)
        {
            // Arrange           
            int mockFileSize = 1024;
            fileDetailsMock
                .Setup(fileData => fileData.Size(filePath))
                .Returns(mockFileSize);

            // Act
            fileService = new FileService(fileDetailsMock.Object);
            string actualResult = fileService.GetFileMetaData(fileSizeInput, filePath);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
