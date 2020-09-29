using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class Packets
    {
        public int CenterId { get; set; }
        public string CentreIdentifier { get; set; }
        public DateTime? DateCreated { get; set; }
        public string SessionIdentifier { get; set; }
        public string AssessmentIdentifier { get; set; }
        public string ComponentIdentifier { get; set; }
    }
}
