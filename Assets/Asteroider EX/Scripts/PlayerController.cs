using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public float rotationSpeed = 200f;
    public float moveForce = 5f;
    public GameObject bulletPrefab;

    public int vidas = 3;
    public TMP_Text textoVida;
    public int orbs = 0;
    public TMP_Text textoOrbs;

    public float tempoInvencivel = 0f;
    public bool invencivel = false;

    private AsteroidsGame gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<AsteroidsGame>();

        AtualizarVidaHUD();
        AtualizarOrbsHUD();
    }

    void Update()
    {
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotation);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * moveForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (invencivel)
        {
            tempoInvencivel += Time.deltaTime;
            if (tempoInvencivel >= 3f)
            {
                invencivel = false;
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            if (rbBullet != null)
            {
                rbBullet.velocity = transform.up * 10f;
            }
        }
    }

    public void TomarDano(int dano = 1)
    {
        if (!invencivel)
        {
            vidas -= dano;
            AtualizarVidaHUD();

            invencivel = true;
            tempoInvencivel = 0f;

            if (vidas <= 0)
            {
                Morte();
            }
        }
    }

    void AtualizarVidaHUD()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vidas: " + vidas;
        }
    }

    void AtualizarOrbsHUD()
    {
        if (textoOrbs != null)
        {
            textoOrbs.text = "Orbs: " + orbs;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Orbs"))
        {
            orbs++;
            AtualizarOrbsHUD();
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Asteroid"))
        {
            TomarDano(1);
            Destroy(col.gameObject); // Garante que o asteroide seja destruído
        }
        else if (col.CompareTag("Vida"))
        {
            if (vidas < 3)
            {
                vidas++;
                AtualizarVidaHUD();
            }
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Limbo"))
        {
            Morte();
        }
    }

    void Morte()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
}