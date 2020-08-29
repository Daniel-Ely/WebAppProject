using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks.Controllers
{

    public class AdminController : Controller
    {
        //we use an empty controller to match and load views
        //the controller is EMPTY since we dont need reflexive CRUD actions for this model.
        //(CRUD actions for Admin are done hard-codedly)
  
        public ActionResult AdminStatistics()
        {         
            return View();
        }    

        public ActionResult myGragh()
        {

            return View();
        }
        public ActionResult Map()
        {

            return View();
        }
        
        public ActionResult ConfirmPendings(IEnumerable<string> Pendings)
        {
            MyDB db = new MyDB();
            if (Pendings != null)
            {
                for (int i = 0; i < Pendings.Count(); i++)
                {
                    var userName = Pendings.ElementAt(i);
                    var user = db.Users.Find(userName);
                    var pendingDetails = db.ProfessionalPendings.Find(userName);
                    if (user != null)
                    {
                        user.isProfessional = true;//tick in the user part
                        Professional professional = new Professional();
                        professional.UserName = userName;
                        professional.Profession_Name = pendingDetails.Profession_Name;
                        professional.Description = pendingDetails.Description;
                        
                        //only the associated pending categories!
                        foreach (var pendingCategory in pendingDetails.ProfessionalCategories)
                        {
                            ProfessionalToCategory acceptedCategory = new ProfessionalToCategory(userName, pendingCategory.CategoryName);
                            db.ProfessionalToCategories.Add(acceptedCategory);                          
                        }
                  
                        pendingDetails.ProfessionalCategories.Clear();
                        pendingDetails.ApplyFiles.Clear();

                        professional.Score = 0;
                        //after getting all the necessary data and removing relationships connections, lets remove 
                        //the entry in the pendingProfessional!
                        db.ProfessionalPendings.Remove(pendingDetails);
                        //lets add a new entry for the brand new professional user
                        db.Professionals.Add(professional);
                        db.SaveChanges();

                    }
                }
            }
            return View();
        }

        public ActionResult DisposePending(string PendingName)
        {
            MyDB db = new MyDB();
               
                    var user = db.Users.Find(PendingName);
                    var pendingDetails = db.ProfessionalPendings.Find(PendingName);

                    if (user != null)
                    {                                
                    pendingDetails.ProfessionalCategories.Clear();
                    pendingDetails.ApplyFiles.Clear();

                        //after removing relationships connections, lets remove 
                        //the entry in the pendingProfessional!
                        db.ProfessionalPendings.Remove(pendingDetails);                     
                        db.SaveChanges();
                    }
                          
            return View("../Admin/ConfirmPendings");
        }

        public FileContentResult GetApplyFile(string PendingName,int FileNum)
        {//TODO: restrict the files uploading to .pdf only
            MyDB db = new MyDB();
            var file=db.PendingFiles.Where(d => d.P_UserName == PendingName && d.FileID == FileNum).ToList().ElementAt(0);
            return File(file.FileContent,".pdf");
        }
    }

}