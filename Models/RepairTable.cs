using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DingDingPuls.Models
{
    public partial class RepairTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CreatNumber { get; set; }
        public int AssetsId { get; set; }
        public int DepartmentId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? PlanTime { get; set; }

        public DateTime? BrokenTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string WorkerName { get; set; }
        public int? IsFinshed { get; set; }
        public decimal? Cost { get; set; }
        public string Workers { get; set; }

        public string Applicant { get; set; }

        public string Leader { get; set; }
        public string Note { get; set; }
        public string Reason { get; set; }
        public string CheckStatus { get; set; }

        public virtual LegerTable Assets { get; set; }
        public virtual DepartmentTable Department { get; set; }
    }
}