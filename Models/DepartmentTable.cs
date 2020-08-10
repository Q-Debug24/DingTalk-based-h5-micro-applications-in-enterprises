using System.Collections.Generic;

namespace DingDingPuls.Models
{
    public partial class DepartmentTable
    {
        public DepartmentTable()
        {
            LegerTable = new HashSet<LegerTable>();
            RepairTable = new HashSet<RepairTable>();
            CheckTable = new HashSet<CheckTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LegerTable> LegerTable { get; set; }
        public virtual ICollection<CheckTable> CheckTable { get; set; }
        public virtual ICollection<RepairTable> RepairTable { get; set; }
    }
}