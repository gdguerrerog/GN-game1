using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public Player WHITE_PLAYER;
    public Player BLACK_PLAYER;
    
    public Player currentPlayer;

    public Tilemap pieces;

    void Start()
    {
        currentPlayer.isCurrentPlayer = true;
    }

    void Update()
    {
        if (currentPlayer.hasMove()) {
            object move = currentPlayer.getMove();
            applyMove(move);

            currentPlayer.isCurrentPlayer = false;

            if (currentPlayer == WHITE_PLAYER) currentPlayer = BLACK_PLAYER;
            else currentPlayer = WHITE_PLAYER;
            
            currentPlayer.isCurrentPlayer = true;
        }
    }

    private void applyMove(object move) {
        Debug.Log("Click!!!" + currentPlayer.color);
    }
}
