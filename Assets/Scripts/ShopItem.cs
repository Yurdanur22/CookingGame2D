using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public IngredientType ingredientType;

    public int price;
    public int amount;

    private Vector3 originalScale;
    private bool isAnimating = false;
    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnMouseDown()
    {
        if (MoneyManager.Instance.SpendMoney(price))
        {
            InventoryManager.Instance.AddIngredient(ingredientType, amount);

            ShopAudioManager.Instance.PlayBuySound();

            StartCoroutine(ClickAnimation());

            Debug.Log(amount + " " + ingredientType + " satın alındı.");
        }
        else
        {
            Debug.Log("Yeterli para yok.");
        }
    }
    private System.Collections.IEnumerator ClickAnimation()
    {
        if (isAnimating)
            yield break;

        isAnimating = true;

        transform.localScale = originalScale * 0.8f;

        yield return new WaitForSeconds(0.08f);

        transform.localScale = originalScale;

        isAnimating = false;
    }

}