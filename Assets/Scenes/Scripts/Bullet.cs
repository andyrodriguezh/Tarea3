using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    private GameManager gameManager;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            if (gameManager != null)
            {
                gameManager.AddHit(); // Suma puntaje
            }
            Destroy(collision.gameObject); // Destruye el Target
            Destroy(gameObject);           // Destruye la Bullet
        }
        else
        {
            Destroy(gameObject); // Si choca con otra cosa, solo destruye la bala
        }
    }
}
