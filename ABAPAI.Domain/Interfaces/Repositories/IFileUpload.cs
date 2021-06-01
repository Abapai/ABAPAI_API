using System.Threading.Tasks;

namespace ABAPAI.Domain.Interfaces.Repositories
{
    public interface IFileUpload
    {
        Task<string> UploadBase64ImageAsync(string base64Image);
        void DeleteImageAsync(string blobName);

        Task<bool> UpdateImageAsync(string base64Image, string blobName_Actual);
    }
}
