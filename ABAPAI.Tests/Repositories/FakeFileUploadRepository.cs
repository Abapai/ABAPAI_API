using ABAPAI.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace ABAPAI.Tests.Repositories
{
    public class FakeFileUploadRepository : IFileUpload
    {
        public void DeleteImageAsync(string blobName)
        {

        }

        public Task<bool> UpdateImageAsync(string base64Image, string blobName_Actual)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<string> UploadBase64ImageAsync(string base64Image)
        {
            var filename = Guid.NewGuid().ToString() + ".jpg";
            return Task.FromResult<string>(filename);
        }
    }
}
