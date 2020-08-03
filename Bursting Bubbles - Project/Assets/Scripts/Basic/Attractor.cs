using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CollisionHandler _collisionHandler; 
    [SerializeField] private GameObject _collidedObject;

    private void Awake()
    {
        _rb = FindObjectOfType<Rigidbody2D>();
        _collisionHandler = this.gameObject.GetComponent<CollisionHandler>();

        if (_rb == null || _collisionHandler == null)
        {
            Destroy(gameObject);
        }

        _collidedObject = _collisionHandler.GiveCollidedObject();
    }

    void FixedUpdate()
    {
        if(_collidedObject == null)
        {
            return;
        }

        Vector2 vector;
        vector = new Vector2(transform.position.x - _collidedObject.gameObject.transform.position.x, transform.position.y - _collidedObject.gameObject.transform.position.y);
        _rb.velocity += (vector);
    }
}
