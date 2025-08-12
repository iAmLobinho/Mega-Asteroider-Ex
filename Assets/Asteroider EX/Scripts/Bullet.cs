using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f); // Limpa o tiro após 2s
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Asteroid"))
        {
            Asteroid a = col.GetComponent<Asteroid>();
            if (a != null)
            {
                a.Quebrar(); // Divide se possível
            }

            Destroy(gameObject); // Destroi o tiro
        }
    }
}