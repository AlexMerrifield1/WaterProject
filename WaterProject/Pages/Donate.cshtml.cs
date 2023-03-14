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
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public DonateModel (IWaterProjectRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

    

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int projectId, string returnUrl)
        {
            Project p = repo.Projects.FirstOrDefault(x => x.ProjectId == projectId);

            basket.AddItem(p, 1);


            return RedirectToPage(new {ReturnUrl = returnUrl});

        }
        public IActionResult OnPostRemove(int projectId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Project.ProjectId == projectId).Project);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

    }
}

//__________________________________________________________________
//Inside the OnGet
//?? means if null do the thing on the right
//basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();           This isn't used anymore cause we changecd the way Sessions are working

//_______________________________________________________________________
//Inside the OnPost
//basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();           This isn't used anymore cause we changecd the way Sessions are working
//HttpContext.Session.SetJson("basket", basket);           This isn't used anymore cause we changecd the way Sessions are working
