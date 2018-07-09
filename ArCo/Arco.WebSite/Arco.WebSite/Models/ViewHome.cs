using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arco.WebSite.Models
{
    public class ViewHome
    {
        public Setting Setting { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Service> Services { get; set; }
        public List<Number> Numbers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<ChooesU> ChooesUs { get; set; }
        public List<Member> Members { get; set; }
        public List<Package> Packages { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Client> Clients { get; set; }

    }
}