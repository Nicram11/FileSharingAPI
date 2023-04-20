namespace FileSharingAPI.FileManagment.Model
{
    public class SaveFileResult
    {
        public static bool SaveFileResult_SUCCESSED = true;
        public static bool SaveFileResult_FAILED = false;
        public Guid CreatedFileGuid{ get; set; }
        public Boolean Success { get; set; }
        public SaveFileResult(bool result)
        {
            Success = result;
        }
        public SaveFileResult(bool result, Guid createdFileGuid)
        {
            Success = result;
            CreatedFileGuid = createdFileGuid;
        }
        public void Failed() => Success = false;
      
        public void Successed() => Success = true;
    
    }
}
