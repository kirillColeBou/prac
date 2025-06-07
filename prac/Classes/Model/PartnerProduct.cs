using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac.Classes.Model
{
    public class PartnerProduct
    {
        public int id { get; set; }
        public virtual Product product { get; set; }
        public virtual Partner partner { get; set; }
        public int countProduct { get; set; }
        public DateTime dateSell { get; set; }
    }
}
