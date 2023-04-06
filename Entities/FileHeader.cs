namespace FileSharingAPI.Entities
{
    public class FileHeader
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate{ get; set; }
        public Guid UserId { get; set; }


    }
}
