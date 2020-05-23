using System;

public class Professional : User
{

    private list<string> professionalSubjects;

    private double score;

    private int numOfRating;

	public Professional(list<string> professionalSubjects, double score, int numOfRating)
	{
        User();
        this.NumOfRating = numOfRating;
        this.ProfessionalSubjects = professionalSubjects;
        this.Score = score;

    }

    #region
    public list<string> ProfessionalSubjects { get => professionalSubjects; set => professionalSubjects = value; }
    public double Score { get => score; set => score = value; }
    public int NumOfRating { get => numOfRating; set => numOfRating = value; }
    #endregion
}
