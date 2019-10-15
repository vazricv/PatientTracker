using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatentTracker.Model;

namespace PatentTracker.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDBContext db;
        public DetailsModel(ApplicationDBContext db)
        {
            this.db = db;
        }
        public Patient patient { get; set; }
        public List<PatientLog> patientLogs {get;set;}

        public Stage currentStage { get; set; }

        public async Task OnGet(int id)
        {
            patient = db.Patient.Include(p => p.PatientLogs).ThenInclude(p => p.Stage).FirstOrDefault(p => p.Id == id);

            //patient = await db.Patient.FindAsync(id);

            //patientLogs = db.PatientLogs.Include(p => p.Stage).Where(l => l.PatientID == id).OrderBy(l => l.Stage.OrderNumber).ToList();

            patientLogs = patient.PatientLogs.ToList();            

            currentStage = patientLogs.FirstOrDefault(l => l.Completed == null).Stage;
        }
    }
}