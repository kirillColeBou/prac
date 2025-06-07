using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac.Classes.Model
{
    public class Partner
    {
        public int id { get; set; }
        public virtual TypePartner typePartner { get; set; }
        public string nameCompany { get; set; }
        public string address { get; set; }
        public string fioDirector { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
        public int rating { get; set; }
    }
}
