using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class Candidates
    {
        public int Id { get; set; }
        public string Prov { get; set; }
        public string ProvName { get; set; }
        public string Region { get; set; }
        public string RegName { get; set; }
        public string District { get; set; }
        public string DistrName { get; set; }
        public byte Circuit { get; set; }
        public string CircName { get; set; }
        public string Emis { get; set; }
        public string CentreName { get; set; }
        public string ExamType { get; set; }
        public string ExamTypeName { get; set; }
        public string Grade { get; set; }
        public string ExamPeriod { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string Paper { get; set; }
        public string PaperDesc { get; set; }
        public string PaperType { get; set; }
        public string PaperMax { get; set; }
        public DateTime? PaperDate { get; set; }
        public string PaperTime { get; set; }
        public string PaperDuration { get; set; }
        public string MsNo { get; set; }
        public string Idno { get; set; }
        public string Candidate { get; set; }
        public DateTime? Dob { get; set; }
    }
}
