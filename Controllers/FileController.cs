using FileSharingAPI.FileManagment.Core;
using FileSharingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;


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

            var fileModel = new Entities.FileHeader
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                ContentType = file.ContentType,
                FileSize = file.Length,
                UploadDate = DateTime.Now
            };

            await _fileStorageService.SaveFileAsync(file, fileModel.Id.ToString());
            var shareableLink = Url.Action(nameof(Download), new { id = fileModel.Id});
            return Ok(shareableLink);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Download(string id)
        {
            var fileModel = await _fileStorageService.GetFileAsync(id);
            if (fileModel == null)
            {
                return NotFound();
            }
            var stream = await _fileStorageService.ReadFileAsync(fileModel.FilePath);
            return File(stream, fileModel.ContentType, fileModel.FileName);
        }

    }

}
