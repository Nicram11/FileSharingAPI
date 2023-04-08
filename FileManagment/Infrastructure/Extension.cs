namespace FileSharingAPI.FileManagment.Infrastructure
{
    public class Extension
    {
        public static string GetExtensionFromContentType(string contentType)
        {
            return MimeTypes.MimeTypeMap.GetExtension(contentType);
        }
    }
}
