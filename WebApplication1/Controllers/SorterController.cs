using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SorterController : Controller
    {
        // GET: Sorter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProceedFile()
        {
            string path = @"C:\Users\user\Desktop\unsorted-names-list.txt";

            try
            {
                List<string> collection = new List<string>();
                List<string> result = new List<string>();

                string[] readText = System.IO.File.ReadAllLines(path);
                
                foreach (var text in readText)
                {
                    collection.Add(text);
                }
                
                collection.Sort();

                foreach (var item in collection)
                {
                    result.Add(item);
                }
            
                TextWriter file = new StreamWriter(@"C:\Users\user\Desktop\sorted-names-list.txt", true);
                foreach (var txt in collection)
                {
                    file.WriteLine(txt);
                }
             
                file.Close();

                return Json(new { Status = "True", Result = result }, JsonRequestBehavior.AllowGet);
            }
            catch (System.IO.FileNotFoundException ex)
            {
               
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetResult(SorterModel model)
        {
         
            try
            {
                if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "test"))
                    System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "test");

                TextWriter file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"test\result.txt", true);
                file.WriteLine("Result");
                file.WriteLine("Time : " + DateTime.Now.ToString("dd-MMMM-yyyy HH:mm:ss"));
                file.Close();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }
    }
}