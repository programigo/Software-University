public interface ICar
{
    string Model { get; }
    string Driver { get; }

    string UseBreaks();
    string PushThGas();
}