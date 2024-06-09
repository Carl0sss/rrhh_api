using rrhh_api.Models;

namespace rrhh_api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context) { 
            _context = context;
        }

        public Usuario Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario GetById(string id)
        {
            return _context.Usuarios.SingleOrDefault(u => u.CodUsuario == id);
        }
    }
}
