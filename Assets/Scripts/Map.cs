using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private Vector3 mapPivot;
    [SerializeField] private Vector3 tileSize;

    public static Tile[,] Tiles { get; private set; }
    public static Player CurrentPlayer { get; private set; }

    private static Vector3 s_mapPivot;
    private static Vector3 s_tileSize;

    private static TilesStack tilesStack;

    private void Awake()
    {
        s_mapPivot = mapPivot;
        s_tileSize = tileSize;

        Tiles = new Tile[width, height]; 

        tilesStack = FindObjectOfType<TilesStack>();

        CurrentPlayer = FindObjectOfType<Player>(true);
        CurrentPlayer.gameObject.SetActive(true);
    }

    public static Tile GetTileFromStack()
    {
        CurrentPlayer.GetTileToHand(tile);
    }

    public static void PlaceTile(int x, int y, Tile tile)
    {
        Tiles[x, y] = tile;
        tile.Place(x, y);
        tile.transform.position = s_mapPivot + new Vector3(x * s_tileSize.x, 0, y * s_tileSize.y);
    }

    public static bool CanPlace(int x, int y, Tile tile)
    {
        Tile topTile = TopTileOf(x, y);
        if(topTile != null)
        {
            if(topTile.GetAreaType(SegmentType.BottomLeft) != tile.GetAreaType(SegmentType.TopLelft))
                return false;

            if(topTile.GetAreaType(SegmentType.BottomMiddle) != tile.GetAreaType(SegmentType.TopMiddle))
                return false;

            if(topTile.GetAreaType(SegmentType.BottomRight) != tile.GetAreaType(SegmentType.TopRight))
                return false;
        }

        Tile rightTile = RightTileOf(x, y);
        if(rightTile != null)
        {
            if(rightTile.GetAreaType(SegmentType.LeftTop) != tile.GetAreaType(SegmentType.RightTop))
                return false;

            if(rightTile.GetAreaType(SegmentType.LeftMiddle) != tile.GetAreaType(SegmentType.RightMiddle))
                return false;

            if(rightTile.GetAreaType(SegmentType.LeftBottom) != tile.GetAreaType(SegmentType.RightBottom))
                return false;
        }

        Tile bottomTile = BottomTileOf(x, y);
        if(bottomTile != null)
        {
            if(bottomTile.GetAreaType(SegmentType.TopLelft) != tile.GetAreaType(SegmentType.BottomLeft))
                return false;

            if(bottomTile.GetAreaType(SegmentType.TopMiddle) != tile.GetAreaType(SegmentType.BottomMiddle))
                return false;

            if(bottomTile.GetAreaType(SegmentType.TopRight) != tile.GetAreaType(SegmentType.BottomRight))
                return false;
        }

        Tile leftTile = LeftTileOf(x, y);
        if(leftTile != null)
        {
            if(leftTile.GetAreaType(SegmentType.RightTop) != tile.GetAreaType(SegmentType.LeftTop))
                return false;

            if(leftTile.GetAreaType(SegmentType.RightMiddle) != tile.GetAreaType(SegmentType.LeftMiddle))
                return false;

            if(leftTile.GetAreaType(SegmentType.RightBottom) != tile.GetAreaType(SegmentType.LeftBottom))
                return false;
        }

        return true;
    }

    public static Tile TopTileOf(int x, int y)
    {
        if(y == 0) 
            return null;
        return Tiles[x, y - 1];
    }

    public static Tile RightTileOf(int x, int y)
    {
        if(x == Tiles.GetLength(0) - 1) 
            return null;
        return Tiles[x+ 1, y];
    }

    public static Tile BottomTileOf(int x, int y)
    {
        if(y == Tiles.GetLength(1) - 1) 
            return null;
        return Tiles[x, y + 1];
    }

    public static Tile LeftTileOf(int x, int y)
    {
        if(x == 0) 
            return null;
        return Tiles[x - 1, y];
    }
}
