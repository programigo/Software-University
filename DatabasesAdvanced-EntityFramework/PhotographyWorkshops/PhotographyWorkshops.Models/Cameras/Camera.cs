using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

public class Camera
{
    public int Id { get; set; }

    [Required]
    public string Make { get; set; }

    [Required]
    public string Model { get; set; }

    public string CameraType { get; set; }

    public bool IsFullFrameOrNot { get; set; }

    [Required, Range(100, Int32.MaxValue)]
    public int MinIso { get; set; }

    public int MaxIso { get; set; }

    public int MaxShutterSpeed { get; set; }

    public virtual Photographer Photographer { get; set; }
}
