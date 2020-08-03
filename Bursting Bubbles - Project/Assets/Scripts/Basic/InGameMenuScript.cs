using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuScript : MainMenuScript
{
    [SerializeField] private static bool _gameIsPaused = false;

    [SerializeField] private GameObject _inGameMenuUI;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.Find("AudioManager");

        /*if(_audioManager == null)
        {
            Debug.Log("No object was found in 'InGameMenu'");
            Destroy(gameObject);
        }*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                _Pause();
            }
        }
    }

    public void Resume()
    {
        _inGameMenuUI.SetActive(false);
        _gameCanvas.SetActive(true);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        _gameIsPaused = false;
        Destroy(_audioManager);
        SceneManager.LoadScene(0);
    }

    private void _Pause()
    {
        _inGameMenuUI.SetActive(true);
        _gameCanvas.SetActive(false);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }
}
