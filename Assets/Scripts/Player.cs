using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Tile CurrentTile { get; private set; }

    private TurnActionType currentAction;

    private void Update()
    {
        switch(currentAction)
        {
            case TurnActionType.TakeTile:
                if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
                {
                    if(hit.transform.CompareTag("TilesStack"))
                    {
                        
                    }
                }
                break;
            case TurnActionType.PlaceTile:
                break;
            case TurnActionType.UseMeeple:
                break;
        }

        if (CurrentTile != null)
        {
            MoveTile();

            if(Input.GetMouseButtonDown(0))
            {
                if(Map.CanPlace(CurrentTile.X, CurrentTile.Y, CurrentTile))
                {
                    Map.PlaceTile(CurrentTile.X, CurrentTile.Y, CurrentTile);
                    CurrentTile = null;
                }
            }
        }
    }

    private void MoveTile()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100, LayerMask.GetMask("Ground")))
        {
            CurrentTile.MoveTo(hit.point.x, hit.point.z);
        }
    }

    public void GetTileToHand(Tile tile) => CurrentTile = tile;
}
