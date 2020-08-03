using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _bubblePrefab;
    [SerializeField] private Transform _spawnTransform;

    [SerializeField] private float _timeBetwenBubbles;
    
    private int _spawnOffset = 0;
    private int _newOffset = 0;
    private float _spawnPoint;

    private void Start()
    {
        _spawnPoint = _spawnTransform.position.x;
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            _SpawnBubble();
            yield return new WaitForSeconds(_timeBetwenBubbles);

            if(_timeBetwenBubbles >= 0.7f)
            {
                _timeBetwenBubbles -= 0.01f;
            }
        }
    }

    private void _SpawnBubble()
    {
        while (_spawnOffset == _newOffset)
        {
            float offset;
            offset = (Random.Range(_spawnPoint - 5, _spawnPoint + 5));
            //Debug.Log(offset + " to " + _newOffset);

            _newOffset = Mathf.RoundToInt(offset);
        }

        _spawnOffset = _newOffset;

        Vector2 vector;
        vector = new Vector2(_spawnOffset, _spawnTransform.position.y);

        var newBubble = Instantiate(_bubblePrefab, vector, Quaternion.identity);
        newBubble.transform.parent = gameObject.transform;
    }
}
