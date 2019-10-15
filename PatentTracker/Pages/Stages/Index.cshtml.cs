using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatentTracker.Model;

namespace PatentTracker.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private ApplicationDBContext db;
        public IndexModel(ApplicationDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<Stage> Stages { get; set; }
        public async Task OnGet()
        {
            Stages = await db.Stage.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var stage = await db.Stage.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }

            db.Stage.Remove(stage);
            await db.SaveChangesAsync();
            return RedirectToPage("index");
        }
    }
}