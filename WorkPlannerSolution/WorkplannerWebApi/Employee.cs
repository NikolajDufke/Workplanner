namespace WorkPlannerWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Worktimes = new HashSet<Worktime>();
        }

        public int EmployeeId { get; set; }

        public int UserID { get; set; }

        public int EInformationID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worktime> Worktimes { get; set; }

        public virtual EmployeeInformation EmployeeInformation { get; set; }

        public virtual User User { get; set; }
    }
}
