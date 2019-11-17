using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Keeps track of the in-game stats, including the time limit, player's scores, and who Player 1 and Player 2 are.
/// </summary>
/// 
[DisallowMultipleComponent]
public class GameplaySession : MonoBehaviour
{

    public UnityEvent onGameOver;
    public static GameplaySession Instance { get; private set; }

    public GameObject playerLeft, playerRight;

    public int playerLeftPoints, playerRightPoints;

    public float timeLimitSeconds = 30;

    private bool isGameOver = false;

    [HideInInspector]
    public float TimeStampStarted { get; private set; }

    public float TimeLeft { get { return TimeStampStarted + timeLimitSeconds - Time.time; } }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate Game session discovered. Overriding...");
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }
    void Start()
    {
        if (playerLeft == null || playerRight == null)
        {
            Debug.LogError("Missing the left or right player. Game will not function properly.");
        }
        TimeStampStarted = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && TimeLeft <= 0)
        {
            // Do something to end the torment
            isGameOver = true;
            onGameOver.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (this == Instance)
        {
            Instance = null;
        }
    }
}
