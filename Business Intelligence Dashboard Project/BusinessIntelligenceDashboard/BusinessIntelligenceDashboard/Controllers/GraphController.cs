using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessIntelligenceDashboard.Models;
using DocuWare.Platform.ServerClient;
using System.Diagnostics;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;

namespace BusinessIntelligenceDashboard.Controllers
{
    //Main Page
    public class GraphController : Controller
    {
        //Drop Down Lists
        public static List<SelectListItem> GroupByDDF = new List<SelectListItem>();
        public static List<SelectListItem> SumDDF = new List<SelectListItem>();
        public static List<SelectListItem> CountDDF = new List<SelectListItem>();
        public static List<List<SelectListItem>> SubDDF = new List<List<SelectListItem>>();
        //All Dashboards
        public static List<Dashboard> Dashboards = new List<Dashboard>();
        public static int GraphCount = 0;
        public enum graph { Line = 0, Vbar = 4, Hbar = 5, Pie = 6 };
        //Non-null Decimal and String Fields in File Cabinet
        public static List<string> DecimalFieldsL = new List<string>();                     //FieldLabels
        public static List<string> StringFieldsL = new List<string>();                      //FieldLabels
        public static List<string> DecimalFieldsN = new List<string>();                     //FieldNames
        public static List<string> StringFieldsN = new List<string>();                      //FieldNames
        //All String Fields Distinct Values
        public static List<List<string>> DistinctValues = new List<List<string>>();

        //Pre-Page Load up Code - Build Drop Down Lists for Form
        public ActionResult Load()
        {
            //Get User Session Object
            var u = Session["User"] as UserModel;

            //Connecting with user credentials
            if (Models.Session.Connect(u.username, u.password, u.organization))
            {
                //For Getting all Non-null String Fields and all Distinct Values in File Cabinet
                List<string> allValues = new List<string>();
                List<string> parallelFieldList = new List<string>();

                //Connection
                ServiceConnection conn = ServiceConnection.Create(Models.Session.uri, u.username, u.password, u.organization);
                //To run DialogExpressions with User Organization and File Cabinet
                var org = conn.Organizations[0];
                var fileCabinets = org.GetFileCabinetsFromFilecabinetsRelation().FileCabinet;
                var fc = fileCabinets[0];

                //Get all documents and get all fields and distinct values for dropdown lists
                DocumentsQueryResult all = conn.GetFromDocumentsForDocumentsQueryResultAsync(
                    fc.Id,
                    count: 1000).Result;
                foreach (var doc in all.Items)
                {
                    List<DocumentIndexField> fe = doc.Fields.ToList();
                    foreach (DocumentIndexField dif in fe)
                    {
                        //Extrating Non-system Feilds
                        if (dif.FieldName.ToString().Substring(0, 2) != "DW")
                        {
                            //Getting all String Field Types for "Group By:" and "Count" Drop Down List
                            if (dif.Item != null && dif.Item.GetType() == typeof(string))
                            {
                                parallelFieldList.Add(dif.FieldLabel);
                                allValues.Add(dif.Item.ToString());

                                StringFieldsL.Add(dif.FieldLabel);
                                StringFieldsN.Add(dif.FieldName);
                            }
                            //Getting all Decimal Field Types for "Sum" and "Count" Drop Down List
                            else if (dif.Item != null && (dif.Item.GetType() == typeof(int) || dif.Item.GetType() == typeof(decimal)))
                            {
                                DecimalFieldsL.Add(dif.FieldLabel);
                                DecimalFieldsN.Add(dif.FieldName);
                            }
                        }
                    }
                }
                StringFieldsL = StringFieldsL.Distinct().ToList();
                StringFieldsN = StringFieldsN.Distinct().ToList();
                DecimalFieldsL = DecimalFieldsL.Distinct().ToList();
                DecimalFieldsN = DecimalFieldsN.Distinct().ToList();
                int x = 0;
                //Organize all String Field values by Field and get only distinct values
                foreach (string s in StringFieldsL)
                {
                    List<string> temp = new List<string>();
                    foreach (string ss in parallelFieldList)
                    {
                        if (parallelFieldList[x] == s)
                        {
                            temp.Add(allValues[x]);
                        }
                        ++x;
                    }
                    temp = temp.Distinct().ToList();
                    temp.Sort();
                    DistinctValues.Add(temp);
                    x = 0;
                }
                //Making Drop Down List for "Count" Selection - (String Fields)
                x = 0;
                foreach (string s in StringFieldsL)
                {
                    CountDDF.Add(new SelectListItem
                    {
                        Text = s,
                        Value = StringFieldsN[x]
                    });
                    ++x;
                }
                //"Group By" Drop Down Same as "Count" Option List
                GroupByDDF = CountDDF;
                //Making Drop Down List for "Sum" Selection - (Decimal Fields)
                x = 0;
                foreach (string s in DecimalFieldsL)
                {
                    SumDDF.Add(new SelectListItem
                    {
                        Text = s,
                        Value = DecimalFieldsN[x]
                    });
                    ++x;
                }
                //Making Drop Down List for Field Values
                foreach (List<string> sl in DistinctValues)
                {
                    List<SelectListItem> temp = new List<SelectListItem>();
                    temp.Add(new SelectListItem
                    {
                        Text = "Non-specific",
                        Value = "NONE"
                    });
                    foreach (string ss in sl)
                    {
                        temp.Add(new SelectListItem
                        {
                            Text = ss,
                            Value = ss
                        });
                    }
                    SubDDF.Add(temp);
                }
            }
            return RedirectToAction("Main", "Graph");
        }
        //Main Page View
        public ActionResult Main()
        {
            //For Displaying Drop Down Lists and Graphs
            ViewBag.GBDDF = GroupByDDF;
            ViewBag.SDDF = SumDDF;
            ViewBag.CDDF = CountDDF;
            ViewBag.SUBDDF = SubDDF;
            ViewBag.Dashboards = Dashboards;
            return View();
        }
        [HttpPost]
        public ActionResult Main(GraphModel g)
        {
            //To Keep Drop Down Lists
            ViewBag.GBDDF = GroupByDDF;
            ViewBag.SDDF = SumDDF;
            ViewBag.CDDF = CountDDF;
            ViewBag.SUBDDF = SubDDF;

            CreateGraph(g);

            ViewBag.Dashboards = Dashboards;

            return View();
        }
        void CreateGraph(GraphModel g)
        {
            var u = Session["User"] as UserModel;
            ServiceConnection conn = ServiceConnection.Create(Models.Session.uri, u.username, u.password, u.organization);

            List<DateTime> DateBins = new List<DateTime>();             //Dates Bins for Grouping Graph Data
            List<string> gbNameList = new List<string>();               //List of Distinct Values in gbName Field
            List<object[]> values = new List<object[]>();               //Data for Graph

            string[] GraphDates = null;                                 //Dates to Display on Graph
            string graphTitle = null;                                   //Graph Title
            string gsubTitle1 = null;
            string gsubTitle2 = null;

            //To run DialogExpressions with User Organization and File Cabinet
            var org = conn.Organizations[0];
            var fileCabinets = org.GetFileCabinetsFromFilecabinetsRelation().FileCabinet;
            var fc = fileCabinets[0];
            var dialogInfoItems = fc.GetDialogInfosFromSearchesRelation();

            //Distinct Values Drop Down List Values
            string sofield = g.cSubField[StringFieldsN.IndexOf(g.cField)];
            string sgbName = g.gbSubField[StringFieldsN.IndexOf(g.gbField)];

            //Check for Specific "Group By:" Field Value
            if (sgbName == "NONE")
            {
                //Get Distinct *Group By:* Field
                gbNameList = DistinctValues[StringFieldsN.IndexOf(g.gbField)];
                gsubTitle2 = string.Concat(" by ", StringFieldsL[StringFieldsN.IndexOf(g.gbField)]);
            }
            else
            {
                gbNameList.Add(sgbName);
                gsubTitle2 = string.Concat(" by ", StringFieldsL[StringFieldsN.IndexOf(g.gbField)], " ", sgbName);
            }

            //If No Date Range - Get the Oldest and Newest Document
            if (g.range == 0)
            {
                g.startDate = DateTime.MaxValue;
                g.endDate = DateTime.MinValue;

                //Get Oldest Document for Each gbNameList - To set startDate  *Update Code before 1/1/2999*
                foreach (string s in gbNameList)
                {
                    var oldest = new DialogExpression()
                    {
                        Condition = new List<DialogExpressionCondition>()
                        {
                            DialogExpressionCondition.Create("DATE", "1/1/1900" ,"1/1/2999"),
                            DialogExpressionCondition.Create(g.gbField, s)
                        },
                        Count = 1,
                        SortOrder = new List<SortedField>
                        {
                            SortedField.Create("DATE", SortDirection.Asc)
                        },
                    };
                    var dialog = dialogInfoItems.Dialog[0].GetDialogFromSelfRelation();
                    var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(oldest);
                    var odoc = queryResult.Items[0];
                    List<DocumentIndexField> dif = new List<DocumentIndexField>();
                    dif = odoc.Fields.ToList();
                    foreach (DocumentIndexField d in dif)
                    {
                        if (d.FieldName == "DATE")
                        {
                            if ((DateTime)d.Item < g.startDate)
                                g.startDate = (DateTime)d.Item;
                        }
                    }
                }
                //Get Newest Document for Each gbNameList - To set endDate
                foreach (string s in gbNameList)
                {
                    var newest = new DialogExpression()
                    {
                        Condition = new List<DialogExpressionCondition>()
                        {
                            DialogExpressionCondition.Create("DATE", "1/1/1900" ,"1/1/2999"),
                            DialogExpressionCondition.Create(g.gbField, s)
                        },
                        Count = 1,
                        SortOrder = new List<SortedField>
                        {
                        SortedField.Create("DATE", SortDirection.Desc)
                        }
                    };
                    var dialog = dialogInfoItems.Dialog[0].GetDialogFromSelfRelation();
                    var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(newest);
                    var ndoc = queryResult.Items[0];
                    List<DocumentIndexField> dif2 = new List<DocumentIndexField>();
                    dif2 = ndoc.Fields.ToList();
                    foreach (DocumentIndexField d in dif2)
                    {
                        if (d.FieldName == "DATE")
                        {
                            if ((DateTime)d.Item > g.endDate)
                                g.endDate = (DateTime)d.Item;
                        }
                    }
                }
            }
            // Date Bin Creation and Getting Data for Graph (Line | Vbar | Hbar)
            if ((g.gType == (int)graph.Line) || (g.gType == (int)graph.Vbar) || (g.gType == (int)graph.Hbar))
            {
                //Get Time Interval - Make Date Bins based on startDate, endDate, and timeInt
                if (g.timeInt == 0)                                          //None
                {
                    //No Dates to display for graph - Legend shows each series
                    GraphDates = new string[1] { StringFieldsL[StringFieldsN.IndexOf(g.gbField)] };
                    DateBins.Add(g.endDate);
                }
                else if (g.timeInt == 1)                                    //Monthly
                {
                    DateTime newDate = new DateTime(g.startDate.Year, g.startDate.Month,
                                                    DateTime.DaysInMonth(g.startDate.Year, g.startDate.Month));
                    DateBins.Add(newDate);
                    Debug.WriteLine(newDate);
                    for (;;)
                    {
                        newDate = newDate.AddMonths(1);
                        newDate = newDate.AddDays(DateTime.DaysInMonth(newDate.Year, newDate.Month) - newDate.Day);
                        DateBins.Add(newDate);
                        Debug.WriteLine(newDate);
                        if (newDate >= g.endDate) break;
                    }
                    //Creating Dates to Display for Graph
                    GraphDates = new string[DateBins.Count];
                    int y = 0;
                    foreach (DateTime d in DateBins)
                    {
                        GraphDates[y] = String.Format("{0}/{1}", d.Month, d.Year);
                        ++y;
                    }
                }
                else if (g.timeInt == 2)                                    //Yearly
                {
                    DateTime newDate = new DateTime(g.startDate.Year, 12, 31);
                    DateBins.Add(newDate);
                    Debug.WriteLine(newDate);
                    for (;;)
                    {
                        newDate = newDate.AddYears(1);
                        if (newDate.Year > g.endDate.Year) break;
                        DateBins.Add(newDate);
                        Debug.WriteLine(newDate);
                    }
                    //Creating Dates to Display for Graph
                    GraphDates = new string[DateBins.Count];
                    int y = 0;
                    foreach (DateTime d in DateBins)
                    {
                        GraphDates[y] = d.Year.ToString();
                        ++y;
                    }
                }
                //Get Values of Selected Field for all *Group By:* Field
                if (g.amount == 1)                                          //Sum
                {
                    foreach (string s in gbNameList)
                    {
                        int sum = 0;
                        int value = 0;
                        int dateindex = 0;
                        int remaining = 0;
                        List<object> v = new List<object>();
                        DateTime checkDate = g.startDate;
                        DialogExpression gbDocs;
                        if (sofield == "NONE")
                        {
                            gsubTitle1 = string.Concat("Sum of ", DecimalFieldsL[DecimalFieldsN.IndexOf(g.sField)],
                                                        " for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)]);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                                {
                                    DialogExpressionCondition.Create(g.gbField, s),
                                    DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                                },
                                SortOrder = new List<SortedField>
                                {
                                    SortedField.Create("DATE", SortDirection.Asc)
                                },
                                Count = 1000
                            };
                        }
                        else
                        {
                            gsubTitle1 = string.Concat("Sum of ", DecimalFieldsL[DecimalFieldsN.IndexOf(g.sField)],
                                                        " for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)], " ",
                                                        sofield);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                                {
                                    DialogExpressionCondition.Create(g.cField, sofield),
                                    DialogExpressionCondition.Create(g.gbField, s),
                                    DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                                },
                                SortOrder = new List<SortedField>
                                {
                                    SortedField.Create("DATE", SortDirection.Asc)
                                },
                                Count = 1000
                            };
                        }
                        var dialog = dialogInfoItems.Dialog[2].GetDialogFromSelfRelation();
                        var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(gbDocs);
                        //For Each Document in Dialog Query Result
                        foreach (var d in queryResult.Items)
                        {
                            List<DocumentIndexField> dif = new List<DocumentIndexField>();
                            dif = d.Fields.ToList();
                            //For Each Field in Document
                            foreach (DocumentIndexField di in dif)
                            {
                                if (di.FieldName == g.sField)
                                {
                                    value = Convert.ToInt32(di.Item);
                                }
                                if (di.FieldName == "DATE")
                                {
                                    checkDate = (DateTime)di.Item;
                                }
                            }
                            //Check Date
                            if (checkDate <= DateBins[dateindex])
                            {
                                sum += value;
                            }
                            else if (checkDate > DateBins[dateindex])
                            {
                                v.Add((object)sum);
                                sum = 0;
                                for (;;)
                                {
                                    ++dateindex;
                                    if ((dateindex > (DateBins.Count - 1)) || checkDate < DateBins[dateindex])
                                    {
                                        sum = value;
                                        break;
                                    }
                                    v.Add((object)0);
                                }
                            }
                        }
                        v.Add((object)sum);
                        remaining = DateBins.Count - (dateindex + 1);
                        for (int x = 0; x < remaining; ++x)
                        {
                            v.Add((object)0);
                        }
                        values.Add(v.ToArray());
                    }
                }
                else if (g.amount == 2)                                     //Count
                {
                    foreach (string s in gbNameList)
                    {
                        int dateindex = 0;
                        int count = 0;
                        List<object> v = new List<object>();
                        DateTime checkDate1 = g.startDate;
                        DateTime checkDate2 = DateBins[dateindex];
                        for (;;)
                        {
                            DialogExpression gbDocs;
                            if (sofield == "NONE")
                            {
                                gsubTitle1 = string.Concat("Count for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)]);
                                gbDocs = new DialogExpression()
                                {
                                    Condition = new List<DialogExpressionCondition>()
                                {
                                    DialogExpressionCondition.Create(g.gbField, s),
                                    DialogExpressionCondition.Create("DATE", checkDate1.ToShortDateString(), checkDate2.ToShortDateString())
                                },
                                    SortOrder = new List<SortedField>
                                {
                                    SortedField.Create("DATE", SortDirection.Asc)
                                },
                                    Count = 1000
                                };
                            }
                            else
                            {
                                gsubTitle1 = string.Concat("Count for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)], " ", sofield);
                                gbDocs = new DialogExpression()
                                {
                                    Condition = new List<DialogExpressionCondition>()
                                {
                                    DialogExpressionCondition.Create(g.cField, sofield),
                                    DialogExpressionCondition.Create(g.gbField, s),
                                    DialogExpressionCondition.Create("DATE", checkDate1.ToShortDateString(), checkDate2.ToShortDateString())
                                },
                                    SortOrder = new List<SortedField>
                                {
                                    SortedField.Create("DATE", SortDirection.Asc)
                                },
                                    Count = 1000
                                };
                            }
                            var dialog = dialogInfoItems.Dialog[1].GetDialogFromSelfRelation();
                            var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(gbDocs);
                            count = queryResult.Count.Value;
                            v.Add((object)count);
                            checkDate1 = DateBins[dateindex];
                            checkDate1 = checkDate1.AddDays(1);
                            ++dateindex;
                            if (dateindex > (DateBins.Count - 1)) break;
                            checkDate2 = DateBins[dateindex];
                            if (checkDate2 > g.endDate)
                                checkDate2 = g.endDate;
                        }
                        values.Add(v.ToArray());
                    }
                }
            }
            //Getting Data for Graph (Pie)
            else if (g.gType == (int)graph.Pie)
            {
                //Get Values of Selected Field for all *Group By:* Field
                if (g.amount == 1)                                          //Sum
                {
                    foreach (string s in gbNameList)
                    {
                        int sum = 0;
                        int value = 0;
                        DialogExpression gbDocs;
                        if (sofield == "NONE")
                        {
                            gsubTitle1 = string.Concat("Sum of ", DecimalFieldsL[DecimalFieldsN.IndexOf(g.sField)],
                                                        " for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)]);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                            {
                                DialogExpressionCondition.Create(g.gbField, s),
                                DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            },
                                Count = 1000
                            };
                        }
                        else
                        {
                            gsubTitle1 = string.Concat("Sum of ", DecimalFieldsL[DecimalFieldsN.IndexOf(g.sField)],
                                                        " for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)], " ",
                                                        sofield);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                            {
                                DialogExpressionCondition.Create(g.cField, sofield),
                                DialogExpressionCondition.Create(g.gbField, s),
                                DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            },
                                Count = 1000
                            };
                        }
                        var dialog = dialogInfoItems.Dialog[2].GetDialogFromSelfRelation();
                        var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(gbDocs);
                        //For Each Document in Dialog Query Result
                        foreach (var d in queryResult.Items)
                        {
                            List<DocumentIndexField> dif = new List<DocumentIndexField>();
                            dif = d.Fields.ToList();
                            //For Each Field in Document
                            foreach (DocumentIndexField di in dif)
                            {
                                if (di.FieldName == g.sField)
                                {
                                    value = Convert.ToInt32(di.Item);
                                    sum += value;
                                }
                            }
                        }
                        values.Add(new object[] { s, sum });
                    }
                }
                else if (g.amount == 2)                                     //Count
                {
                    foreach (string s in gbNameList)
                    {
                        int count = 0;
                        DialogExpression gbDocs;
                        if (sofield == "NONE")
                        {
                            gsubTitle1 = string.Concat("Count for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)]);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                            {
                                DialogExpressionCondition.Create(g.gbField, s),
                                DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            },
                                Count = 1000
                            };
                        }
                        else
                        {
                            gsubTitle1 = string.Concat("Count for ", StringFieldsL[StringFieldsN.IndexOf(g.cField)], " ", sofield);
                            gbDocs = new DialogExpression()
                            {
                                Condition = new List<DialogExpressionCondition>()
                            {
                                DialogExpressionCondition.Create(g.cField, sofield),
                                DialogExpressionCondition.Create(g.gbField, s),
                                DialogExpressionCondition.Create("DATE", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            },
                                Count = 1000
                            };
                        }
                        var dialog = dialogInfoItems.Dialog[1].GetDialogFromSelfRelation();
                        var queryResult = dialog.Query.PostToDialogExpressionRelationForDocumentsQueryResult(gbDocs);
                        count = queryResult.Count.Value;
                        values.Add(new object[] { s, count });
                    }
                }
            }
            graphTitle = string.Concat(gsubTitle1, gsubTitle2);

            Highcharts chart = null;
            //Create Graph
            if ((g.gType == (int)graph.Line) || (g.gType == (int)graph.Vbar) || (g.gType == (int)graph.Hbar))
            {
                ++GraphCount;
                //Creating Series for graphs
                Series[] chartVals = new Series[gbNameList.Count];
                int r = 0;
                foreach (string n in gbNameList)
                {
                    chartVals[r] = new Series
                    {
                        Name = n,
                        Type = (ChartTypes)g.gType,
                        Data = new Data(values[r])
                    };
                    ++r;
                }

                chart = new Highcharts(string.Format("chart{0}", GraphCount))
                            .SetTitle(new Title
                            {
                                Text = graphTitle
                            })
                            .SetSubtitle(new Subtitle
                            {
                                Text = string.Format("Data From: {0} - {1}", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            })
                            .SetXAxis(new XAxis
                            {
                                Categories = GraphDates
                            })
                            .SetSeries
                            (
                                chartVals
                            );
            }
            else if (g.gType == (int)graph.Pie)
            {
                ++GraphCount;
                chart = new Highcharts(string.Format("chart{0}", GraphCount))
                             .SetTitle(new Title
                             {
                                 Text = graphTitle
                             })
                            .SetSubtitle(new Subtitle
                            {
                                Text = string.Format("Data From: {0} - {1}", g.startDate.ToShortDateString(), g.endDate.ToShortDateString())
                            })
                            .SetSeries(new Series
                            {
                                Type = ChartTypes.Pie,
                                Name = "Amount",
                                Data = new Data(values.ToArray())
                            }
                            );
            }
            //Add Graph to proper Dashboard
            foreach (Dashboard d in Dashboards)
            {
                if (d.name == g.DashID && d.charts != null)
                {
                    d.charts.Add(chart);
                    d.active = true;
                    d.cObjects.Add(g);
                }
                else if (d.name == g.DashID && d.charts == null)
                {
                    d.charts = new List<Highcharts>();
                    d.charts.Add(chart);
                    d.cObjects = new List<GraphModel>();
                    d.cObjects.Add(g);
                    d.active = true;
                }
                else d.active = false;
            }

            return;
        }
        //Add a Dashboard
        public ActionResult NewDash(string dashboardname)
        {
            foreach (var dash in Dashboards) dash.active = false;
            Dashboard d = new Dashboard();
            d.name = dashboardname;
            d.charts = null;
            d.active = true;
            Dashboards.Add(d);
            return RedirectToAction("Main", "Graph");
        }
        //Duplicate a Dashboard
        public ActionResult Duplicate(string dashboardname, string newName)
        {
            foreach (var d in Dashboards)
            {
                if (d.name == dashboardname)
                {
                    Dashboard dash = new Dashboard();
                    dash.name = newName;
                    Dashboards.Add(dash);
                    if (d.cObjects != null)
                    { 
                        foreach (var g in d.cObjects)
                        {
                            g.DashID = newName;
                            CreateGraph(g);
                        }
                    }
                    dash.active = true;
                    d.active = false;
                    break;
                }
                else d.active = false;
            }

            return RedirectToAction("Main", "Graph");
        }
        //Delete a Graph Function
        public ActionResult DeleteGraph(string dashboardname, int id)
        {
            foreach(var d in Dashboards)
            {
                if (d.name == dashboardname)
                {
                    d.charts.RemoveAt(id);
                    break;
                }
            }
            return RedirectToAction("Main", "Graph");
        }
        //Delete a Dashboard Function
        public ActionResult DeleteDash(string dashboardname)
        {
            foreach (var d in Dashboards)
            {
                if (d.name == dashboardname)
                {
                    Dashboards.Remove(d);
                    break;
                }
            }
            return RedirectToAction("Main", "Graph");
        }
        //LogOut Function
        public ActionResult LogOut()
        {
            //Clear all Global Variabels
            GroupByDDF = new List<SelectListItem>();
            SumDDF = new List<SelectListItem>();
            CountDDF = new List<SelectListItem>();
            SubDDF = new List<List<SelectListItem>>();
            Dashboards = new List<Dashboard>();
            GraphCount = 0;
            DecimalFieldsL = new List<string>();
            StringFieldsL = new List<string>();
            DecimalFieldsN = new List<string>();
            StringFieldsN = new List<string>();
            DistinctValues = new List<List<string>>();
            Session["User"] = null;

            return RedirectToAction("Login", "Login");
        }
    }
}