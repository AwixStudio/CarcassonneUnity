using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesStack : MonoBehaviour
{
    [SerializeField] private Tile startingTile;
    [SerializeField] private Tile[] startingTiles;
    [SerializeField] private Tile lastStartingTile;
    [SerializeField] private Tile[] tiles;
    [SerializeField] private float tileWidth;

    private Stack<Tile> stack = new Stack<Tile>();

    private void Awake()
    {
        Shuffle(startingTiles);
        Shuffle(tiles);

        for (int i = 0; i < tiles.Length; i++)
            stack.Push(Instantiate(tiles[i], transform.position + transform.up * tileWidth * i, Quaternion.identity));
        stack.Push(Instantiate(lastStartingTile, transform.position + transform.up * tileWidth * (tiles.Length), Quaternion.identity));
        for (int i = 0; i < startingTiles.Length; i++)
            stack.Push(Instantiate(startingTiles[i], transform.position + transform.up * tileWidth * (tiles.Length + 1 + i), Quaternion.identity));
        stack.Push(Instantiate(startingTile, transform.position + transform.up * tileWidth * (tiles.Length + 1 + startingTiles.Length), Quaternion.identity));
    }

    private void Shuffle<T>(T[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    public void OnMouseDown()
    {
        Map.CurrentPlayer.GetTileToHand(stack.Peek());
    }
}
