using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatentTracker.Model;

namespace PatentTracker.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext db;
        public CreateModel(ApplicationDBContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Patient newpatient { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Patient.Add(newpatient);

            // get the initial stage id to add to patient log
            int initialState = GetInitialStageID();
            
            PatientLog newlog = new PatientLog()
            {
                 EnteredIn = DateTime.Now,
                  PatientID = newpatient.Id,
                  StageID = initialState
            };

            db.PatientLogs.Add(newlog);

            await db.SaveChangesAsync();
            return RedirectToPage("Index", new { id = initialState });
        }

        public int GetInitialStageID()
        {
            return db.Stage.FirstOrDefault(s => s.OrderNumber == 1).Id;
        }
    }
}