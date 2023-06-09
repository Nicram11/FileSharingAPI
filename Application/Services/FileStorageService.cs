﻿using AutoMapper;
using FileSharingAPI.Application.Interfaces;
using FileSharingAPI.Entities;
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

        public async Task<SaveFileResult> SaveFileAsync(IFormFile file,CreateFileRequest createFileRequest)
        {
            var createdFileGuid = await _storeFileHeaders.CreateFileHeaderAsync(createFileRequest, _fileStoragePath);
            
            if (createdFileGuid.Equals(Guid.Empty))
                return new SaveFileResult(SaveFileResult.SaveFileResult_FAILED);

            await _storeFiles.SaveFileAsync(file, createdFileGuid, _fileStoragePath);

            return new SaveFileResult(SaveFileResult.SaveFileResult_SUCCESSED, createdFileGuid);

        }

        public async Task<DownloadFileResult> DownloadAsync(Guid guid)
        {
            var fileHeader = await _storeFileHeaders.GetFileHeaderAsync(guid);
            if (fileHeader is null)
                return new DownloadFileResult(DownloadFileResult.FAILED);

           var stream =  await _storeFiles.ReadFileAsync(fileHeader.FilePath);
           if(stream is null)
                return new DownloadFileResult(DownloadFileResult.FAILED);

           return new DownloadFileResult(DownloadFileResult.SUCCESSED, stream, fileHeader);
        }

        public async Task<List<GetFileHeadersResult>> GetUserFileHeadersAsync(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var fileHeaders = await _storeFileHeaders.GetUserFileHeadersAsync(userId);

            var result = new List<GetFileHeadersResult>();
            foreach(var f in fileHeaders)
            {
                result.Add(new GetFileHeadersResult
                {
                    Id = f.Id,
                    FileName = f.FileName,
                    ContentType = f.ContentType,
                    FileSize = f.FileSize,
                    UploadDate = f.UploadDate
                });
            }
            return result;
        }
    }
}
