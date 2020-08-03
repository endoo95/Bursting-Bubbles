using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameDataCollector _gameData;
    [SerializeField] private GameManager _gameManager;

    private GameObject collidedObject;

        private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObject = collision.gameObject;
    }

    private void Awake()
    {
        _rb = FindObjectOfType<Rigidbody2D>();
        _gameData = GameObject.Find("GameManager").GetComponent<GameDataCollector>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_rb == null || _gameData == null || _gameManager == null)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        _DoIColide();
    }

    private void OnMouseDown()
    {
        //Debug.Log(name + " was clicked.");
        IAmHit();
    }

    private void _DoIColide()
    {
        if (collidedObject == null)
        {
            return;
        }

        string tag;
        tag = collidedObject.tag;

        switch (tag)
        {
            case "Wall":
                _CollideRecoil();
                break;
            case "ObjectDestroyer":
                _gameData.TakeDamage(1);
                _IsItEnd();
                Destroy(gameObject);
                break;
            case "Bubble":
                _CollideAttract();
                break;
            default:
                break;
        }
        collidedObject = null;
    }

    private void _CollideRecoil()
    {
        Vector2 vector;
        vector = new Vector2(transform.position.x - collidedObject.gameObject.transform.position.x, 0);

        _rb.AddForce(vector*500);
    }

    private void _CollideAttract()
    {
        if(this.gameObject.GetComponent<Attractor>() != null)
        {
            return;
        }

        Debug.Log("Collide!");
        this.gameObject.AddComponent<Attractor>();
    }

    public void IAmHit()
    {
        _gameData.AddScore(1);
        _gameData.ChangeDifficulty();
        Destroy(gameObject);
    }

    public GameObject GiveCollidedObject()
    {
        return collidedObject.gameObject;
    }

    private void _IsItEnd()
    {
        if((_gameData.GetLivesLeft() - 0.1f) >= 0)
        {
            return;
        }

        _gameManager.GameOver();
    }
}
