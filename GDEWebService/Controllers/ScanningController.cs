using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GDEWebService.ScanningWebWS;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security.Tokens;

namespace GDEWebService.Controllers
{
    public class ScanningController : Controller
    {

        internal class rmScanningWebWSWseExt : rmScanningWebWS

        {
            WebServicesClientProtocol webServicesClientProtocol = new WebServicesClientProtocol();

            //public  rmScanningWebWSWseExt(string username, string password)

            //{

            //    RequireMtom = true;
            //    SetClientCredential(new UsernameToken(username, password, PasswordOption.SendPlainText));
            //    SetPolicy("username");
            //    RMs
            //}

            protected override System.Net.WebRequest GetWebRequest(Uri uri)

            {
                HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
                webRequest.KeepAlive = false; // Set KeepAlive
                return webRequest;
            }

        }


            // GET: Scanning
            public ActionResult Index()
        {
            ComponetScanning();

           

            return View();
        }

        public void ComponetScanning()
        {
            using(rmScanningWebWS rmScanningWebWS = new rmScanningWebWS())
            {

                //rmScanningWebWS s = new rmScanningWebWSWseExt("Lebone", "hgte$ttb");
                //s.Url = "https://gder61uat-scanning.assessor.rm.com/RMScanningWebWS.asmx";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //string temp1 = s.Ping();

                ComponentScanningSetup componentScanningSetup = new ComponentScanningSetup()
                {
                    RequestImages = false,
                    SessionID = 15
                };
                RequestComponentPackets requestComponentPackets = new RequestComponentPackets()
                {
                    ExamSessionID = 1
                };

                var req = rmScanningWebWS.RequestComponentPackets(requestComponentPackets);

                ComponentScanningSetupResult test2 = rmScanningWebWS.ComponentScanningSetup(componentScanningSetup);
                try
                {
                    ComponentScanningSetupResult test = rmScanningWebWS.ComponentScanningSetup(componentScanningSetup);

                }
                catch
                {
                    
                }
            }
        }
    }
}