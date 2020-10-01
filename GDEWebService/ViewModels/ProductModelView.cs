using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDEWebService.Models;

namespace GDEWebService.ViewModels
{
    public class ProductModelView
    {
        public List<Session> session { get; set; }
        public List<Product> product { get; set; }
        public string SelectedCountryIso3 { get; set; }
        public IEnumerable<QuestionPaperList> QuestionsPaper { get; set; }

    }

    public class QuestionPaperList
    {
        public string value { get; set; }
        public string text { get; set; }

    }
}