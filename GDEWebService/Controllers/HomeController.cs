using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDEWebService.Models;
using GDEWebService.AssessmentStructureWS;
using System.Threading.Tasks;

namespace GDEWebService.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            using(var db = new RM_GDEContext())
            {
                var listOfSessions = db.QuestionPaper.ToList();

                 return View(listOfSessions);
            }

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateProduct()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> addProduct(string QualificationShortName, string AssessmentIndentifier, 
            string AssessmentName, int AssessmentVersion, string ComponentIdentifier,string ComponentName, int ComponentVersion,
            string SessionIdentifier, string Name,string Timeframe,
            string StartDate,string StartDatePart,string EndDate,
            string QuestionPaperIdentifier,string Barcode, string QuestionPaperPartName, string MarkingType, string NameQP, int PageCount, string SyllabusCode)
        {
            string markingTypeCreated = "MFI";
            string RMKey1 = WebServiceDetails.RMKey;
            AssessmentStructureWS.AssessmentStructureWS test = new AssessmentStructureWS.AssessmentStructureWS();

            ProductArguments productArguments = new ProductArguments();
            ProductReceipt productReceipt = new ProductReceipt();

            ProductArgumentsProduct productArgumentsProduct = new ProductArgumentsProduct();
            ProductArgumentsSession productArgumentsSession = new ProductArgumentsSession();
            ProductArgumentsExam productArgumentsExam = new ProductArgumentsExam();
            ProductArgumentsQuestionPaper productArgumentsQuestionPaper = new ProductArgumentsQuestionPaper();


            productArgumentsProduct.BusinessStreamIndentifier = WebServiceDetails.BusinessStreamIndentifier;
            productArgumentsProduct.QualificationShortName = QualificationShortName;
            productArgumentsProduct.AssessmentIndentifier = AssessmentIndentifier;
            productArgumentsProduct.AssessmentName = AssessmentName;
            productArgumentsProduct.AssessmentVersion = AssessmentVersion;
            productArgumentsProduct.ComponentIdentifier = ComponentIdentifier;
            productArgumentsProduct.ComponentName = ComponentName;
            productArgumentsProduct.ComponentVersion = ComponentVersion;

            productArgumentsSession.SessionIdentifier = SessionIdentifier;
            productArgumentsSession.Name = Name;
            productArgumentsSession.Timeframe = Timeframe;

            productArgumentsExam.StartDate = Convert.ToDateTime(StartDate);
            productArgumentsExam.StartDatePart = StartDatePart;
            productArgumentsExam.EndDate = Convert.ToDateTime(EndDate);


            productArgumentsQuestionPaper.QuestionPaperIdentifier = QuestionPaperIdentifier;
            productArgumentsQuestionPaper.Barcode = Barcode;
            productArgumentsQuestionPaper.QuestionPaperPartName = QuestionPaperPartName;
            productArgumentsQuestionPaper.MarkingType = markingTypeCreated;
            productArgumentsQuestionPaper.Name = NameQP;
            productArgumentsQuestionPaper.PageCount = PageCount;
            productArgumentsQuestionPaper.SyllabusCode = SyllabusCode;

            productArguments.Product = productArgumentsProduct;
            productArguments.Session = productArgumentsSession;
            productArguments.Exam = productArgumentsExam;
            productArguments.QuestionPaper = productArgumentsQuestionPaper;

            productReceipt = test.Product(RMKey1, productArguments);

            if (productReceipt.Success)
            {
                using (var db = new RM_GDEContext())
                {
                    db.Product.Add(new Product
                    {
                        QualificationShortName = QualificationShortName,
                        AssessmentIndentifier = AssessmentIndentifier,
                        AssessmentName = AssessmentName,
                        AssessmentVersion = AssessmentVersion,
                        ComponentIdentifier = ComponentIdentifier,
                        ComponentName = ComponentName,
                        ComponentVersion = ComponentVersion
                    });

                    db.QuestionPaper.Add(new QuestionPaper
                    {
                        QuestionPaperIdentifier = QuestionPaperIdentifier,
                        Barcode = Barcode,
                        QuestionPaperPartName = QuestionPaperPartName,
                        MarkingType = markingTypeCreated,
                        SyllabusCode = SyllabusCode,
                        CreatedDate = DateTime.Now

                        //Add to Table later
                        //Name = NameQP,
                        //PageCount = PageCount,
                    });

                    db.Session.Add(new Session
                    {
                        SessionIdentifier = SessionIdentifier,
                        Name = Name,
                        Timeframe = Timeframe
                    });

                    db.Exam.Add(new Exam
                    {
                        StartDate = Convert.ToDateTime(StartDate),
                        StartDatePart = StartDatePart,
                        EndDate = Convert.ToDateTime(EndDate)
                    });

                    await db.SaveChangesAsync();
                    var listOfSessions = db.QuestionPaper.ToList();
                    return View("Index", listOfSessions);

                }

                
            }
            return View("Index");
        }
    }
}