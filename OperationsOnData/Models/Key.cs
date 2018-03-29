using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperationsOnData.Models
{
    public class Key
    {
        [Key]
        public int Id { get; set; }

        public string AccessKey { get; set; }
    }
}