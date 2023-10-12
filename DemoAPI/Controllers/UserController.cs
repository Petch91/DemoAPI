using DAL;
using DAL.Interfaces;

using DemoAPI.Models;
using DemoAPI.Tools;
using DemoASP.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
      private readonly IUserService _UserService;
      private readonly TokenManager _tokenManager;
      public UserController(IUserService UserService,TokenManager tokenManager)
      {
         _UserService = UserService;
         _tokenManager = tokenManager;
      }
      [Authorize("AdminPolicy")]
      [HttpGet]
      public IActionResult GetAll() 
      {
         return Ok(_UserService.ReadAll().Select(u => u.ToUserView()));
      }
      [Authorize("IsConnected")]
      [HttpGet("{id}")]
      public IActionResult GetById([FromRoute]int id) 
      {
         return Ok(_UserService.ReadOne(id).ToUserView());
      }
      [HttpPost("register")]
      public IActionResult Register(UserRegisterForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(user);
         }
         try
         {
            if (_UserService.Register(user.Email, user.Password, user.Username))
            {
               return Ok(user);
            }
            return Ok();
         }
         catch (Exception ex)
         {

            BadRequest(ex.Message);
         }
         return Ok();

      }

      [HttpPost("login")]
      public IActionResult Login(UserLoginForm user)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest();
         }
         try
         {
            User u = _UserService.Login(user.Email, user.Password).ToAPI();
            u.Token = _tokenManager.GenerateToken(u);
            return Ok(u);
         }
         catch (Exception ex)
         {
            return BadRequest(ex.Message);
         }
      }

   }
}
