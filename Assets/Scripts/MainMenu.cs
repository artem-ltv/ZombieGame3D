using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonOptions;
    [SerializeField] private Button _buttonQuit;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _buttonPlay.onClick.AddListener(Play);
        _buttonOptions.onClick.AddListener(ShowOptions);
        _buttonQuit.onClick.AddListener(Quit);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowOptions()
    {
        Debug.Log("Options");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
