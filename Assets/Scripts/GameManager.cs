using System.Collections.Generic;
using UnityEngine;

public enum TileState { X, O, EMPTY }

public class GameManager : MonoBehaviour
{
    int turn = 0;

    List<List<TileState>> field;

    public void Awake()
    {
        field = new();
        for (int x = 0; x < 3; x++)
        {
            field.Add(new List<TileState>());
            for (int y = 0; y < 3; y++)
            {
                field[x].Add(TileState.EMPTY);
            }
        }
    }

    public TileState GetCell(Vector2Int coordinates)
    {
        return field[coordinates.x][coordinates.y];
    }

    public bool IsCellEmpty(Vector2Int coordinates)
    {
        if (field[coordinates.x][coordinates.y] != TileState.EMPTY) return false;
        return true;
    }

    public bool TryMove(int playerID, Vector2Int coordinates, TileState state)
    {
        if (turn != playerID || !IsCellEmpty(coordinates)) { return false; }

        field[coordinates.x][coordinates.y] = state;
        turn++;
        turn %= 2;
        return true;
    }

    public bool WinCondition()
    {
        int size = field.Count;

        for (int x = 0; x < size; x++)
        {
            if (field[x][0] == TileState.EMPTY) continue;
            bool win = true;
            for (int y = 1; y < size; y++)
            {
                if (field[x][y] != field[x][0])
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;
        }

        for (int y = 0; y < size; y++)
        {
            if (field[0][y] == TileState.EMPTY) continue;
            bool win = true;
            for (int x = 1; x < size; x++)
            {
                if (field[x][y] != field[0][y])
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;
        }

        if (field[0][0] != TileState.EMPTY && field[0][0] == field[1][1] && field[0][0] == field[2][2]) return true;
        if (field[2][0] != TileState.EMPTY && field[2][0] == field[1][1] && field[2][0] == field[0][2]) return true;

        return false;
    }
}