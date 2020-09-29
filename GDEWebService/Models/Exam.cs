using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class Exam
    {
        public DateTime StartDate { get; set; }
        public string StartDatePart { get; set; }
        public DateTime EndDate { get; set; }
        public int ExamId { get; set; }
    }
}
