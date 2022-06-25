using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace WebApp.Services.CloudService
{
    public class CloudService : ICloudService
    {
        public IConfiguration Configuration { get; set; }
        private Cloudinary _cloudinary;

        public CloudService(IConfiguration configuration)
        {
            Configuration = configuration;
            var cloudName = Configuration.GetValue<string>("AccountSettings:CloudName");
            var apiKey = Configuration.GetValue<string>("AccountSettings:ApiKey");
            var apiSecret = Configuration.GetValue<string>("AccountSettings:ApiSecret");

            _cloudinary = new Cloudinary(new Account() { ApiKey = apiKey, Cloud=cloudName,ApiSecret=apiSecret});
        }

        public string AddImage(IFormFile file)
        {
            
            try
            {
                if (file.Length > 0)
                {
                    var result = new ImageUploadResult();
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream)
                        };
                        result = _cloudinary.Upload(uploadParams);
                    }
                    return result.Url.ToString();
                }
            }
            catch
            {
                return null;
            }
            return null;
          
        }

        public string AddCV(IFormFile file)
        {
            throw new System.NotImplementedException();
        }
    }

}
