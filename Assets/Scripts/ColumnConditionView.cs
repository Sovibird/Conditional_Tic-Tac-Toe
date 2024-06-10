using UnityEngine;
using UnityEngine.UI;

public class ColumnConditionView : MonoBehaviour
{
    [SerializeField] private Vector2Int coordinate;
    [SerializeField] private GameView controller;
    [SerializeField] private Text columnText;

    public void Start()
    {
        columnText.text = controller.RegisterColumnConditions(coordinate);
    }
}