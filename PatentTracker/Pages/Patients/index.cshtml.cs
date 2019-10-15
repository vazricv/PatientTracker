using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatentTracker.Model;

namespace PatentTracker.Pages.Patients
{
    public class indexModel : PageModel
    {
        private readonly ApplicationDBContext db;
        public indexModel(ApplicationDBContext db)
        {
            this.db = db;
            
        }

        public Stage stage;
        public IEnumerable<Patient> patients;
        public async Task OnGet(int id)
        {
            stage = await db.Stage.FindAsync(id);
          //  patients = stage.PatientLogs.Select(p => p.ThePatient).ToList();
            patients =  db.PatientLogs.Where(l => l.StageID == id && l.Completed == null).Select(l => l.Patient).ToList();
        }

        public  IActionResult  OnPostMarkCompleted(int id, int stageID)
        {
            PatientLog patientStage = db.PatientLogs.FirstOrDefault(p=>p.PatientID==id && p.StageID == stageID);
            Stage currentstage = db.Stage.Find(stageID);
            if (patientStage == null)
            {
                return NotFound();
            }
            patientStage.Completed = DateTime.Now;
            //get the next stage
            Stage nextStage =  db.Stage.Where(s => s.OrderNumber > currentstage.OrderNumber).OrderBy(s => s.OrderNumber).First();
            if(nextStage != null)
            {
                PatientLog newLog = new PatientLog()
                {
                    PatientID = id,
                    StageID = nextStage.Id,
                    EnteredIn = DateTime.Now,
                };
                db.Add(newLog);
            }
            db.Attach(patientStage);
            db.SaveChanges();
            return RedirectToPage("/Patients/index",new { id = stageID});
        }
    }
}