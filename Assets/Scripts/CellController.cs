using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector2Int coordinate;
    [SerializeField] private UI_Controller controller;

    public void Start()
    {
        controller.RegisterButton(coordinate, GetComponent<Image>());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.CellButton(coordinate);
    }
}
