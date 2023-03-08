using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infrastructure;
using WaterProject.Models;

namespace WaterProject.Pages
{
    public class DonateModel : PageModel
    {
        private IWaterProjectRepository repo { get; set; }
        public DonateModel (IWaterProjectRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
                                                                //?? means if null do the thing on the right
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }
        public IActionResult OnPost(int projectId, string returnUrl)
        {
            Project p = repo.Projects.FirstOrDefault(x => x.ProjectId == projectId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new {ReturnUrl = returnUrl});

        }
    }
}
