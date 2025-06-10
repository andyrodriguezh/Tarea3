using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager; // Asignar desde el Inspector
    public GameObject bulletPrefab;
    public Transform firingPoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameManager != null && gameManager.TryShoot())
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.forward * bulletSpeed;
        }
    }
}