using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Transfer;
using ForeCast.API;
using ForeCast.Common;

namespace ForeCast
{
    public class ForeCastDownloader:IForeCastDownloader
    {
        private readonly string _folderPath;
        private readonly string _bucketPath;
        private readonly IFileNamesGenerator fileNamesGenerator;
        private readonly string _accessKey;
        private readonly string _privateKey;
        
        public ForeCastDownloader(IAccessData accessData)
        {
            if (accessData == null) throw new ArgumentNullException(nameof(accessData));
            if (!accessData.IsValid())
                throw new ArgumentException("Access data is missing");
            _folderPath = accessData.Folder;
            _bucketPath = accessData.Address;
            fileNamesGenerator = new FileNamesGenerator();
            if (!Directory.Exists(_folderPath))
                throw new Exception($"Please create foder {_folderPath}");
            _accessKey = accessData.AccessKey;
            _privateKey = accessData.PrivateKey;
        }

        public async Task<string> DownloadForeCastFile(DateTime date)
        {
            var fileNames = fileNamesGenerator.CreateFileNames(date);
            string fullName = Path.Combine(_folderPath, fileNames.File);
            if (!File.Exists(fullName))
            {
                try
                {
                    TransferUtility fileTransferUtility;
                    AmazonS3Client client;
                    using (client = new AmazonS3Client(_accessKey, _privateKey, Amazon.RegionEndpoint.USEast1))
                    {
                        var obj = await client.GetObjectAsync(_bucketPath, fileNames.Bucket);
                        using (fileTransferUtility = new TransferUtility(client))
                            await fileTransferUtility.DownloadAsync(fullName, _bucketPath, fileNames.Bucket);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return String.Empty;
                }
                
            }

            return fullName;
        }

        public bool DownloadSucceed(DateTime date)
        {
            var fileName = GetFileName(date);
            return File.Exists(fileName);
        }

        public string GetFileName(DateTime date)
        {
            var fileNames = fileNamesGenerator.CreateFileNames(date);
            return Path.Combine(_folderPath, fileNames.File);
        }

       
    }
}
