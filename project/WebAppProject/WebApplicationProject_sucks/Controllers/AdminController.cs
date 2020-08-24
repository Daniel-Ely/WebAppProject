using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
    
        public ActionResult ConfirmPendings(IEnumerable<string> acceptedPendings)
        {
            MyDB db = new MyDB();
            if (acceptedPendings != null)
            {
                for (int i = 0; i < acceptedPendings.Count(); i++)
                {
                    var userName = acceptedPendings.ElementAt(i);
                    var user = db.Users.Find(userName);
                    var pendingDetails = db.ProfessionalPendings.Find(userName);
                    if (user != null)
                    {
                        user.isProfessional = true;//tick in the user part
                        Professional professional = new Professional();
                        professional.UserName = userName;
                        professional.Profession_Name = pendingDetails.Profession_Name;
                        professional.Description = pendingDetails.Description;


                        foreach (var pendingCategory in db.PendingToCategories)
                        {
                            ProfessionalToCategory acceptedCategory = new ProfessionalToCategory(userName, pendingCategory.CategoryName);
                            db.ProfessionalToCategories.Add(acceptedCategory);
                            db.PendingToCategories.Remove(pendingCategory);
                        }
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

        public FileContentResult GetApplyFile(string PendingName,int FileNum)
        {
            MyDB db = new MyDB();
            var file=db.PendingFiles.Where(d => d.P_UserName == PendingName && d.FileID == FileNum).ToList().ElementAt(0);
            return File(file.FileContent,".docx");
        }
    }

}