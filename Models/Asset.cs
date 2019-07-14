using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OGtech.Models
{
    public class Asset
    {
        [Required]       
        public int id { get; set; }
        
        
        [Display(Name = "Name : ")]
        public string name { get; set; }
        
        
        [Display(Name = "Descreption : ")]
        public string descreption { get; set; }
        
        
        [Display(Name = "Type")]
        public Assettype Type { get; set; }
        
        
        [Required]
        [Display(Name = "Type of Asset : ")]
        public int  typeId { get; set; }
    }
}