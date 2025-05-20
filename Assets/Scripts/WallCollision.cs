using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollision : MonoBehaviour
{
    private PlayerMovement player;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Kena Dinding! Reset posisi.");
            player.ResetPosition();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Menang!");
            // Bisa tambahkan load scene berikutnya atau tampilkan UI Menang
        }
    }
}
