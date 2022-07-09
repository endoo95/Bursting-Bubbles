using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour
{
    private Vector2 _screenWidthBounds;

    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _leftWall;
    private void Awake()
    {
        _screenWidthBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 0.5f, Camera.main.transform.position.z));

        _rightWall.transform.position = new Vector2(_screenWidthBounds.x, _screenWidthBounds.y);
        _leftWall.transform.position = new Vector2(_screenWidthBounds.x * -1f, _screenWidthBounds.y);
    }
}
