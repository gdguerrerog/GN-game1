using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

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
    
    public bool HasMove() {
        if (hasClicked) {
            hasClicked = false;
            return true;
        }
        return false;
    }

    public object GetMove() {
        return null;
    }
}
