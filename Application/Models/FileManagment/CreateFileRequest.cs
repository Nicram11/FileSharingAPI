namespace FileSharingAPI.FileManagment.Model
{
    public class CreateFileRequest
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public string UserId { get; set; }

    }
}
