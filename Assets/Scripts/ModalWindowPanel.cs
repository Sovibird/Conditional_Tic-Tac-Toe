using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalWindowPanel : MonoBehaviour
{
    [SerializeField] private Transform headerArea;
    [SerializeField] private TextMeshProUGUI titleField;

    [SerializeField] public Transform contentArea;
    [SerializeField] public TMP_InputField inputField;

    [SerializeField] private Transform footerArea;
    [SerializeField] private Button confirmButton;
}