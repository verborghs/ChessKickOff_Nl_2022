using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{

    private Board _board;

    private void OnEnable()
    {
        _board = FindObjectOfType<Board>();           
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        _board.Select(this);   
    }

    internal void Hightlight()
    {
        Debug.Log($"Tile {gameObject.name} Highlighted");
    }
}
