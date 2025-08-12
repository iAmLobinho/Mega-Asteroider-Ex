using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 25f;
    public float spawnRadius = 15f;
    public Vector2 asteroidSpeedRange = new Vector2(1f, 2f);
    public float tamanho = 1f;

    private Transform player;
    public AsteroidsGame gameManager;

    [Header("Comportamento")]
    public bool perseguePlayer = false;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
            player = playerGO.transform;
        else
            Debug.LogWarning("Player com tag 'Player' não encontrado na cena!");

        gameManager = FindObjectOfType<AsteroidsGame>();
        rb = GetComponent<Rigidbody2D>();

        if (asteroidPrefab != null && gameObject.name.Contains("Clone") == false)
            InvokeRepeating(nameof(SpawnAsteroid), 2f, spawnInterval);
    }

    void Update()
    {
        if (perseguePlayer && player != null)
        {
            Vector2 dir = ((Vector2)player.position - rb.position).normalized;
            rb.velocity = dir * Random.Range(asteroidSpeedRange.x, asteroidSpeedRange.y);
        }
    }

    public void SpawnAsteroid(Vector3? position = null, float size = 1f)
    {
        if (player == null || asteroidPrefab == null) return;

        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = position ?? (Vector2)player.position + direction * spawnRadius;

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        asteroid.transform.localScale = Vector3.one * size;

        Rigidbody2D rbAst = asteroid.GetComponent<Rigidbody2D>();
        if (rbAst != null)
        {
            Vector2 moveDir = ((Vector2)player.position - spawnPosition).normalized;
            rbAst.velocity = moveDir * Random.Range(asteroidSpeedRange.x, asteroidSpeedRange.y);
        }

        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
        {
            asteroidScript.gameManager = gameManager;
            asteroidScript.tamanho = size;

            // Define aleatoriamente se este asteroide vai seguir o player
            asteroidScript.perseguePlayer = Random.value < 0.3f; // 30% chance
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void Quebrar()
    {
        if (tamanho > 0.3f)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 pos = transform.position + (Vector3)Random.insideUnitCircle * 0.5f;
                GameObject fragmento = Instantiate(asteroidPrefab, pos, Quaternion.identity);
                float novoTamanho = tamanho * 0.5f;

                fragmento.transform.localScale = Vector3.one * novoTamanho;

                Rigidbody2D rb = fragmento.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Random.insideUnitCircle.normalized * Random.Range(asteroidSpeedRange.x, asteroidSpeedRange.y);
                }

                Asteroid fragScript = fragmento.GetComponent<Asteroid>();
                if (fragScript != null)
                {
                    fragScript.gameManager = gameManager;
                    fragScript.tamanho = novoTamanho;
                    fragScript.perseguePlayer = Random.value < 0.3f; // Herda comportamento
                }
            }
        }
        

        
}
}