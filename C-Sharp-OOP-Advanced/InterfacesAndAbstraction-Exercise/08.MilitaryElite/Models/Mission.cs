using System.Text;

public class Mission : IMission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; private set; }

    public string State
    {
        get { return this.state; }
        private set { this.state = value; }
    }

    public void CompleteMission()
    {
        this.State = "Finished";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");

        return sb.ToString().Trim();
    }
}