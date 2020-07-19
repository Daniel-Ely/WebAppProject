using System;
using System.Collections.Generic;
using WebApplicationProject_sucks.WebApplicationProject_sucks;

namespace WebApplicationProject_sucks
{
    public class Professional : User
    {

        public List<string> ProfessionalSubjects { get; set; }
        //set by the avg of the posts rates
        public double Score { get; set; }

        public Professional(List<string> professionalSubjects, double score, int numOfRating, string userName, string firstName, string gender, DateTime birthDay, List<string> intrest, string email, string password) : base(userName, firstName, gender, birthDay, intrest, email, password)
        {

            this.ProfessionalSubjects = professionalSubjects;
            this.Score = score;

        }
    }
}