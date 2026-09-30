using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBoardUI : MonoBehaviour
{
    public Image[] ingredientImages;
    public List<IngredientIcon> ingredientIcons;

    public void ShowRecipe(RecipeSO recipe)
    {
        // Önce bütün resimleri kapat
        foreach (Image image in ingredientImages)
        {
            image.enabled = false;
        }

        // Tarifteki malzemeleri sırayla göster
        for (int i = 0; i < recipe.ingredients.Count; i++)
        {
            IngredientType ingredient = recipe.ingredients[i];

            foreach (IngredientIcon icon in ingredientIcons)
            {
                if (icon.ingredient == ingredient)
                {
                    ingredientImages[i].sprite = icon.icon;
                    ingredientImages[i].enabled = true;
                    break;
                }
            }
        }
    }
}
