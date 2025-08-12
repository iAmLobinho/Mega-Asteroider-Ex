using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGame : MonoBehaviour
{
    [Header("Configurações do Jogo")]
    public int targetFPS = 60; // Limite de FPS para consistência
    
    public GameObject playerPrefab;
    public GameObject asteroidPrefab;
    public GameObject bulletPrefab;
    public int initialAsteroids = 5;
    public float spawnInterval = 2f;
    public float spawnRadius = 15f; // Raio para o spawn aleatório
    public Vector2 asteroidSpeedRange = new Vector2(1f, 3f);
    public float minAsteroidSize = 1f; // Tamanho mínimo para asteroides iniciais
    public float maxAsteroidSize = 1f; // Tamanho máximo para asteroides iniciais

    private GameObject player;
    private List<GameObject> asteroids = new List<GameObject>();


        void Awake()
{
    // Limita o FPS para evitar aceleração no Build
    Application.targetFrameRate = 60;

    // Garante que a física rode a 60Hz
    Time.fixedDeltaTime = 1f / 60f;
}
    void Start()
    {

        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        if (playerGO != null)
            player = playerGO;
        else if (playerPrefab != null)
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // Gera os asteroides iniciais
        for (int i = 0; i < initialAsteroids; i++)
        {
            SpawnInitialAsteroid();
        }

        // Começa a chamar o spawn periódico após 1 segundo, repetindo a cada 'spawnInterval'
        InvokeRepeating(nameof(SpawnInitialAsteroid), 1f, spawnInterval);
    }

    // Este método será chamado pelo InvokeRepeating e pelos asteroides iniciais
    void SpawnInitialAsteroid()
    {
        // Gera uma posição aleatória dentro do spawnRadius
        Vector3 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
        // Gera um tamanho aleatório
        float randomSize = Random.Range(minAsteroidSize, maxAsteroidSize);

        // Chama o método que realmente cria o asteroide com os parâmetros
        SpawnAsteroidAt(randomPosition, randomSize);
    }

    // Este método é usado para criar asteroides em posições e tamanhos específicos
    public void SpawnAsteroidAt(Vector3 position, float size)
    {
        GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
        asteroid.transform.localScale = Vector3.one * size;

        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            rb.velocity = dir * Random.Range(asteroidSpeedRange.x, asteroidSpeedRange.y);
        }

        Asteroid asteroidScript = asteroid.GetComponent<Asteroid>();
        if (asteroidScript != null)
            asteroidScript.gameManager = this; // Atribui a referência ao GameManager
            asteroidScript.tamanho = size; // Define o tamanho no script do asteroide

        asteroids.Add(asteroid);
    }

    // Este método é para dividir asteroides existentes
    public void SplitAsteroid(GameObject asteroid, float size)
    {
        if (size > 0.3f) // Condição para saber se o asteroide ainda pode se dividir
        {
            // Spawna dois novos asteroides menores na mesma posição
            SpawnAsteroidAt(asteroid.transform.position, size * 0.5f);
            SpawnAsteroidAt(asteroid.transform.position, size * 0.5f);
        }

        Destroy(asteroid); // Destrói o asteroide original
    }
}