using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment
{
    public Area AssignedArea { get; private set; }

    public void Init(Area area)
    {
        AssignedArea = area;
    }
}
