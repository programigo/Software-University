namespace MassDefect.Data
{
    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public virtual IDbSet<Anomalies> Anomalies { get; set; }

        public virtual IDbSet<Persons> Persons { get; set; }

        public virtual IDbSet<Planets> Planets { get; set; }

        public virtual IDbSet<Stars> Stars { get; set; }

        public virtual IDbSet<SolarSystems> SolarSystems { get; set; }
    }
}