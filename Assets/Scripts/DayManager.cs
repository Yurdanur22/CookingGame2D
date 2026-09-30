using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DayManager : MonoBehaviour
{
    public int currentDay = 1;
    public int ordersCompleted = 0;
    public int ordersPerDay = 5;
    public int starsEarnedToday = 0;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI starsEarnedText;

    public static DayManager Instance;

    public GameObject dayCompletePanel;

    public bool waitingForNextDay = false;

    public bool dayComplete = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        FindSceneUI();
        Debug.Log("GameScene Start: " + currentDay);
        UpdateDayUI();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            FindSceneUI();
            UpdateDayUI();

            Debug.Log("GameScene UI yeniden bağlandı.");
        }
    }

    private void FindSceneUI()
    {
        // OrderText aktif olduğu için normal şekilde bulabiliriz
        GameObject orderObject = GameObject.Find("OrderText");

        if (orderObject != null)
        {
            orderText = orderObject.GetComponent<TextMeshProUGUI>();
        }

        // DayCompletePanel başlangıçta inactive olduğu için
        // Resources.FindObjectsOfTypeAll kullanıyoruz
        DayCompletePanelFinder();

        Debug.Log("OrderText bulundu: " + (orderText != null));
        Debug.Log("DayCompletePanel bulundu: " + (dayCompletePanel != null));
    }
    private void DayCompletePanelFinder()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "DayCompletePanel" && obj.scene.name == "GameScene")
            {
                dayCompletePanel = obj;
                break;
            }
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    void UpdateDayUI()
    {
        //if (dayText != null)
            //dayText.text = "Day " + currentDay;

        if (orderText != null)
            orderText.text = ordersCompleted + " / " + ordersPerDay;
    }

    public void CompleteOrder()
    {
        ordersCompleted++;
        Debug.Log("Day " + currentDay + " - Sipariş: " + ordersCompleted + " / " + ordersPerDay);

        UpdateDayUI();

        if (ordersCompleted >= ordersPerDay)
        {
            Debug.Log("Day " + currentDay + " TAMAMLANDI!");
            dayComplete = true;
            if (starsEarnedText != null)
            {
                starsEarnedText.text = "Stars Earned : " + starsEarnedToday;
            }
            waitingForNextDay = true;
            if (dayCompletePanel != null)
            {
                dayCompletePanel.SetActive(true);
            }
        }
    }

    void NextDay()
    {
        currentDay++;
        ordersCompleted = 0;

        UpdateDayUI();

        Debug.Log("Yeni Gün Başladı!");
    }

    public void ContinueToNextDay()
    {
        dayComplete = false;

        if (dayCompletePanel != null)
        {
            dayCompletePanel.SetActive(false);
        }

        currentDay++;
        ordersCompleted = 0;

        UpdateDayUI();

        starsEarnedToday = 0;
    }
    public void ContinueFromShop()
    {
        Debug.Log("Önce: " + currentDay);
        dayComplete = false;

        currentDay++;
        Debug.Log("Sonra: " + currentDay);

        ordersCompleted = 0;
        starsEarnedToday = 0;

        SceneManager.LoadScene("GameScene");
    }
    public void AddStars(int amount)
    {
        starsEarnedToday += amount;
    }
    public void OpenMarket()
    {
        dayCompletePanel.SetActive(false);
        SceneManager.LoadScene("ShopScene");
    }
  
}
