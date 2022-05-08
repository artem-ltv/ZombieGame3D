using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;
    [SerializeField] private Button _buttonResume;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Button _buttonMainMenu;

    private bool isPause;

    private void Start()
    {
        isPause = false;
        _buttonResume.onClick.AddListener(Resume);
        _buttonOptions.onClick.AddListener(ShowOptions);
        _buttonMainMenu.onClick.AddListener(LoadMainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (isPause)
            ShowPausePannel(isPause, 0f, CursorLockMode.None);

        else
            Resume();
    }

    private void ShowPausePannel(bool showPause, float timeScale, CursorLockMode cursorLockMode)
    {
        _panelPause.SetActive(showPause);
        Time.timeScale = timeScale;
        Cursor.lockState = cursorLockMode;
    }

    private void Resume()
    {
        isPause = false;
        ShowPausePannel(isPause, 1f, CursorLockMode.Locked);
    }

    private void ShowOptions()
    {
        Debug.Log("Options");
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
