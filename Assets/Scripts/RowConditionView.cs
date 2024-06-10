using UnityEngine;
using UnityEngine.UI;

public class RowConditionView : MonoBehaviour
{
    [SerializeField] private Vector2Int coordinate;
    [SerializeField] private GameView controller;
    [SerializeField] private Text rowText;

    public void Start()
    {
        rowText.text = controller.RegisterRowConditions(coordinate);
    }
}