using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{


    public static readonly (int, int)[] ROUND_4 = {(1, 0), (-1, 0), (0, 1), (0, -1)};
    public static readonly (int, int)[] ROUND_8 = {
        ( 1, 1), ( 1, 0), ( 1, -1),
        ( 0, 1),          ( 0, -1),
        (-1, 1), (-1, 0), (-1, -1)
    };

    // Cheks if a piece is ally of a player or not
    public static bool isAlly(int piece, string player) {
        if (player == GameController.WHITE) return piece > 0;
        return piece < 0;
    }

    public static List<(int, int)> GetMovementsPawn((int, int) location, int[,] gameState, string player) {
    int x = location.Item1;
    int y = location.Item2;
    List<(int, int)> movements = new List<(int, int)>();

    int direction = (player == GameController.WHITE) ? 1 : -1;
    
    (int, int)[] directions = 
    {
        (1, direction), (0,direction), (-1, direction) 
    };

    // For each direction
    foreach ((int, int) dir in directions) {
        (int, int) newLocation = (x + dir.Item1, y + dir.Item2);
        // Check if locations is inside the bounds of the board
        if (newLocation.Item1 < 0 || newLocation.Item1 >= 8 || newLocation.Item2 < 0 || newLocation.Item2 >= 8) continue;
        
        int targetPiece = gameState[newLocation.Item1, newLocation.Item2];

        if(targetPiece == 0 && dir.Item1==0) movements.Add(newLocation);
        else if (targetPiece != 0 && !isAlly(targetPiece, player)) movements.Add(newLocation); // Can eat a enemy piece
    }

    return movements;
    }


    public static List<(int, int)> GetMovementsKing((int, int) location, int[,] gameState, string player) {
        return GetFixedMovements(location, gameState, player, ROUND_8);
    }


    public static List<(int, int)> GetInfiniteMovements((int, int) location, int[,] gameState, string player, (int, int)[] directions) {
        List<(int, int)> exit = new List<(int, int)>();
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


    public static List<(int, int)> GetFixedMovements((int, int) location, int[,] gameState, string player, (int, int)[] directions) {
        List<(int, int)> exit = new List<(int, int)>();
        
        foreach ((int dx, int dy) dir in directions) {
            (int, int) newLocation = (location.Item1 + dir.Item1, location.Item2 + dir.Item2);

            // Check if new position is inside the board
            if (newLocation.Item1 < 0 || newLocation.Item1 >= 8 || newLocation.Item2 < 0 || newLocation.Item2 >= 8) continue;

            int targetPiece = gameState[newLocation.Item1, newLocation.Item2];

            // Check if new position is empty or contains an enemy piece
            if (targetPiece == 0 || !isAlly(targetPiece, player)) exit.Add(newLocation);
        }

        return exit;
    }

    public static List<(int, int)> GetMovementsTower((int, int) location, int[,] gameState, string player) {
        return GetInfiniteMovements(location, gameState, player, ROUND_4);
    }



    public static List<(int, int)> GetMovementsBishop((int, int) location, int[,] gameState, string player) {
        (int, int)[] directions = {(1, 1), (-1, -1), (-1, 1), (1, -1)};
        return GetInfiniteMovements(location, gameState, player, directions);
    }

     public static List<(int, int)> GetMovementsQueen((int, int) location, int[,] gameState, string player) {
        return GetInfiniteMovements(location, gameState, player, ROUND_8);
    }

     public static List<(int, int)> GetMovementsHorse((int, int) location, int[,] gameState, string player) {
        (int, int)[] directions = {(2, 1), (2, -1), (-2, 1), (-2, -1), (1, -2), (-1, -2), (1, 2), (-1, 2)};
        return GetFixedMovements(location, gameState, player, directions);
    }


}
