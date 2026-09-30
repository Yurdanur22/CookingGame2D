using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI saltText;
    public TextMeshProUGUI butterText;
    public TextMeshProUGUI breadText;

    private void Start()
    {
        InventoryManager.Instance.eggText = eggText;
        InventoryManager.Instance.saltText = saltText;
        InventoryManager.Instance.butterText = butterText;
        InventoryManager.Instance.breadText = breadText;

        InventoryManager.Instance.UpdateInventoryUI();
    }
}