using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Email;
using Services.Users;

namespace ProyectoClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISvUser _usuariosService;
        private readonly ISvEmail _emailService;
        private readonly IConfiguration _config;

        public UsersController(ISvUser usuariosService, ISvEmail emailService, IConfiguration config)
        {
            _usuariosService = usuariosService;
            _emailService = emailService;
            _config = config;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
        public List<User> GetUsers()
        {
            var usuarios_request = _usuariosService.GetUsers();

            if (usuarios_request == null)
            {
                return null;
            }

            return usuarios_request;
        }


        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            var usuario =  _usuariosService.GetUserById(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        [Authorize(Policy = "User")]
        [HttpPut("{id}")]
        public void UpdateUser(User user)
        {
            try
            {
                _usuariosService.UpdateUser(user);
            }
            catch (Exception e)
            {
                throw new Exception("Error: can't update user", e);
            }


        }


        [HttpPost]
        public void AddUser(User user)
        {
            GmailSettings settings = new GmailSettings();
            settings.Port = _config.GetValue<int>("GmailSettings:Port");
            settings.Server = _config.GetValue<string>("GmailSettings:Server");
            settings.Username = _config.GetValue<string>("GmailSettings:Username");
            settings.Password = _config.GetValue<string>("GmailSettings:Password");


            try { _usuariosService.AddUser(user); } catch(Exception e) { throw new Exception("Error: can't add user", e); }
             

            string subject = "Bienvenido a nuestra clinica";
            string message = $"Hola {user.UserName}, bienvenido a nuestra web.";

            _emailService.SendEmail(user.Paciente!.Email!, subject, message, settings);

        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            try
            {
                _usuariosService.DeleteUser(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error: can't delete user", e);
            }
        }
    }
}
