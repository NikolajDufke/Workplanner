namespace WorkPlannerWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worktime")]
    public partial class Worktime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkTimeID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
