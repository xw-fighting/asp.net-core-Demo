using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.EntityFramework.Models
{
    //部门类定义  
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PrimaryManagerId { get; set; } //正管理者外键  d

        public virtual Manager PrimaryManager { get; set; } //正管理者导航  

        public int SecondManagerId { get; set; } //副管理者外键  

        public virtual Manager SecondManager { get; set; } //副管理者导航  
    }
}
