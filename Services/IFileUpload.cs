namespace ProductManagementSystem.Services
{
    public interface IFileUpload
    {
        Task<bool> UploadFile(IFormFile file);
        String FileName { get; set; }
    }
}
