using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton Instance { get; private set; }

    public AudioSource coinPickup;
    public AudioSource music;
    public AudioSource chestOpen;

    void OnEnable()
    {
        if (Instance)
        {
            Debug.Log("Discovered existing audio singleton. Self-destructing...");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
