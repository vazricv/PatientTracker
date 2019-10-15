using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PatentTracker.Model
{
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Stage Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [CustomValidation(typeof(Stage), "ValidateOrderNumber")]
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        [Required]
        [Display(Name ="Due Time")]
       // [DataType(DataType.Duration)]
        [DisplayFormat(DataFormatString = "{0:dd\\:hh\\:mm}", ApplyFormatInEditMode = true)]
        
        public TimeSpan DueTime { get; set; }

        //[InverseProperty("TheStage")]
        public virtual ICollection<PatientLog> PatientLogs { get; set; }

        public String DueTimeDisplay
        {
            get
            {
                string result = "";
                if (DueTime.Days > 0)
                    result = DueTime.Days + "D ";
                if (DueTime.Hours > 0)
                    result += DueTime.Hours + "H ";
                if (DueTime.Minutes > 0)
                    result += DueTime.Minutes + "Min";

                return result;
            }
        }

        public int NumberOfPatients
        {
            get
            {
                if (db != null)
                {
                    return db.PatientLogs.Count(l => l.StageID == this.Id && l.Completed == null);
                }
                //this is either an error situation or loading the stage without DB context 
                return -1;
            }
        }
        public static ValidationResult ValidateOrderNumber(int value, ValidationContext context)
        {

            if (value <= 0)
                return new ValidationResult("Order Number should be grater than 0.");
            
            //if(.Stage.Any(s=>s.OrderNumber == value))
            

            return ValidationResult.Success;

        }

        private readonly ApplicationDBContext db;
        public Stage(ApplicationDBContext db)
        {
            this.db = db;

        }
        public Stage()
        {
            
        }
    }

}
