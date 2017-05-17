using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.EntityFramework.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Department> PrimaryDepartments { get; set; } //正职部门导航  

        public virtual ICollection<Department> SecondDepartments { get; set; } //副职部门导航
    }
}
