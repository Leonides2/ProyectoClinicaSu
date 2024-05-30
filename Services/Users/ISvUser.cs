using Entidades;

namespace Services.Users
{
    public interface ISvUser
    {
        public List<User> GetUsers();
        public User GetUserById(int id);

        public void AddUser(User user);
        public void UpdateUser( User user);
        public void DeleteUser(int id);
    }
}
