namespace FileSharingAPI.FileManagment.Model
{
    public class GetFileHeadersResult
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
