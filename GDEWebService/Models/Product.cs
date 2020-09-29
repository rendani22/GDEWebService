using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class Product
    {
        public string QualificationShortName { get; set; }
        public string AssessmentIndentifier { get; set; }
        public string AssessmentName { get; set; }
        public int? AssessmentVersion { get; set; }
        public string ComponentIdentifier { get; set; }
        public string ComponentName { get; set; }
        public int? ComponentVersion { get; set; }
    }
}
