using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Area[] Areas { get; private set; }
    public Segment[] Segments { get; private set; }

    private void Awake()
    {
        Segments = new Segment[12];
        for (int i = 0; i < Segments.Length; i++)
        {
            Segments[i] = new Segment();
        }

        Areas = GetComponentsInChildren<Area>();
        for (int i = 0; i < Areas.Length; i++)
        {
            Areas[i].Init(this);
        }
    }

    public AreaType GetAreaType(SegmentType segmentType)
    {
        return Segments[(int)segmentType].AssignedArea.Type;
    }

    public void Place(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void MoveTo(float x, float y)
    {
        X = Mathf.RoundToInt(x);
        Y = Mathf.RoundToInt(y);
        transform.position = new Vector3(x, 0, y);
    }
}
