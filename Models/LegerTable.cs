using System;
using System.Collections.Generic;

namespace DingDingPuls.Models
{
    public partial class LegerTable
    {
        public LegerTable()
        {
            RepairTable = new HashSet<RepairTable>();
            CheckTable = new HashSet<CheckTable>();
        }

        public int Id { get; set; }
        public string AssetsNumber { get; set; }
        public string AssetsName { get; set; }
        public int AssetsTip { get; set; }
        public int DepartmentId { get; set; }
        public string AssetsClass { get; set; }
        public string EquipmentType { get; set; }
        public int? AccountStatus { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImgUrl { get; set; }

        public virtual DepartmentTable Department { get; set; }
        public virtual ICollection<RepairTable> RepairTable { get; set; }
        public virtual ICollection<CheckTable> CheckTable { get; set; }
    }
}