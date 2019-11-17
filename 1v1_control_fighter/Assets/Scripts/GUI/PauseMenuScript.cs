using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Named "script" because there's just a weird hanging script somewhere unrelated to the project.
/// </summary>
public class PauseMenuScript : MonoBehaviour
{
    public Button resumeButton;
    public Button quitButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);
    }


    private void Resume()
    {
        gameObject.SetActive(false);
        PauseUtility.Unpause();
    }

    private void Quit()
    {
        GameplaySession session = GameplaySession.Instance;

        if(session)
        {
            session.ForceGameEnd();
            gameObject.SetActive(false);
        }
        else
        {
            PauseUtility.Unpause();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
