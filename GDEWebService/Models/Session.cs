using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class Session
    {
        public Session()
        {
            Product = new HashSet<Product>();
        }

        public string SessionIdentifier { get; set; }
        public string Name { get; set; }
        public string Timeframe { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
