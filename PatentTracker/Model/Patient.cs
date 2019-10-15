using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatentTracker.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        [BirthDateValidation]
        public DateTime BOD { get; set; }

        private readonly ApplicationDBContext db;

        [NotMapped]
        public Stage CurrentStage { get
            {
                if (db == null)
                    return null;
                return db.PatientLogs.Include(l => l.Stage).FirstOrDefault(l => l.Completed == null && l.PatientID == this.Id).Stage;
            } }

        public int Age
        {
            get
            {
                return (DateTime.Today.Year - BOD.Year);
            }
        }

        public int GetCurrentStageID()
        {
            if (db == null)
                return -1;
            return db.PatientLogs.FirstOrDefault(l=>l.Completed == null && l.PatientID == this.Id).StageID;

        }

        public string GetCurrentStageProcessingDuration()
        {
            if (db == null)
                return "";
            PatientLog currentStageLog = db.PatientLogs.FirstOrDefault(l => l.Completed == null && l.PatientID == this.Id);
            return currentStageLog.DurationToCurrentTime;
        }

        public bool IsPassedDueOnCurrentStage{ get {
                if (db == null)
                    return false; 
                    
                PatientLog currentStageLog = db.PatientLogs.Include(l => l.Stage ).FirstOrDefault(l => l.Completed == null && l.PatientID == this.Id);
                return currentStageLog.IsPassedDue;
            } }
        // [InverseProperty("ThePatient")]
        public virtual ICollection<PatientLog> PatientLogs  { get; set; }

        public class BirthDateValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime dt = (DateTime)value;
                if (dt < DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage ?? "Make sure the entered date of birth is correct and valid!");
            }

        }

        public Patient(ApplicationDBContext db)
        {
            this.db = db;
        }
        public Patient()
        {

        }
    }
}
