using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatentTracker.Model;

namespace PatentTracker.Pages.Stages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext db;
        public EditModel(ApplicationDBContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Stage Stage { get; set; }
        public async Task OnGet(int id)
        {
            Stage = await db.Stage.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // var stageFromDb = await db.Stage.FindAsync(Stage.Id);
                               
                db.Stage.Update(Stage);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
           // return RedirectToPage();
        }
    }
}