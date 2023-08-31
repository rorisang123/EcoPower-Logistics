using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proj2redo.Models
{
    public class OrderDetails
    {
        public Int16 OrderDetailsID { get; set; }
        [Required]
        public Int16 OrderId { get; set; }
        public Int16 ProductId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}