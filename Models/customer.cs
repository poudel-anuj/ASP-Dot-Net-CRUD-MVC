using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer.Models
{
    public class customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string cusName { get; set; }
        [Required]
        public string cusEmail { get; set; }
        [Required]
        public string cusAddress { get; set; }
        [Required]
        public DateTime entrydate { get; set; }
        [Required]
        public DateTime updateDate { get; set; }
        [Required]
        public int depId { get; set; }
        
        public string departName { get; set; }
    }
}