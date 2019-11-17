using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class WinMenu : MonoBehaviour
{
    public TMPro.TextMeshProUGUI winnerText;

    public Button replayButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Awake()
    {
        replayButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);
    }

    void OnEnable()
    {
        GameplaySession session = GameplaySession.Instance;
        if (session.playerLeftPoints > session.playerRightPoints)
        {
            //#2DFF30
            winnerText.color = new Color(0.175f, 1f, 0.175f, 1f);
            winnerText.text = "Player 1 wins!!!";
        }
        else if(session.playerLeftPoints < session.playerRightPoints)
        {
            //#00B3FF
            winnerText.color = new Color(0, 0.70f, 1f, 1f);
            winnerText.text = "Player 2 wins!!!";
        }
        else
        {
            winnerText.color = new Color(1, 0.9f, 0.9f, 1f);
            winnerText.text = "Stalemate!";
        }
    }

    
    private void Start()
    {
        // Technically this is okay at this time...?
        EventSystem.current.SetSelectedGameObject(replayButton.gameObject);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameObject.SetActive(false);
        PauseUtility.Unpause();
    }

    private void Quit()
    {
        // TODO
        PauseUtility.Unpause();
        SceneManager.LoadScene("MainMenu");
    }

}
