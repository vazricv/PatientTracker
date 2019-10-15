using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PatentTracker.Model;

namespace PatentTracker.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int OrderBy { get; set; }
        public string name { get; set; }

        private ApplicationDBContext db;

        public List<Patient> PatientsList = new List<Patient>();

        public IndexModel(ApplicationDBContext db)
        {
            this.db = db;
            name = "Vazric";
        }
        public async Task OnGetAsync()
        {
            var patients = from p in db.Patient
                           join l in db.PatientLogs on p.Id equals l.PatientID
                           join s in db.Stage on l.StageID equals s.Id
                           where l.Completed == null && (string.IsNullOrWhiteSpace(SearchString) || p.Name.Contains(SearchString))
                           select new { p, l, s };
            switch(OrderBy)
            {
                case 0: // soft by name
                    patients = patients.OrderBy(i => i.p.Name);
                    break;
                case 1: // soft by stage level
                    patients = patients.OrderBy(i => i.s.OrderNumber);
                    break;
                case 2: // soft by duration highest
                    patients = patients.OrderByDescending(i => i.l.DurationToCurrentTimeTimeSpan);
                    break;
                case 3: // soft by duration lowest
                    patients = patients.OrderBy(i => i.l.DurationToCurrentTimeTimeSpan);
                    break;
                case 4: // soft by duration - past dues first then highest to lowest
                    patients = patients.OrderByDescending(i => i.l.IsPassedDue).ThenByDescending(i=>i.l.DurationToCurrentTimeTimeSpan);
                    break;
            }
            PatientsList = await patients.Select(i=>i.p).ToListAsync();
        }

        public IActionResult GetTheDepartments()
        {
            return Page();
        }
    }
}
