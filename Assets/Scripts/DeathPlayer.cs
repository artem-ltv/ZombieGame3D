using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathPlayer: MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private Animation _deathScreenAnimation;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnEnable()
    {
        _player.PlayerDie += BlockPlayerMovement;
        _player.PlayerDie += ShowDeathScreen;
        _player.PlayerDie += StartCoroutineGoToMenu;
    }
    private void OnDisable()
    {
        _player.PlayerDie -= BlockPlayerMovement;
        _player.PlayerDie -= ShowDeathScreen;
        _player.PlayerDie -= StartCoroutineGoToMenu;
    }

    private void BlockPlayerMovement() =>
        _playerMovement.enabled = false;

    private void ShowDeathScreen()
    {
        _deathScreen.SetActive(true);
        _deathScreenAnimation.Play();
    }

    private void StartCoroutineGoToMenu() =>
        StartCoroutine(GoToMenu(5f));

    private IEnumerator GoToMenu(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
    
}
