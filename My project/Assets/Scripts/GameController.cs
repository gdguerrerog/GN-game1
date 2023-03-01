using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public const int PAWN = 1, TOWER = 2, BISHOP = 3, HORSE = 4, QUEEN = 5, KING = 6;
    public const string WHITE = "WHITE", BLACK = "BLACK";

    private Camera cam;
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
        cam = Camera.main;
        ReadGameState();
        // SetupGameState();
    }


    // negative if its black, positive if its white
    private int[,] SetupGameState() {
        int[,] gameState = new int[8, 8];

        // Pawns
        for (int i = 0; i < 8; i++) {
            gameState[1, i] = PAWN;
            gameState[6, i] = -PAWN;
        }

        // Towers
        gameState[0, 0] = TOWER;
        gameState[0, 7] = TOWER;
        gameState[7, 0] = -TOWER;
        gameState[7, 7] = -TOWER;

        // Horses
        gameState[0, 1] = HORSE;
        gameState[0, 6] = HORSE;
        gameState[7, 1] = -HORSE;
        gameState[7, 6] = -HORSE;

        // Bishops
        gameState[0, 2] = BISHOP;
        gameState[0, 5] = BISHOP;
        gameState[7, 2] = -BISHOP;
        gameState[7, 5] = -BISHOP;

        // Queens
        gameState[0, 3] = QUEEN;
        gameState[7, 3] = -QUEEN;

        // Kings
        gameState[0, 4] = KING;
        gameState[7, 4] = -KING;

        return gameState;
    }


    private int[,] ReadGameState() {
        Vector3Int corner = new Vector3Int(-4, -4, 0);

        int[,] gameState = new int[8, 8];

        for (int i = 0; i < 8; i++) for (int j = 0; j < 8; j++) {
            Debug.Log(pieces.GetTile(corner + new Vector3Int(i, j, 0))?.name);
        }


        return gameState;
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
