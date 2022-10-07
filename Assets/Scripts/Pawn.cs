using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pawn : Piece
{

    private bool _hasMoved = false;

    private List<Tile> _validTiles = new List<Tile>();

    public override void Activate()
    {
        _validTiles.Clear();

        var tile1 = Board.GetTileAt(transform.position + transform.forward);
        if(tile1 != null)
        {
            var piece1 = Board.GetPieceAt(tile1.transform.position);
            if (piece1 == null)
            {
                _validTiles.Add(tile1);
                tile1.Hightlight();
            }

            if(!_hasMoved)
            {
                var tile2 = Board.GetTileAt(transform.position + transform.forward * 2);
                if(tile2 != null)
                {
                    var piece2 = Board.GetPieceAt(tile2.transform.position);
                    if (piece2 == null)
                    {
                        _validTiles.Add(tile2);
                        tile2.Hightlight();
                    }
                }
            }
        }

        var tile3 = Board.GetTileAt(transform.position + transform.forward + transform.right);
        if(tile3 != null)
        {
            var piece3 = Board.GetPieceAt(tile3.transform.position);
            if (piece3 != null)
            {
                _validTiles.Add(tile3);
                tile3.Hightlight();
            }
        }

        var tile4 = Board.GetTileAt(transform.position + transform.forward - transform.right);
        if (tile4 != null)
        {
            var piece4 = Board.GetPieceAt(tile4.transform.position);
            if (piece4 != null)
            {
                _validTiles.Add(tile4);
                tile4.Hightlight();
            }
        }
    }

    internal override bool Move(Tile tile)
    {
        if (_validTiles.Contains(tile))
        {
            transform.position = tile.transform.position;

            foreach (var validTile in _validTiles)
                validTile.UnHightlight();

            return true;
        }

        return false;
    }
}
