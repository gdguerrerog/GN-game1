using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public const int PAWN = 1, TOWER = 2, BISHOP = 3, HORSE = 4, QUEEN = 5, KING = 6;

    public Player WHITE_PLAYER;
    public Player BLACK_PLAYER;
    
    public Player currentPlayer;

    public Tilemap pieces;

    public int[,] gameState;


    // Singleton
    public static GameController Instance { get; private set; }
    private void Awake() { 
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this; 
    }


    void Start() {
        SetupGameState();
    }


    // negative if its black, positive if its white
    private void SetupGameState() {
        gameState = new int[8, 8];
    }

    void Update() {
        if (currentPlayer.HasMove()) {
            object move = currentPlayer.GetMove();
            ApplyMove(move);

            if (currentPlayer == WHITE_PLAYER) currentPlayer = BLACK_PLAYER;
            else currentPlayer = WHITE_PLAYER;
        }
    }

    private void ApplyMove(object move) {
        Debug.Log("Click!!!" + currentPlayer.color);
    }
}
