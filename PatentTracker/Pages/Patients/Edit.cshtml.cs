using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatentTracker.Model;

namespace PatentTracker.Pages.Patients
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext db;
        public EditModel(ApplicationDBContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Patient patient { get; set; }
        public int CurrentStageId { get; set; }
        public async Task OnGet(int id )
        {
            patient = await db.Patient.FindAsync(id);
           // CurrentStageId = patient.GetCurrentStageID();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // var stageFromDb = await db.Stage.FindAsync(Stage.Id);

                db.Patient.Update(patient);
                await db.SaveChangesAsync();
                return RedirectToPage("Details",new { id = patient.Id });
            }
            return RedirectToPage();
        }
    }
}