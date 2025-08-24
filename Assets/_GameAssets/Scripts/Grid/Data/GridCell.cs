using UnityEngine;

public class GridCell
{
    public Vector2Int Position { get; private set; }
    public ResourceType Resource { get; set; }

    public bool IsOccupied => Resource != ResourceType.None;

    public GridCell(Vector2Int position)
    {
        Position = position;
        Resource = ResourceType.None;
    }
}
