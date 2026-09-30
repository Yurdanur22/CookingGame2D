using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Pot : MonoBehaviour
{
    public List<IngredientType> ingredients = new List<IngredientType>();
    public Transform lid;
    private Vector3 closedPosition;
    private bool isOpen = false;
    public GameObject SunnySideUpEggPrefab;
    public Transform eggSpawnPoint;
    public List<RecipeSO> recipes;
    private bool isCooking = false;
    public GameObject steamEffect;
    public AudioSource cookingAudio;
    void Start()
    {
        closedPosition = lid.position;
    }
    public void AddIngredient(IngredientType ingredient)
    {
        ingredients.Add(ingredient);
        /*
        Debug.Log("Tenceredeki malzemeler:");

        foreach (string item in ingredients)
        {
            Debug.Log(item);
        }*/

    }
    public void ToggleLid()
    {
        if (isCooking)
        {
            return;
        }
        if (!isOpen)
        {
            lid.position = closedPosition + new Vector3(0, 0.5f, 0);
            isOpen = true;
        }
        else
        {
            lid.position = closedPosition;
            isOpen = false;
            // CheckRecipe();
            StartCoroutine(Cook());
        }
    }
    private void OnMouseDown()
    {
        ToggleLid();
    }
    public bool IsOpen()
    {
        return isOpen;
    }
    private void CheckRecipe()
    {
        /* if (ingredients.Count == 3 &&
             ingredients.Contains(IngredientType.Butter) &&
             ingredients.Contains(IngredientType.Egg) &&
             ingredients.Contains(IngredientType.Salt))
         {
             // Debug.Log("🍳 Omlet yapıldı!");
             Instantiate(SunnySideUpEggPrefab, eggSpawnPoint.position, Quaternion.identity);
         }
         else
         {
             Debug.Log("❌ Tarif başarısız.");
         }*/
        foreach (RecipeSO recipe in recipes)
        {
            if (recipe.ingredients.Count != ingredients.Count)
                continue;

            bool match = true;

            foreach (IngredientType ingredient in recipe.ingredients)
            {
                if (!ingredients.Contains(ingredient))
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                GameObject meal = Instantiate(
                    recipe.resultPrefab,
                    eggSpawnPoint.position,
                    Quaternion.identity
                );

                ServedMeal servedMeal = meal.GetComponent<ServedMeal>();

                if (servedMeal != null)
                {
                    servedMeal.recipe = recipe;
                }

                Debug.Log("Tarif bulundu!");
                ingredients.Clear();
                return;
            }
        }

        Debug.Log("Tarif bulunamadı.");
        ingredients.Clear();

    }
    private IEnumerator Cook()
    {
        isCooking = true;

        steamEffect.SetActive(true);
        cookingAudio.Play();

        Debug.Log("Pişiyor...");

        yield return new WaitForSeconds(2f);

        steamEffect.SetActive(false);
        cookingAudio.Stop();

        CheckRecipe();

        isCooking = false;
    }

}
