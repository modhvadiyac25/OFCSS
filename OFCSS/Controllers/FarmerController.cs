using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OFCSS.Models;
using OFCSS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public FarmerController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult CreateCropSale() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCropSale(CreateCropSaleViewModel model) {

            if (ModelState.IsValid) {

                var data = context.farmers.AsQueryable();
                Farmer farmer = null;
                if (User.Identity.Name != null) {
                     farmer = context.farmers.Where(x => x.email == User.Identity.Name.ToLower()).SingleOrDefault();
                }
                CropSale obj = new CropSale
                {   
                    cname = model.cname,
                    cquantity = model.cquantity,
                    cprice = model.cprice,
                    cdiscription = model.cdiscription,
                    f_id = farmer.f_id
                };
                var result = context.cropSales.Add(obj);
                context.SaveChanges();
                string temp = result.ToString();
                return RedirectToAction("CreateCropSale", "Farmer");
            }  
            return RedirectToAction("CreateCropSale", "Farmer");
        } 

        [HttpGet]
        public IActionResult ShowCropSale()
        {
            

            return View(context.cropSales.ToList());  
        }
        
        [HttpPost]
        public IActionResult ShowCropSale(CropSale s)
        {
            return View();  
        }

    }
}
