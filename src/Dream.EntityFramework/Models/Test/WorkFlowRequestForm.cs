using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dream.EntityFramework.Models
{
    public class WorkFlowRequestForm
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string Ext1 { get; set; }

        public string Ext2 { get; set; }

        public string LogicSymbol { get; set; }

        public Decimal Num { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public virtual KeyValue KeyValue1 { get; set; }

        public virtual KeyValue KeyValue2 { get; set; }
    }
}
