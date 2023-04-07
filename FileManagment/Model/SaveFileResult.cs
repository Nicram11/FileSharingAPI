namespace FileSharingAPI.FileManagment.Model
{
    public class SaveFileResult
    {
        public Boolean Success { get; set; }

        public void Failed()
        {
            Success = false;
        }
        public void Successed()
        {
            Success = true;
        }
    }
}
