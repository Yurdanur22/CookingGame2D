using UnityEngine;

public class ServedMeal : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isServing = false;
    public OrderManager orderManager;
    private MoneyManager moneyManager;
    public RecipeSO recipe;
    void Start()
    {
        orderManager = FindFirstObjectByType<OrderManager>();
        moneyManager = FindFirstObjectByType<MoneyManager>();
    }
    void Update()
    {
        if (isServing)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 2f * Time.deltaTime);

            // Ekrandan iyice çıkınca sil
            if (transform.position.x < -15f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Yemeğe tıklandı!");
        orderManager.CompleteOrder();
        moneyManager.AddMoney(recipe.sellPrice);
        DayManager.Instance.AddStars(recipe.sellPrice);
        DayManager.Instance.CompleteOrder();
        isServing = true;
    }

}
