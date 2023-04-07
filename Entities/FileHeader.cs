using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FileSharingAPI.Entities
{
    public class FileHeader
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate{ get; set; }
        public string UserId { get; set; }


    }
}
