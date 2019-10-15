using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatentTracker.Model
{
    public class PatientLog
    {
        [Key]
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int StageID { get; set; }
        [Display(Name = "Entered Date")]
        public DateTime EnteredIn { get; set; }
        [Display(Name = "Completed Date")]
        public DateTime? Completed { get; set; }

        [Display(Name = "Duration")]
        public string Duration
        {
            get
            {
                if (Completed == null)
                    return "";

                string result = "";


                int days = (Completed - EnteredIn).Value.Days;
                int hours = (Completed - EnteredIn).Value.Hours;
                int minutes = (Completed - EnteredIn).Value.Minutes;
                int seconds = (Completed - EnteredIn).Value.Seconds;

                if (days > 0)
                    result = days + "D ";
                if (hours > 0)
                    result += hours + "H ";
                if (minutes > 0)
                    result += minutes + "Min";
                else if (seconds > 0)
                    result += seconds + "Sec";

                return result;
            }
        }

        [Display(Name = "Processing Duration")]
        public string DurationToCurrentTime
        {
            get
            {
                TimeSpan duration = (DateTime.Now - EnteredIn);

                string result = "";


                int days = duration.Days;
                int hours = duration.Hours;
                int minutes = duration.Minutes;
                int seconds = duration.Seconds;

                if (days > 0)
                    result = days + "D ";
                if (hours > 0)
                    result += hours + "H ";
                if (minutes > 0)
                    result += minutes + "Min";
                else if (seconds > 0)
                    result += seconds + "Sec";

                return result;
            }
        }
        public TimeSpan DurationToCurrentTimeTimeSpan
        {
            get
            {
                return (DateTime.Now - EnteredIn);
            }
        }

        [Display(Name = "Passed Due")]
        public bool IsPassedDue
        {
            get
            {
                TimeSpan duration = (DateTime.Now - EnteredIn);
                if (this.Completed != null)
                     duration = (this.Completed - EnteredIn).Value;

                if(Stage == null )
                {
                    return false;
                }
                return duration > Stage.DueTime;
            }
        }
        public virtual Patient Patient { get; set; }

        [Display(Name = "Stage Name")]
        public virtual Stage Stage { get; set; }
    }
}
