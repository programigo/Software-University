public abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier
{
    private string corps;

    protected SpecialisedSoldier(int id, string firstName, string lastName, string corps) : base(id, firstName, lastName)
    {
        this.Corps = corps;
    }

    public string Corps
    {
        get { return this.corps; }
        private set { this.corps = value; }
    }

    public double Salary { get; }
}