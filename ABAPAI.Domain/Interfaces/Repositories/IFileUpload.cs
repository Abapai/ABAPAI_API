using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IFileUpload
    {
        Task<string> UploadBase64ImageAsync(string base64Image);
        void DeleteImageAsync(string blobName);
    }
}
