using UnityEngine;

public class GameDataCollector : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _lives;
    [SerializeField] private float _difficulty;

    public void AddScore(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        return _score;
    }

    public void TakeDamage(int damage)
    {
        _lives -= damage;
    }

    public int GetLivesLeft()
    {
        return _lives;
    }

    public void ChangeDifficulty()
    {
        _difficulty = (float)(1 + (_score * 0.1));
    }

    public float GetDifficultyLevel()
    {
        return _difficulty;
    }
}
