namespace CameraBazaar.Data.Models
{
    using System;

    [Flags]
    public enum LightMetering
    {
        Spot = 0,
        CenterWeighted = 1,
        Evaluative = 2
    }
}
