using UnityEngine;

public class PauseMenuGameTrigger : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Back") || Input.GetButtonDown("Start"))
        {
            if (pauseMenuCanvas.gameObject.activeSelf)
            {
                pauseMenuCanvas.gameObject.SetActive(false);
                PauseUtility.Unpause();
            }
            else
            {
                pauseMenuCanvas.gameObject.SetActive(true);
                PauseUtility.Pause();
            }
        }
    }
}
