using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proj2redo.Models
{
    public class Order
    {
        public Int16 OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}