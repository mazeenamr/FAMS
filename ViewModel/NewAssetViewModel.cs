using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OGtech.Models;

namespace OGtech.ViewModel
{
    public class NewAssetViewModel
    {
        public IEnumerable<Assettype> Assettypes{ get; set; }
        public Asset Asset { get; set; }
    }
}