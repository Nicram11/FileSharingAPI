using FileSharingAPI.Entities;
using FileSharingAPI.FileManagment.Core;
using FileSharingAPI.FileManagment.Model;
using FileSharingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Claims;

namespace FileSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        public FileController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            var createFileRequest = new CreateFileRequest()
            {
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileSize = file.Length,
                UploadDate = DateTime.Now,
                UserId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value
            };

        

            var result = await _fileStorageService.SaveFileAsync(file, createFileRequest);
            
            if (!result.Success)
                return BadRequest("Something went Wrong");


            var shareableLink = Url.Action(nameof(Download), new { id = result.CreatedFileGuid});
            return Ok(shareableLink);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Download(Guid id)
        {
          
               var result = await _fileStorageService.DownloadAsync(id);
            if(result.Success)
               return File(result.Stream, result.FileHeader.ContentType, result.FileHeader.FileName);

            return NotFound();

          
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFiles()
        {
            var files = await _fileStorageService.GetUserFileHeadersAsync(User);

            return Ok(files);
        }

    }

}
