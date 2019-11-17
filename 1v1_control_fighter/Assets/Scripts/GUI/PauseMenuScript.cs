using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Named "script" because there's just a weird hanging script somewhere unrelated to the project.
/// </summary>
public class PauseMenuScript : MonoBehaviour
{
    public Button resumeButton;
    public Button helpButton;
    public Button quitButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        helpButton.onClick.AddListener(Help);
        quitButton.onClick.AddListener(Quit);
    }

    private void Resume()
    {
        gameObject.SetActive(false);
        PauseUtility.Unpause();
    }
    private void Help()
    {
        // TODO
    }

    private void Quit()
    {
        // TODO
    }
}
