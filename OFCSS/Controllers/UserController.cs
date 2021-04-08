using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OFCSS.ViewModel;
using Microsoft.AspNetCore.Identity;
using OFCSS.Models;
using Microsoft.AspNetCore.Http;

namespace OFCSS.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(AppDbContext context,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

              

                if (result.Succeeded)
                { 
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    { 
                        return RedirectToAction("index", "Home");
                    }

                }


                ModelState.AddModelError(string.Empty, "Invalide login !!");

            }
            return View(model);
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.usertype)
                {
                    //var farmerObj = new Admin
                    //{
                    //    fname = model.fname,
                    //    lname = model.lname,
                    //    state = model.state,
                    //    distric = model.distric,
                    //    taluka = model.taluka,
                    //    village = model.village,
                    //    email = model.email,
                    //    mno = model.mno,
                    //    password = model.password
                    //};
                    //context.admins.Add(farmerObj);

                    var farmerObj = new Farmer
                    {
                        fname = model.fname,
                        lname = model.lname,
                        state = model.state,
                        distric = model.distric,
                        taluka = model.taluka,
                        village = model.village,
                        email = model.email,
                        mno = model.mno,
                        password = model.password

                    };
                    context.farmers.Add(farmerObj);


                }
                else {

                    var merchantObj = new Merchant
                    {
                        fname = model.fname,
                        lname = model.lname,
                        state = model.state,
                        distric = model.distric,
                        taluka = model.taluka,
                        village = model.village,
                        email = model.email,
                        mno = model.mno,
                        password = model.password

                    };
                    context.merchants.Add(merchantObj);

                }

                
                var user = new IdentityUser
                {
                    UserName = model.email,
                    Email = model.email
                };

                var result = await userManager.CreateAsync(user, model.password);
                

                if (result.Succeeded)
                {

                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
