using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateboaringMVCproject.Models
{
    public class Skateboarding
    {
        public int SkateboardingID { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Attempts { get; set; }
        public bool Landed { get; set; }

        public int TrickTypeID { get; set; }
        public virtual TrickType NameOfTrick { get; set; }
    }
}