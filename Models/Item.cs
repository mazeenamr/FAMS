using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OGtech.Models
{
    public class Item
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public string RFIDCode { get; set; }
        public string descreption { get; set; }
       
        public Asset Asset{ get; set; }

        public Location Location { get; set; }



    }
}