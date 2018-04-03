using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModels
{
    public class KeyViewModel
    {
        [DataType(DataType.Password)]
        public string Number { get; set; }

        [DataType(DataType.Password)]
        public string AccessKey { get; set; }
    }
}