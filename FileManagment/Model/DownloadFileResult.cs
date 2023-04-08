using FileSharingAPI.Entities;

namespace FileSharingAPI.FileManagment.Model
{
    public class DownloadFileResult
    {
        public static bool SUCCESSED = true;
        public static bool FAILED = false;

        public bool Success { get; set; }
        public Stream Stream { get; set; }
        public FileHeader FileHeader{ get; set; }
        public DownloadFileResult(bool result)
        {
            Success = result;
        }
        public DownloadFileResult(bool result, Stream stream, FileHeader header)
        {
            Success = result;
            Stream = stream;
            FileHeader = header;
        }
    }
}
