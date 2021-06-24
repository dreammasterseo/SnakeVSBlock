using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplate;
    
    public List<Segment> Generation(int count)
    {
        List<Segment> tile = new List<Segment>();
        for (int i = 0; i < count; i++)
        {
            tile.Add(Instantiate(_segmentTemplate,transform));
        }
        return tile;
    }
}
