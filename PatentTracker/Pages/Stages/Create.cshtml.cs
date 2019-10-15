using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatentTracker.Model;

namespace PatentTracker.Pages.Stages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext db;
        public CreateModel(ApplicationDBContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Stage Stage { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            db.Stage.Add(Stage);
            await db.SaveChangesAsync();
            return RedirectToPage("Index");
        }


    }
}