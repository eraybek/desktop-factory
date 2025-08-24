using UnityEngine;
using UnityEngine.Tilemaps;

public class GridInputHandler : MonoBehaviour
{
    [Header("References")]
    public Tilemap highlightTilemap;
    public TileBase highlightTile;
    public Tilemap resourceTilemap;

    private Vector2Int? lastHoverCell;

    void Update()
    {
        HandleHover();
        HandleClick();
    }

    void HandleHover()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = resourceTilemap.WorldToCell(mouseWorld);

        if (lastHoverCell.HasValue && lastHoverCell.Value != (Vector2Int)cellPos)
        {
            highlightTilemap.SetTile((Vector3Int)lastHoverCell.Value, null);
        }

        highlightTilemap.SetTile(cellPos, highlightTile);
        lastHoverCell = (Vector2Int)cellPos;

    }

    void HandleClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = resourceTilemap.WorldToCell(mouseWorld);
            
            TileBase tile = resourceTilemap.GetTile(cellPos);
            
            Debug.Log($"Clicked cell {cellPos}");
            
            if (tile != null)
            {
                if (tile is ResourceTile resourceTile)
                {
                    Debug.Log($"Resource found - Type: {resourceTile.resourceType}");
                    Debug.Log($"Tile name: {tile.name}");
                }
                else
                {
                    Debug.Log($"Tile found but not a ResourceTile: {tile.name}");
                }
            }
            else
            {
                Debug.Log("No tile at this position - cell is empty");
            }
        }
    }

}

