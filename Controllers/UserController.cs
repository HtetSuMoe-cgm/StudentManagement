using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Services;
using LoginAndCRUDCoreProject.ViewsModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace LoginAndCRUDCoreProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IStudentService _studentService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IStudentService studentService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._studentService = studentService;
        }

        [HttpGet("/login")]
        public ActionResult Login()
        {
            return View("UserLogin");
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginVM loginForm , string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(loginForm.Email, loginForm.Password, loginForm.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return View("UserLogin");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet("/register")]
        public ActionResult Register()
        {
            return View("UserRegister");
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterVM registerForm)
        {
            IFormFile profilePicture = Request.Form.Files.FirstOrDefault(); ;
            byte[] imageBytes = null;
            if (profilePicture != null)
            {
                using var dataStream = new MemoryStream();
                await profilePicture.CopyToAsync(dataStream);
                imageBytes = dataStream.ToArray();
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    ProfilePicture = imageBytes,
                    Name = registerForm.Name,
                    UserName = registerForm.Email,
                    Email = registerForm.Email,
                    CreatedAt = DateTime.Now
                };
                
                var result = await _userManager.CreateAsync(user, registerForm.Password);
                if (result.Succeeded)
                {
                    string rolname = "User";
                    await _userManager.AddToRoleAsync(user, rolname);
                    await _signInManager.SignInAsync(user, false);
                    StudentDto student = new StudentDto();
                    student.Name = registerForm.Name;
                    student.Email = registerForm.Email;
                    student.Address = registerForm.Address;
                    student.UserId = await _userManager.GetUserIdAsync(user);
                    _studentService.doAddStudent(student);
                    return RedirectToAction("Index", "Student");
                }
                foreach (IdentityError? error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("UserRegister",registerForm);
        }
    
        [HttpGet]
        [Route("/Home/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
