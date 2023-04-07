﻿namespace FileSharingAPI.FileManagment.Core
{
    public interface IStoreFiles
    {

        public Task<Stream> ReadFileAsync(string fileName, string fileStoragePath);
        public Task SaveFileAsync(IFormFile file, string fileId, string fileStoragePath);
        public Task DeleteFileAsync(string fileName, string fileStoragePath);
    }
}