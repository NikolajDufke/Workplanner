namespace WorkplannerWebApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
