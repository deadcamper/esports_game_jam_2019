using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuGameTrigger : MonoBehaviour
{
    public PauseMenuScript pauseMenuCanvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Back") || Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuCanvas.gameObject.activeSelf)
            {
                pauseMenuCanvas.gameObject.SetActive(false);
                PauseUtility.Unpause();
            }
            else
            {
                pauseMenuCanvas.gameObject.SetActive(true);

                EventSystem.current.SetSelectedGameObject(pauseMenuCanvas.resumeButton.gameObject);
                PauseUtility.Pause();
            }
        }
    }
}
