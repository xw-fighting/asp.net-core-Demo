using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dream.EntityFramework.Models
{
    public class KeyValue
    {
        [Key]
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Remark { get; set; }

        public virtual ICollection<WorkFlowRequestForm> WorkFlowRequestForm1 { get; set; }

        
        public virtual ICollection<WorkFlowRequestForm> WorkFlowRequestForm2 { get; set; }
    }
}
