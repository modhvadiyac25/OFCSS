using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OFCSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFCSS.Controllers
{
    public class MerchantController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public MerchantController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
         

        [HttpGet]
        public ActionResult ShowMerchantRequirment()
        {
            return View(context.merchantRequirments.ToList());
        }
        
        [HttpGet]
        public IActionResult CreateMerchantRequirment()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateMerchantRequirment(MerchantRequirment model)
        {
            if (ModelState.IsValid)
            {
                var data = context.merchants.AsQueryable();
                Merchant merchant= null;
                if (User.Identity.Name != null)
                {
                    merchant = context.merchants.Where(x => x.email == User.Identity.Name.ToLower()).SingleOrDefault();
                }

                MerchantRequirment obj = new MerchantRequirment
                {
                    mr_name = model.mr_name,
                    mr_quantity = model.mr_quantity,
                    mr_price = model.mr_price,
                    mr_discription = model.mr_discription,
                    m_id = merchant.m_id
                };

                var result = context.merchantRequirments.Add(obj);
                context.SaveChanges();
                string temp = result.ToString();
                return RedirectToAction("CreateMerchantRequirment", "Merchant");
            }
            return RedirectToAction("CreateMerchantRequirment", "Merchant");

          
        }
    }
}
