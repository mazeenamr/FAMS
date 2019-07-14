using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OGtech.Models
{
    public class Location
    {


        public int id { get; set; }
        [Display(Name = "Name : ")]
        [Required]
        public string name { get; set; }
        public string RFIDCode{ get; set; }

        public Location ParentLocId { get; set; }
        public List<Item> Items { get; set; }
    }
}