using UnityEngine;

public class GameScreenManager : MonoBehaviour
{
    public PauseMenuScript pauseMenu;
    public PauseMenuGameTrigger pauseMenuTrigger;

    public WinMenu winMenu;

    // Start is called before the first frame update
    void Start()
    {
        GameplaySession session = GameplaySession.Instance;
        session.onGameOver.AddListener(OnGameOver);
    }

    void OnGameOver()
    {
        PauseUtility.Pause();

        pauseMenuTrigger.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);

        winMenu.gameObject.SetActive(true);
    }
}
