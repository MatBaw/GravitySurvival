using UnityEngine;

public class Comet : MonoBehaviour
{
    public float speed = 5f;                       // prędkość komety
    public Vector2 moveDirection = Vector2.down;   // kierunek ruchu ustawienie tego w spawner

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        moveDirection = moveDirection.normalized;
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;

        // jeśli kometa przeleciała to usuwamy
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
