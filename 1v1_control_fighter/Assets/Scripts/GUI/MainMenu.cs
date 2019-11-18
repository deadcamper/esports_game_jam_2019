using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuWindow;
    public GameObject levelSelectWindow;
    public GameObject helpWindow;

    public Button mainMenuLevelButton;
    public Button mainMenuHelpButton;
    public Button mainMenuQuitButton;

    public Button levelSelectFirstLevelButton;
    public Button levelSelectSecondLevelButton;
    public Button levelSelectThirdLevelButton;
    public Button levelSelectDevLevelButton;
    public Button levelSelectBackButton;

    public Button helpBackButton;

    public enum PreferredWindow
    {
        MainMenu,
        LevelSelect
    }

    public static PreferredWindow choiceWindow = PreferredWindow.MainMenu;

    void Start()
    {
        mainMenuLevelButton.onClick.AddListener(OnLevelSelect);
        mainMenuHelpButton.onClick.AddListener(OnHelpSelect);
        mainMenuQuitButton.onClick.AddListener(OnQuit);

        levelSelectFirstLevelButton.onClick.AddListener(() => { LoadLevel("Level01_V2"); });
        levelSelectSecondLevelButton.onClick.AddListener(() => { LoadLevel("Level02"); });
        levelSelectThirdLevelButton.onClick.AddListener(() => { LoadLevel("Level03"); });
        levelSelectDevLevelButton.onClick.AddListener(() => { LoadLevel("GameTestScene"); });
        levelSelectBackButton.onClick.AddListener(OnMenuSelect);

        helpBackButton.onClick.AddListener(OnMenuSelect);

        if (choiceWindow == PreferredWindow.LevelSelect)
        {
            OnLevelSelect();
        }
        else
        {
            OnMenuSelect();
        }
    }

    void OnMenuSelect()
    {
        OpenWindow(mainMenuWindow);
        EventSystem.current.SetSelectedGameObject(mainMenuLevelButton.gameObject);
    }
    void OnLevelSelect()
    {
        OpenWindow(levelSelectWindow);
        EventSystem.current.SetSelectedGameObject(levelSelectFirstLevelButton.gameObject);
    }

    void OnHelpSelect()
    {
        OpenWindow(helpWindow);
        EventSystem.current.SetSelectedGameObject(helpBackButton.gameObject);
    }

    void OnQuit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    private void OpenWindow(GameObject window)
    {
        mainMenuWindow.SetActive(false);
        levelSelectWindow.SetActive(false);
        helpWindow.SetActive(false);

        window.SetActive(true);
    }

    void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
