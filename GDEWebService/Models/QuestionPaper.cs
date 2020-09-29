using System;
using System.Collections.Generic;

namespace GDEWebService.Models
{
    public partial class QuestionPaper
    {
        public string QuestionPaperIdentifier { get; set; }
        public string Barcode { get; set; }
        public string QuestionPaperPartName { get; set; }
        public string MarkingType { get; set; }
        public string SyllabusCode { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
