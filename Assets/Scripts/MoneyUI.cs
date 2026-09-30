using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    private void Start()
    {
        MoneyManager.Instance.moneyText = GetComponent<TextMeshProUGUI>();
        MoneyManager.Instance.UpdateMoneyUI();
    }
    
}