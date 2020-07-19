using System;
using System.Collections.Generic;

namespace WebApplicationProject_sucks.Model
{
    public class Professional : User
    {

        public List<string> ProfessionalSubjects { get; set; }

        public double Score { get; set; }

        public Professional(List<string> professionalSubjects, double score, int numOfRating, string userName, string firstName, string gender, DateTime birthDay, List<string> intrest, string email, string password) : base(userName, firstName, gender, birthDay, intrest, email, password)
        { 
            this.ProfessionalSubjects = professionalSubjects;
            this.Score = score;

        }
    }
}