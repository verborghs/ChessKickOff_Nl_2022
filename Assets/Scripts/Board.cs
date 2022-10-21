using System;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    [SerializeField]
    private LayerMask _piecesLayerMask;

    [SerializeField]
    private LayerMask _tilesLayerMask;

    private Player _currentPlayer = Player.White;

    private Piece _currentPiece;
    private List<Tile> _validTiles = new List<Tile>(0);


    public void Select(Tile tile)
    {

        DeactivateValidTiles();

        if (_currentPiece == null)
        {
            var selectedPiece = GetPieceAt(tile.transform.position);
            if (selectedPiece != null && _currentPlayer == selectedPiece.Player)
            {
                _currentPiece = selectedPiece;
                _validTiles = _currentPiece?.GetValidTiles();
            }
        }
        else
        {
            if(_validTiles.Contains(tile))
            {
                TryTakePiece(tile);

                _currentPiece.Move(tile);

                ResetData();

                ChangeTurn();
            }
        }

        ActivateValidTiles();

    }

    private void ActivateValidTiles()
    {
        foreach (var validTile in _validTiles)
            validTile.Hightlight();
    }

    private void DeactivateValidTiles()
    {
        foreach (var validTile in _validTiles)
            validTile.UnHightlight();
    }

    private void ChangeTurn()
    {
        _currentPlayer = (_currentPlayer == Player.White) ? Player.Black : Player.White;
    }

    private void TryTakePiece(Tile tile)
    {
        var piece = GetPieceAt(tile.transform.position);
        if (piece != null && piece.Player != _currentPlayer)
            piece.Take();
    }

    private void ResetData()
    {
        _currentPiece = null;
        _validTiles.Clear();
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

