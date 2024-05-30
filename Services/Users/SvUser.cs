using Entidades;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;


namespace Services.Users
{
    public class UserService : ISvUser
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.Include(u => u.Rol).ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Include(u => u.Rol).FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }

}
