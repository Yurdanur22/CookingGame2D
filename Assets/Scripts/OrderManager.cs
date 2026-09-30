using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrderManager : MonoBehaviour
{
    public List<RecipeSO> recipes;
    private RecipeSO currentRecipe;
    public Image mealImage;
    public GameObject orderPanel;
    public RecipeBoardUI recipeBoardUI;
    void Start()
    {
        ShowOrder();
    }

    void ShowOrder()
    {
        List<RecipeSO> availableRecipes = new List<RecipeSO>();

        foreach (RecipeSO recipe in recipes)
        {
            if (recipe.unlockDay <= DayManager.Instance.currentDay)
            {
                availableRecipes.Add(recipe);
            }
        }

        int randomIndex = Random.Range(0, availableRecipes.Count);
        currentRecipe = availableRecipes[randomIndex];
        mealImage.sprite = currentRecipe.orderSprite;
        recipeBoardUI.ShowRecipe(currentRecipe);
    }
    public void CompleteOrder()
    {
        Debug.Log("Sipariş tamamlandı!");
        // orderPanel.SetActive(false);
        StartCoroutine(NewOrderRoutine());
    }
    private IEnumerator NewOrderRoutine()
    {
        orderPanel.SetActive(false);

        yield return new WaitForSeconds(2f);

        ShowOrder();

        orderPanel.SetActive(true);
    }

}
