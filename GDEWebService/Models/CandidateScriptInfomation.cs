using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class CandidateScriptInfomation
    {
        public int Id { get; set; }
        public string CandidateExamNumber { get; set; }
        public string SubjectCode { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
    }
}
