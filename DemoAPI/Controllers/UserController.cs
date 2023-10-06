using DAL;
using DAL.Interfaces;
using DAL.Models;
using DemoAPI.Tools;
using DemoASP.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
      private readonly IUserRepository _userRepository;
      public UserController(IUserRepository userRepository)
      {
         _userRepository = userRepository;
      }
      [HttpGet]
      public IActionResult GetAll() 
      {
         return Ok(_userRepository.ReadAll().Select(u => u.ToUserView()));
      }
      [HttpGet("{id}")]
      public IActionResult GetById([FromRoute]Guid id) 
      {
         return Ok(_userRepository.ReadOne(id).ToUserView);
      }
      [HttpPost("Register")]
      public IActionResult Register(UserRegisterForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(user);
         }
         try
         {
            if (_userRepository.Register(user.Email, user.Password, user.Username))
            {
               return Ok("Utilisateur enregistré");
            }
            return Ok();
         }
         catch (Exception ex)
         {

            BadRequest(ex.Message);
         }
         return Ok();

      }

      [HttpPost("Login")]
      public IActionResult Login(UserLoginForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         try
         {
            User u = _userRepository.Login(user.Email, user.Password);
            //_session.ConnectedUser = u;
            return Ok($"{u.UserName} est bien connecté");
         }
         catch (Exception ex)
         {
            return BadRequest(ex.Message);
         }
      }
      //[HttpGet("Logout")]
      //public IActionResult Logout() 
      //{
      //   _session.Logout();
      //   return Ok();
      //}
   }
}
