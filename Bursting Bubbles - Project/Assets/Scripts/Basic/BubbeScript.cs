using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BubbeScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameDataCollector _gameData;

    [SerializeField] private float _forceMultipler = 3;
    [SerializeField] private float _randomFactor = 4;
    [SerializeField] private float _scaleMultipler = 0.20f;

    private float _force;
    [SerializeField] private float _difficultyFactor = 1;

    private void Awake()
    {
        _rb = FindObjectOfType<Rigidbody2D>();
        _gameData = GameObject.Find("GameManager").GetComponent<GameDataCollector>();

        if(_rb == null || _gameData == null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _difficultyFactor = _GetDifficultyFactor();
        _rb.gravityScale = Random.Range(_rb.gravityScale - 0.01f, _rb.gravityScale + 0.01f);
        _rb.gravityScale -= (0.01f * _difficultyFactor);

        _forceMultipler = Random.Range(_forceMultipler - 1, _forceMultipler + 1);
        _randomFactor = Random.Range(_randomFactor - 1, _randomFactor + 1);
        _scaleMultipler = Random.Range(_scaleMultipler - 0.05f, _scaleMultipler + 0.05f);
    }

    private void FixedUpdate()
    {
        _GenerateForce();
        _AddForce();
        _ChangeScale();
    }

    private float _GetDifficultyFactor()
    {
        return (_gameData.GetDifficultyLevel());
    }

    private void _GenerateForce()
    {
        _force = Random.Range(-_randomFactor, _randomFactor);
        _force *= _forceMultipler * _difficultyFactor;
    }

    private void _AddForce()
    {
        Vector2 vector;
        vector = new Vector2(_force, 0);

        _rb.AddForce(vector);
       
    }

    private void _ChangeScale()
    {
        transform.localScale *= 1 + (0.01f * _scaleMultipler);
    }
}
