using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthChangeEvent : EventArgs
{
    public int Health { get; set; }
}
