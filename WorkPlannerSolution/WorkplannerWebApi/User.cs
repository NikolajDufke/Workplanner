﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WorkplannerWebApi
{
    public partial class User
    {
        public User()
        {
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public int AccessLevel { get; set; }

        public virtual Access AccessLevelNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}