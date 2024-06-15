using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [field: SerializeField] public AreaType Type { get; private set; }
    [SerializeField] private SegmentType[] segmentsSetup;

    public Segment[] Segments { get; private set; }

    private Tile tile;

    public void Init(Tile tile)
    {
        this.tile = tile;

        Segments = new Segment[segmentsSetup.Length];
        for (int i = 0; i < segmentsSetup.Length; i++)
        {
            Segments[i] = tile.Segments[(int)segmentsSetup[i]];
            Segments[i].Init(this);
        }
    }
}
