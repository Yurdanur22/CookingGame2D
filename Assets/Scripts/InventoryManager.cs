using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Dictionary<IngredientType, int> ingredientStock =
        new Dictionary<IngredientType, int>();

    public TextMeshProUGUI eggText;
    public TextMeshProUGUI saltText;
    public TextMeshProUGUI butterText;
    public TextMeshProUGUI breadText;
    public TextMeshProUGUI milkText;
    public TextMeshProUGUI bananaText;
    public TextMeshProUGUI flourText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            ingredientStock.Add(IngredientType.Egg, 5);
            ingredientStock.Add(IngredientType.Salt, 20);
            ingredientStock.Add(IngredientType.Butter, 10);
            ingredientStock.Add(IngredientType.Bread, 5);
            ingredientStock.Add(IngredientType.Mulk, 10);
            ingredientStock.Add(IngredientType.Banana, 10);
            ingredientStock.Add(IngredientType.Flour, 5);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        UpdateInventoryUI();
    }
    public int GetStock(IngredientType ingredient)
    {
        return ingredientStock[ingredient];
    }
    public bool HasIngredient(IngredientType ingredient)
    {
        return ingredientStock[ingredient] > 0;
    }
    public void UseIngredient(IngredientType ingredient)
    {
        if (HasIngredient(ingredient))
        {
            ingredientStock[ingredient]--;
            UpdateInventoryUI();

            Debug.Log(ingredient + " kaldı: " + ingredientStock[ingredient]);
        }
    }
    public void AddIngredient(IngredientType ingredient, int amount)
    {
        ingredientStock[ingredient] += amount;
        Debug.Log($"{ingredient} eklendi: +{amount}, Yeni stok: {ingredientStock[ingredient]}");
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI()
    {
        if (eggText != null)
            eggText.text = "Egg : " + ingredientStock[IngredientType.Egg];

        if (saltText != null)
            saltText.text = "Salt : " + ingredientStock[IngredientType.Salt];

        if (butterText != null)
            butterText.text = "Butter : " + ingredientStock[IngredientType.Butter];

        if (breadText != null)
            breadText.text = "Bread : " + ingredientStock[IngredientType.Bread];

        if (milkText != null)
            milkText.text = "Milk : " + ingredientStock[IngredientType.Mulk];

        if (bananaText != null)
            bananaText.text = "Banana : " + ingredientStock[IngredientType.Banana];

        if (flourText != null)
            flourText.text = "Flour : " + ingredientStock[IngredientType.Flour];

    }

}
