using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameDataCollector _gameData;
    [SerializeField] private Text _ScoreText;
    [SerializeField] private Text _LivesText;

    private void Update()
    {
        _ScoreText.text = _gameData.GetScore().ToString();
        _LivesText.text = _gameData.GetLivesLeft().ToString();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;

        SceneManager.LoadScene(0);
    }
}
