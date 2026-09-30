using UnityEngine;

public class IngredientDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private bool dragging;
    private bool isOverPot;
    private Pot pot;
    public IngredientType ingredientType;
    void Start()
    {
        startPosition = transform.position;
        pot = FindFirstObjectByType<Pot>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (!InventoryManager.Instance.HasIngredient(ingredientType))
                {
                    Debug.Log("Bu malzemeden kalmadı!");
                    return;
                }

                dragging = true;
            }
        }

        if (dragging)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            if (isOverPot && pot.IsOpen())
            {
               // Debug.Log(gameObject.name + " tencereye eklendi");
                pot.AddIngredient(ingredientType);
                InventoryManager.Instance.UseIngredient(ingredientType);
                // gameObject.SetActive(false);
                //transform.position = startPosition;
                if (InventoryManager.Instance.GetStock(ingredientType) == 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    transform.position = startPosition;
                }
            }
            else
            {
                transform.position = startPosition;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Çarptı: " + other.name);
        if (other.CompareTag("Pot"))
        {
            isOverPot = true;
            Debug.Log("Tencerenin üstünde");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pot"))
        {
            isOverPot = false;
        }
    }

}
