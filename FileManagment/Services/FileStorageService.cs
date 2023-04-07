using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Core;
using FileSharingAPI.FileManagment.Model;
using System;
using System.IO;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace FileSharingAPI.Services
{
    public class FileStorageService : IFileStorageService
    {

        private readonly string _fileStoragePath;
        private readonly IConfiguration _configuration;
        private readonly IStoreFileHeaders _storeFileHeaders;
        private readonly IStoreFiles _storeFiles;

        public FileStorageService(IConfiguration configuration, IStoreFileHeaders storeFileHeaders, IStoreFiles storeFiles)
        {
            _configuration = configuration;
            this._storeFileHeaders = storeFileHeaders;
            this._storeFiles = storeFiles;

            _fileStoragePath = _configuration["AppSettings:FilesPath"];
        }


        public async Task<SaveFileResult> SaveFileAsync(IFormFile file,CreateFileRequest createFileRequest ,Claim user)
        {

            var result = await _storeFileHeaders.CreateFileHeaderAsync(createFileRequest);
            
            if (result.Equals(Guid.Empty))
                return new SaveFileResult(SaveFileResult.SaveFileResult_FAILED);

            await _storeFiles.SaveFileAsync(file, result, _fileStoragePath);

            return new SaveFileResult(SaveFileResult.SaveFileResult_SUCCESSED);


        }

    }
}
