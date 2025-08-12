using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrbManager : MonoBehaviour
{
    [Header("Configuração de Orbs")]
    public GameObject orbPrefab;
    public Vector2 areaMin = new Vector2(-100, -100);
    public Vector2 areaMax = new Vector2(100, 100);
    public int orbsPorFrame = 25;

    private static int totalColetados = 0;
    private static string dificuldadeAtual = "Super fácil já ativa";
    private int orbsInstanciados = 0;

    private Transform containerOrbs;

    // Faixas de dificuldade (limites superiores)
    private int[] limites = new int[] { 15, 40, 100, 105, 155, 215, 240, 250 };

    void Start()
    {
        containerOrbs = new GameObject("Orbs").transform;
        LiberarOrbsSeNecessario();
    }

    public static void RegistrarColeta()
    {
        totalColetados++;
        AtualizarDificuldade();
        FindObjectOfType<OrbManager>().LiberarOrbsSeNecessario(); // Gera mais orbs se necessário
    }

    void LiberarOrbsSeNecessario()
    {
        foreach (int limite in limites)
        {
            if (totalColetados < limite && orbsInstanciados < limite)
            {
                int quantidadeParaInstanciar = limite - orbsInstanciados;
                StartCoroutine(SpawnOrbsGradualmente(quantidadeParaInstanciar));
                orbsInstanciados = limite;
                break;
            }
        }
    }

    IEnumerator SpawnOrbsGradualmente(int quantidade)
    {
               
        for (int i = 0; i < quantidade; i++)
        {
     Vector2 pos = new Vector2(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y)
            );
         Instantiate(orbPrefab, pos, Quaternion.identity, containerOrbs);


            if ((i + 1) % orbsPorFrame == 0)
                yield return null;
        }
    }

    static void AtualizarDificuldade()
    {
        if (totalColetados >= 240) dificuldadeAtual = "Big Bang";
        else if (totalColetados >= 215) dificuldadeAtual = "Buraco Negro";
        else if (totalColetados >= 155) dificuldadeAtual = "Extreme";
        else if (totalColetados >= 105) dificuldadeAtual = "Difícil";
        else if (totalColetados >= 100) dificuldadeAtual = "Avançada";
        else if (totalColetados >= 40) dificuldadeAtual = "Normal";
        else if (totalColetados >= 15) dificuldadeAtual = "Fácil";
        else dificuldadeAtual = "Super fácil já ativa";
    }

    // Propriedades públicas para acesso externo
    public static int TotalColetados => totalColetados;
    public static string DificuldadeAtual => dificuldadeAtual;
}