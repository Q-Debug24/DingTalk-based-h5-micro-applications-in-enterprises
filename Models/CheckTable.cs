using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DingDingPuls.Models
{
    public partial class CheckTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EquName { get; set; }
        public string PlanNumber { get; set; }
        public string CreatNumber { get; set; }
        public int AssetsId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? CheckPlanTime { get; set; }
        public DateTime? CheckStartTime { get; set; }
        public DateTime? CheckEndTime { get; set; }
        public string Applicant { get; set; }
        public string Leader { get; set; }
        public string WorkerName { get; set; }
        public string CheckAreas { get; set; }
        public string CheckResult { get; set; }
        public string CheckCyc { get; set; }
        public string CheckStatus { get; set; }
        public int? IsFinshed { get; set; }
        public decimal? CheckCost { get; set; }
        public string Note { get; set; }

        public virtual LegerTable Assets { get; set; }
        public virtual DepartmentTable Department { get; set; }
    }
}