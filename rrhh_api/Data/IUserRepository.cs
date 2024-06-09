using rrhh_api.Models;

namespace rrhh_api.Data
{
    public interface IUserRepository
    {
        Usuario Create(Usuario usuario);
        Usuario GetById(string id);
    }
}
