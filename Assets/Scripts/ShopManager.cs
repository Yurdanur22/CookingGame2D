using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyEgg();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuySalt();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyButter();
        }
    }

    public void BuyEgg()
    {
        if (MoneyManager.Instance.SpendMoney(10))
        {
            InventoryManager.Instance.AddIngredient(IngredientType.Egg, 5);

            Debug.Log("5 Egg satın alındı.");
        }
        else
        {
            Debug.Log("Yeterli para yok.");
        }
    }

    public void BuySalt()
    {
        if (MoneyManager.Instance.SpendMoney(5))
        {
            InventoryManager.Instance.AddIngredient(IngredientType.Salt, 10);

            Debug.Log("10 Salt satın alındı.");
        }
        else
        {
            Debug.Log("Yeterli para yok.");
        }
    }

    public void BuyButter()
    {
        if (MoneyManager.Instance.SpendMoney(8))
        {
            InventoryManager.Instance.AddIngredient(IngredientType.Butter, 5);

            Debug.Log("5 Butter satın alındı.");
        }
        else
        {
            Debug.Log("Yeterli para yok.");
        }
    }
}