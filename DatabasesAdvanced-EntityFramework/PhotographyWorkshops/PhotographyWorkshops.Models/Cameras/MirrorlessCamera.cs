﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class MirrorlessCamera : Camera
{
    public string MaxVideoResolution  { get; set; }
    public int MaxFrameRate  { get; set; }
}
