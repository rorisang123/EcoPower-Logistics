using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proj2redo.Models
{
    public class Customer
    {
        public Int16 CustomerId { get; set; }
        [Required]
        public string CustomerTitle { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CellPhone { get; set; }
    }
}