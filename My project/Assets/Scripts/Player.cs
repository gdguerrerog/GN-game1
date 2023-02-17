using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public const string QUEEN = "QUEEN", KING = "KING", BISHOP_W = "BISHOP_W", BISHOP_B = "BISHOP_B", TOWER_1 = "TOWER_1", TOWER_2 = "TOWER_2", PAWN = "PAWN";

    public string color;
    public bool isCurrentPlayer = false;
    private bool hasClicked = false;

    void Start() {
        
    }

    void Update() {
        if (isCurrentPlayer) {
            Mouse mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame) {
                Vector3 mousePosition = mouse.position.ReadValue();
                    hasClicked = true;
            }
        } 
        
   }
    
    public bool hasMove() {
        if (hasClicked) {
            hasClicked = false;
            return true;
        }
        return false;
    }

    public object getMove() {
        return null;
    }
}
