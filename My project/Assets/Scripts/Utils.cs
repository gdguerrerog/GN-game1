using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{


    // Cheks if a piece is ally of a player or not
    public static bool isAlly(int piece, string player) {
        if (player == GameController.WHITE) return piece > 0;
        return piece < 0;
    }

    public static List<(int, int)> GetMovementsPawn((int, int) location, int[,] gameState, string player) {
        return null;
    }

    public List<(int, int)> GetMovementsKing((int, int) location, int[,] gameState, string player) {
        return null;
    }

    public List<(int, int)> GetMovementsTower((int, int) location, int[,] gameState, string player) {
        return null;
    }



    public List<(int, int)> GetMovementsBishop((int, int) location, int[,] gameState, string player) {
        List<(int, int)> exit = new List<(int, int)>();

        (int, int)[] directions = {(1, 0), (-1, 0), (0, 1), (0, -1)};

        // For each direction
        foreach ((int, int) dir in directions) {
            // For each possible distance
            for (int i = 1; i < 7; i++) {
                (int, int) newLocation = (location.Item1 + dir.Item1 * i, location.Item2 + dir.Item2 * i);
                // Check if locations is inside the bounds of the board
                if (newLocation.Item1 < 0 || newLocation.Item1 >= 8 || newLocation.Item2 < 0 || newLocation.Item2 >= 8) break;
                
                int targetPiece = gameState[newLocation.Item1, newLocation.Item2];

                if (targetPiece == 0) exit.Add(newLocation); // Empty place
                else if (isAlly(targetPiece, player)) break; // cant eat or see over a ally piece
                else { // Can eat a enemy piece but cant see over
                    exit.Add(newLocation);
                    break;
                }
            }    
        }
        

        return exit;
    }

     public List<(int, int)> GetMovementsQueen((int, int) location, int[,] gameState, string player) {
        return null;
    }

     public List<(int, int)> GetMovementsHorse((int, int) location, int[,] gameState, string player) {
        return null;
    }


}
