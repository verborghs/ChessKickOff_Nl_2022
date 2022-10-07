using UnityEngine;

public class Board : MonoBehaviour
{

    [SerializeField]
    private LayerMask _piecesLayerMask;

    [SerializeField]
    private LayerMask _tilesLayerMask;


    public void Select(Tile tile)
    {
        var piece = GetPieceAt(tile.transform.position);
        piece?.Activate();

    }


    public Piece GetPieceAt(Vector3 worldPosition)
    {
        worldPosition.y = 2;

        Debug.DrawRay(worldPosition, Vector3.down * 2, Color.red, 2);

        if (Physics.Raycast(worldPosition, Vector3.down, out var hitInfo, 2, _piecesLayerMask))
            return hitInfo.collider.GetComponent<Piece>();

        return null;
    }

    public Tile GetTileAt(Vector3 worldPosition)
    {
        worldPosition.y = 2;

        Debug.DrawRay(worldPosition, Vector3.down * 2, Color.green, 2);

        if (Physics.Raycast(worldPosition, Vector3.down, out var hitInfo, 2, _tilesLayerMask))
            return hitInfo.collider.GetComponent<Tile>();

        return null;


    }
}

