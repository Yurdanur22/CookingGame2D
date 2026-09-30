using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneLoader : MonoBehaviour
{
    public GameObject shopDayCompletePanel;
    private void Update()
    {
        // GameScene -> ShopScene
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("ShopScene");
            }
        }

        // ShopScene -> GameScene
        if (SceneManager.GetActiveScene().name == "ShopScene")
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
    public void OpenShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void OpenGame()
    {
        DayManager.Instance.ContinueFromShop();
    }
    public void ShowShopPanel()
    {
        shopDayCompletePanel.SetActive(true);
    }

}