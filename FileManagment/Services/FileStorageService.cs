using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Core;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FileSharingAPI.Services
{
    public class FileStorageService : IFileStorageService
    {

        private readonly string _fileStoragePath;
        private readonly IConfiguration _configuration;

        public FileStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _fileStoragePath = _configuration["AppSettings:FilesPath"];
        }


        public  SaveFileAsync()
        {

        }

    }
}
