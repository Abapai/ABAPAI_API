using ABAPAI.Domain.Interfaces.Repositories;
using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ABAPAI.Infra.Repositories
{
    public class FileUpload : IFileUpload
    {
        private readonly string NAME_CONTAINER;

        private readonly string KEY_CONTAINER;

        public FileUpload(string name_container, string key_container)
        {
            NAME_CONTAINER = name_container;
            KEY_CONTAINER = key_container;
        }

        public async Task<string> UploadBase64ImageAsync(string base64Image)
        {
            try
            {
                // Gera um nome randomico para imagem
                var filename = Guid.NewGuid().ToString() + ".jpg";

                //Limpa o hash base64 enviado
                var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

                //Convertendo um Base64 para Array de Bytes
                byte[] imageBytes = Convert.FromBase64String(data);

                // Define o Blob no qual a imagem será armazenada 
                var blobClient = new BlobClient(KEY_CONTAINER, NAME_CONTAINER, filename);

                //Envia a imagem
                using (var stream = new MemoryStream(imageBytes))
                {
                    await blobClient.UploadAsync(stream);
                }

                return blobClient.Uri.AbsoluteUri;
            }
            catch
            {
                throw;
            }

        }

        public async void DeleteImageAsync(string blobName)
        {
            try
            {

                // Define a conexão de qual blob
                var blobClient = new BlobClient(KEY_CONTAINER, NAME_CONTAINER, blobName);

                //Deleta se existir 
                await blobClient.DeleteIfExistsAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateImageAsync(string base64Image, string blobName_Actual)
        {
            try
            {
                // Gera um nome randomico para imagem
                var filename = Guid.NewGuid().ToString() + ".jpg";

                //Limpa o hash base64 enviado
                var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

                //Convertendo um Base64 para Array de Bytes
                byte[] imageBytes = Convert.FromBase64String(data);

                // Define a conexão de qual blob
                var blobClient = new BlobClient(KEY_CONTAINER, NAME_CONTAINER, blobName_Actual);
                var exist = await blobClient.ExistsAsync();
                if (exist)
                {
                    using (var stream = new MemoryStream(imageBytes))
                    {
                        await blobClient.UploadAsync(stream, overwrite: true);
                    }
                    return true;
                }

                return false;
            }
            catch
            {
                return false;                
            }
        }
    }
}
