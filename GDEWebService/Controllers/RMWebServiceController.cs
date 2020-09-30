using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDEWebService.Models;
using System.IO;
using System.Data;
using GDEWebService.MarkerProvisioningWS;
using GDEWebService.AssessmentStructureWS;
using GDEWebService.SessionCompositionWS;
using GDEWebService.ScanningWebWS;
using System.Globalization;
using System.Xml.Serialization;
using System.Xml;

namespace GDEWebService.Controllers
{
    public class RMWebServiceController : Controller
    {
        // GET: RMWebService
        public  ActionResult Marker()
        {

            RM_GDEContext context = new RM_GDEContext();

            var markerList =  context.Markers.ToList();

            return View(markerList);
        }

        public  ActionResult addMarker(string persalNumber, string surname, string email)
        {
            string RMKey = WebServiceDetails.RMKey;
            var markerType = "Marker";
            string[] surnameInitials = surname.Split(',');

            MarkerProvisioningWS.MarkerProvisioningWS marker  =  new MarkerProvisioningWS.MarkerProvisioningWS();

            MarkerArguments markerArguments = new MarkerArguments();

            markerArguments.MarkerIdentifier = persalNumber;
            markerArguments.MarkerType = markerType;
            markerArguments.Surname = surnameInitials[0];
            markerArguments.Initials = surnameInitials[1];
            markerArguments.Email = email;

            var markerSent =  marker.Marker(RMKey, markerArguments);

            if (markerSent.Success)
            {
                //string SessionIdentifier = "June223";
                //string AssessmentIdentifier = "ENGFZ";
                //int AssessmentVersion = 1;
                //string ComponentIdentifier = "ENGFZ1";
                //int ComponentVersion = 1; 29285305

                MarkerAttribute[] attributes = new MarkerAttribute[1];
                MarkerAttribute markerAttribute = new MarkerAttribute { Descriptor = "Browse Rights",Value = "BM" };

                attributes[0] = markerAttribute;

                Target[] target = new Target[1];

                target[0] = new Target { TargetType = "Live", MaximumMarkingCount = 100, MarkingCompletionDate = DateTime.Now };
                //target[1] = new Target { TargetType = "Practice", MaximumMarkingCount = 15, MarkingCompletionDate = DateTime.Now };
                //target[2] = new Target { TargetType = "Standardisation", MaximumMarkingCount = 10, MarkingCompletionDate = DateTime.Now };


                Marker marker1 = new Marker
                {
                    MarkerIdentifier = persalNumber,
                    MarkerType = "Marker",
                    RoleName = "Assistant Principal Examiner",
                    Priority = 1,
                    Attributes = attributes
                };

                MarkerResponsibilitiesArguments markerResponsibilitiesArguments = new MarkerResponsibilitiesArguments
                {
                    BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
                    SessionIdentifier = "Comp1",
                    AssessmentIdentifier = "Comp1",
                    AssessmentVersion = 1,
                    ComponentIdentifier = "Comp1",
                    ComponentVersion = 1,
                    Marker = marker1,
                    ParentMarker = new ParentMarker { MarkerIdentifier = "29285305", MarkerType = "Chief Marker" },
                    Targets = target
                };

                SessionCompositionWS.SessionCompositionWS sessionCompositionWS = new SessionCompositionWS.SessionCompositionWS();
                var MarkerResponsibilitie =  sessionCompositionWS.MarkerResponsibilities(WebServiceDetails.RMKey, markerResponsibilitiesArguments);
            }
            RM_GDEContext context = new RM_GDEContext();
            var markerList = context.Markers.ToList();
            return View("Marker", markerList);

        }

        public ActionResult questionPaperLayout(string QuestionPaperIdentifier)
        {

            using(AssessmentStructureWS.AssessmentStructureWS Layout = new AssessmentStructureWS.AssessmentStructureWS())
            {

                var imageZone = new ImageZone
                {
                    ImageZoneIdentifier = 1,
                    Name = "Zone test 1",
                    Sequence = 1,
                    SourcePage = 3,
                    Height = 90,
                    Left = 10,
                    Top = 10,
                    Width = 80,
                    ImageFileFormat = WebServiceDetails.ImageFileFormat,
                    OutputPageNumber = 1
                };

                ImageZone[] test = new ImageZone[1];

                test[0] = imageZone;

                var imageCluster = new ImageCluster {
                    ImageClusterIdentifier = 1,
                    Name = "Page one test",
                    Sequence = 1,
                    ImageZones = test
                };

                ImageCluster[] imageClusters = new ImageCluster[1];
                imageClusters[0] = imageCluster;

                LayoutArguments layoutArguments = new LayoutArguments {
                    BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
                    QuestionPaperIdentifier = "ENGFZ",
                    ImageClusters = imageClusters
                };

                var QuestionpaperLayout = Layout.Layout(WebServiceDetails.RMKey, layoutArguments);
            }
            
            return View("PaperLayout");
        }

        public ActionResult MarkSchemeStructure(string QuestionPaperIdentifier)
        {
            using (AssessmentStructureWS.AssessmentStructureWS MarkScheme = new AssessmentStructureWS.AssessmentStructureWS())
            {
                Characteristic[] characteristic = { new Characteristic
                {
                    Descriptor = "Mark by Annotation"

                } };

                Annotation[] Annotation = { new Annotation
                {
                    Descriptor = "Mark by Annotation"

                } };

                QuestionItemGroup questionItemGroup = new QuestionItemGroup
                {
                    QuestionItemGroupIdentifier = 1001,
                    Name = "Question 1",
                    DefaultGrace = 60,
                    EStandardisationIndicator = false,
                    MarkingApplicationIdentifier = "SCORIS",
                    MarkingCount = 10,
                    MaximumCacheLimit = 20,
                    MaximumConcurrentMarkingLimit = 20,
                    Characteristics = characteristic,
                    Annotations = null,
                    EStandardisationCreationTargets = null,
                    ExceptionTypes = null,
                    SampleRules = null

                 };

                QuestionItemGroup[] questionItemGroups = { questionItemGroup };

                MarkingCluster markingCluster = new MarkingCluster
                {
                    MarkingClusterIdentifier = 3,
                    Name = "Section A",
                    Sequence = 1,
                    ParentMarkingClusterIdentifier = 1001,
                    ReuseRIGSequence = 0
                };

                MarkingCluster[] markingClusters = { markingCluster };


                MarkingItem markingItem = new MarkingItem
                {
                    QuestionNumber = "Question 3",
                    MarkingItemIdentifier = 3,
                    MarkingClusterIdentifier = 3,
                    Sequence = 1,
                    ReuseRIGSequence = 0
                };

                MarkingItem[] markingItems = { markingItem};


                MarkType[] markTypes = {new MarkType
                {
                    MarkTypeIdentifier = 2,
                    Name = "Question 3",
                    NumericIndicator = true
                } };

                MarkScheme1[] markSchemes = {new MarkScheme1
                {
                    MarkSchemeIdentifier = 3,
                    MarkTypeIdentifier = 2,
                    MarkingItemIdentifier = 3,
                    MarkingItemIdentifierSpecified = true,
                    Sequence = 1,
                    WholenumberIndicator = true,
                    ReuseRIGSequence = 0
                } };

                MarkSchemeStructureArguments markSchemeStructureArguments = new MarkSchemeStructureArguments
                {
                    BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
                    QuestionPaperIdentifier = "Comp2 ",
                    QuestionItemGroups = questionItemGroups,
                    MarkingClusters = markingClusters,
                    MarkingItems = markingItems,
                    MarkTypes = markTypes,
                    MarkSchemes = markSchemes
                };



                XmlSerializer xsSubmit = new XmlSerializer(typeof(MarkSchemeStructureArguments));
                XmlDocument xmlDoc = new XmlDocument();
                var subReq = markSchemeStructureArguments;
                var xml = "";

                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        xsSubmit.Serialize(writer, subReq);
                        xml = sww.ToString(); // Your XML
                    }
                }
                using (MemoryStream xmlStream = new MemoryStream())
                {
                    xsSubmit.Serialize(xmlStream, subReq);
                    xmlStream.Position = 0;
                    xmlDoc.Load(xmlStream);
                    var test2 = xmlDoc.InnerXml;
                }

                var pingTest = MarkScheme.Ping();
                ScanningWebWS.rmScanningWebWS rmScanningWebWS = new rmScanningWebWS();
                //var scanningTest = rmScanningWebWS.Ping();

                var MarkSchemeSent = MarkScheme.MarkSchemeStructure(WebServiceDetails.RMKey, markSchemeStructureArguments);
            }

            return View("PaperLayout");
        }

        public PartialViewResult _notification(string SessionIdentifier, string AssessmentIdentifier, int AssessmentVersion, string ComponentIdentifier, int ComponentVersion)
        {
            //AssessmentIdentifier = SubjectCode
            //ComponentIdentifier = Subject Code + Paper number
            var paperNumber = ComponentIdentifier.Last().ToString();

            using (var db = new RM_GDEContext())
            {
                var candidates = db.Candidates.ToList();
                var centers = candidates.Where(c => c.SubjectCode == "LFSCZ" && c.Paper == "1").Select(c => new { c.CentreName, c.MsNo }).Distinct();
                //var centers = candidates.Select(c => new { c.CentreName, c.MsNo }).Distinct();
                
                foreach (var center in centers)
                {
                    using (SessionCompositionWS.SessionCompositionWS sessionComposition = new SessionCompositionWS.SessionCompositionWS())
                    {
                        var numberOfMarkSheets = centers.Where(c => c.MsNo == center.MsNo).Distinct().Count();
                        Packet[] packets = new Packet[numberOfMarkSheets];
                        for(var i = 0; i < numberOfMarkSheets; i++)
                        {
                            Packet packet = new Packet
                            {
                                PacketBarcode = center.MsNo
                            };
                            packets[i] = packet;
                        }
                        

                        PacketArguments packetArguments = new PacketArguments
                        {
                            BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
                            SessionIdentifier = SessionIdentifier,
                            AssessmentIdentifier = AssessmentIdentifier,
                            AssessmentVersion = AssessmentVersion,
                            ComponentIdentifier = ComponentIdentifier,
                            ComponentVersion = ComponentVersion,
                            CentreIdentifier = center.CentreName,
                            Packets = packets
                        };

                        var sendPackets =  sessionComposition.Packets(WebServiceDetails.RMKey, packetArguments);


                        if (sendPackets.Success)
                        {
                            var candidateList = candidates.Where(c => c.CentreName == center.CentreName);

                            //CentreCandidateIdentifier = ExamNumber + Subject code + paper number

                            var numberOfCandidates = candidateList.Count();
                            CandidateEntry[] CandidateEntries = new CandidateEntry[numberOfCandidates];
                            var j = 0;
                            foreach (var candidate in candidateList)
                            {
                                
                                CandidateEntry candidateModel = new CandidateEntry
                                {
                                    UniqueCandidateIdentifier = candidate.Idno,
                                    CentreCandidateIdentifier = candidate.Idno,
                                    CandidateName = candidate.Idno + candidate.SubjectCode + candidate.Paper,
                                    Gender = "N",
                                    DOB = (DateTime)candidate.Dob
                                };
                                CandidateEntries[j] = candidateModel;
                                j++;
                            }
                            //for (var i = 0; i < numberOfCandidates; i++)
                            //{

                            //    CandidateEntry candidateModel = new CandidateEntry
                            //    {
                            //        UniqueCandidateIdentifier = candidateList.
                            //    };
                            //    CandidateEntries[i] = candidateModel;
                            //}

                            CandidateEntriesArguments candidateEntriesArguments = new CandidateEntriesArguments
                            {
                                BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
                                SessionIdentifier = SessionIdentifier,
                                AssessmentIdentifier = AssessmentIdentifier,
                                AssessmentVersion = AssessmentVersion,
                                ComponentIdentifier = ComponentIdentifier,
                                ComponentVersion = ComponentVersion,
                                CentreIdentifier = center.CentreName,
                                CandidateEntries = CandidateEntries
                            };

                            var sendCandidates = sessionComposition.CandidateEntries(WebServiceDetails.RMKey, candidateEntriesArguments);
                        }
                    }

                }
               
            }

            
            return PartialView();
        }

        //public PartialViewResult CandidateEntries(string SessionIdentifier, string AssessmentIdentifier, int AssessmentVersion, string ComponentIdentifier, int ComponentVersion)
        //{
        //    //AssessmentIdentifier = SubjectCode
        //    //ComponentIdentifier = Subject Name + Paper number
        //    using (var db = new RM_GDEContext())
        //    {
        //        var centers = db.Candidates.Where(c => c.SubjectCode == AssessmentIdentifier);

        //        foreach (var center in centers)
        //        {
        //            int i = 0;
        //            using (SessionCompositionWS.SessionCompositionWS sessionComposition = new SessionCompositionWS.SessionCompositionWS())
        //            {
        //                Packet[] packets = new Packet[centers.Where(c => c.MsNo == center.MsNo).Count()];

        //                Packet packet = new Packet
        //                {
        //                    PacketBarcode = center.MsNo
        //                };

        //                packets[i] = packet;

        //                i++;

        //                PacketArguments packetArguments = new PacketArguments
        //                {
        //                    BusinessStreamIdentifier = WebServiceDetails.BusinessStreamIndentifier,
        //                    SessionIdentifier = SessionIdentifier,
        //                    AssessmentIdentifier = AssessmentIdentifier,
        //                    AssessmentVersion = AssessmentVersion,
        //                    ComponentIdentifier = ComponentIdentifier,
        //                    ComponentVersion = ComponentVersion,
        //                    CentreIdentifier = center.CentreName,
        //                    Packets = packets
        //                };

        //                var sendPackets = sessionComposition.Packets(WebServiceDetails.RMKey, packetArguments);
        //            }

        //        }

        //    }


        //    return PartialView();
        //}


        public ActionResult StartFeeds()
        {
            return View();
        }

        public PartialViewResult uploadProcess(string step)
        {

            //using (var giodb = new RM_GDEContext())
            //{
            //  var candidates = giodb.Candidates.ToList();

            //    foreach(var can in candidates)
            //    {
            //        can.PaperDesc
            //    }
              
            //}

            //return candidates;


            using (var db = new RM_GDEContext())
            {
                if (step == "session")
                {
                    var session = db.Session.ToList();

                    return this.PartialView("PartialView/_" + step, session);
                } else if (step == "component")
                {
                    ////var component = db.
                }
            }
           

            return this.PartialView("PartialView/_" + step);
        }

        [HttpPost]
        public void ImportCandidates(HttpPostedFileBase FileUpload1)
        {

            RM_GDEContext rM_GDEContext = new RM_GDEContext();

            StreamReader csvReader = new StreamReader(FileUpload1.InputStream);
            string[] csvValues = null;
            int firstLine = 0;

            while (!csvReader.EndOfStream)
            {
                csvValues = csvReader.ReadLine().Split('#').Where(x => !String.IsNullOrEmpty(x)).ToArray();
                //if (csvValues.Length < 2)
                //{
                //    return this.PartialView("Error");
                //}

                string[] insertToDatabase = csvValues;

                if (firstLine != 0)
                {
                    var candidates = new Candidates
                    {
                        Prov = insertToDatabase[0],
                        ProvName = insertToDatabase[1],
                        Region = insertToDatabase[2],
                        RegName = insertToDatabase[3],
                        District = insertToDatabase[4],
                        DistrName = insertToDatabase[5],
                        Circuit = Convert.ToByte(insertToDatabase[6]),
                        CircName = insertToDatabase[7],
                        Emis = insertToDatabase[8],
                        CentreName = insertToDatabase[9],
                        ExamType = insertToDatabase[10],
                        ExamTypeName = insertToDatabase[11],
                        Grade = insertToDatabase[12],
                        ExamPeriod = insertToDatabase[13],
                        SubjectCode = insertToDatabase[14],
                        SubjectName = insertToDatabase[15],
                        Paper = insertToDatabase[16],
                        PaperDesc = insertToDatabase[17],
                        PaperType = insertToDatabase[18],
                        PaperMax = insertToDatabase[19],
                        PaperDate = DateTime.ParseExact(insertToDatabase[20],"yyyyMMdd",null),
                        PaperTime = insertToDatabase[21],
                        PaperDuration = insertToDatabase[22],
                        MsNo = insertToDatabase[23],
                        Idno = insertToDatabase[24],
                        Candidate = insertToDatabase[25],
                        Dob = DateTime.ParseExact(insertToDatabase[26], "yyyyMMdd", null)
                    };

                    rM_GDEContext.Candidates.Add(candidates);
                    rM_GDEContext.SaveChanges();
                }

                firstLine++;
            }

        }

    }
}