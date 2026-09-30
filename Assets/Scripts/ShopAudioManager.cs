using UnityEngine;

public class ShopAudioManager : MonoBehaviour
{
    public static ShopAudioManager Instance;

    public AudioSource audioSource;
    public AudioClip buySound;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayBuySound()
    {
        audioSource.PlayOneShot(buySound);
    }
}