using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public GameManager gameManager;
    public UI_Controller controller;
    public int currentPlayerTurn = 0;

    [SerializeField] public List<IConditionChecker> rowConditions = new();
    [SerializeField] public List<IConditionChecker> columnConditions = new();

    private void Awake()
    {
        List<int> numbers = NumberGenerator(6);
        for (int i = 0; i < 3; i++)
        {
            columnConditions.Add(GetConditionByIndex(numbers[i])); 
        }

        for (int i = 0; i < 3; i++)
        {
            rowConditions.Add(GetConditionByIndex(numbers[i + 3])); 
        }
    }

    public string RegisterColumnConditions(Vector2Int coordinates)
    {
        Debug.Log(columnConditions[coordinates.x].GetConditionView());
        return columnConditions[coordinates.x].GetConditionView();
    }

    public string RegisterRowConditions(Vector2Int coordinates)
    {
        Debug.Log(rowConditions[coordinates.y].GetConditionView());
        return rowConditions[coordinates.y].GetConditionView();
    }

    private IConditionChecker GetConditionByIndex(int index) 
    {
        switch (index)
        {
            case 0: 
                return new DivideBy(2);
            case 1:
                return new DivideBy(3);
            case 2:
                return new DivideBy(5);
            case 3:
                return new DivideBy(7);
            case 4:
                return new DigitsAmount(2);
            case 5:
                return new DigitsAmount(3);
            default:
                Debug.LogError("No condition");
                return null;
        }
    }

    private List<int> NumberGenerator(int arraySize)
    {
        List<int> conditionNumbers = new List<int>(new int[arraySize]);
        for (int i = 0; i < arraySize; i++)
        {
            conditionNumbers[i] = i;
        }
        for (int i = arraySize - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);
            (conditionNumbers[i], conditionNumbers[j]) = (conditionNumbers[j], conditionNumbers[i]);
        }
        return conditionNumbers;
    }
        private TileState PlayerIDtoState(int playerID)
    {
        if (playerID == 0) { return TileState.X; }
        else if (playerID == 1) { return TileState.O; }
        else { Debug.LogError("playerID doesn't exist"); return TileState.EMPTY; }
    }

    public void CellClicked(Vector2Int coordinates)
    {
        if (!gameManager.IsCellEmpty(coordinates))
        {
            return;
        }
        controller.ShowWindow(coordinates);
    }

    public void ConfirmMove(Vector2Int coordinates, int number)
    {
        TileState currentPlayerState = PlayerIDtoState(currentPlayerTurn);

        if (!columnConditions[coordinates.x].CheckCondition(number))
        {
            currentPlayerState = TileState.EMPTY;
        }
        else if (!rowConditions[coordinates.y].CheckCondition(number))
        {
            currentPlayerState = TileState.EMPTY;
        }

        if (gameManager.TryMove(currentPlayerTurn, coordinates, currentPlayerState))
        {
            currentPlayerTurn += 1;
            currentPlayerTurn %= 2;
            controller.RecolorTile(coordinates, gameManager.GetCell(coordinates));
            if (gameManager.WinCondition() == true) Debug.Log("Game over");
        }
    }

    public bool FinishGame()
    {
        if (gameManager.WinCondition() == true) return true;
        else return false;
    }
}