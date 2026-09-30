using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<IngredientType> ingredients;
    public GameObject resultPrefab;
    public Sprite orderSprite;
    public int sellPrice;

    public int unlockDay = 1;
}
