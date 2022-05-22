using DAL.Entities;
using System.Threading.Tasks;
using WebApp.Models.Response;

namespace WebApp.Services.CVService
{
    public class CVService : ICVService
    {
        public Task<Response<Cv>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> GetByCvId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> GetByEmpId(string empId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> GetByJobId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> RemoveCv(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Cv>> UploadCv(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}
