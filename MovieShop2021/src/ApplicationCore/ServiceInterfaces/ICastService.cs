using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public interface ICastService
    {
        Task<CastResponseModel> GetCastDetailByMovieId(int id);
    }
}