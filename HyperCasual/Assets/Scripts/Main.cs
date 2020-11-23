using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _loseScreen;
    private float _timeScale;

    public void ReloadLevel()
    {
        Pause(1f, true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseOn()
    {
        Pause(0f, false);
        _audioSource.Pause();
    }
    public void PauseOff()
    {
        Pause(1f, true);
        _audioSource.Play();
    }
    public void LoseScreen()
    {
        Pause(0f, false);
        _loseScreen.SetActive(true);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Pause(float timeScale, bool player)
    {
        _timeScale = timeScale;
        Time.timeScale = timeScale;
        _playerController.enabled = player;
    }
    
}
