using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPickup : MonoBehaviour
{
    [Header("Efeitos (opcional)")]
    public AudioClip coletaSound;
    // public ParticleSystem coletaVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Registrar coleta no gerenciador
            OrbManager.RegistrarColeta();

            // Toca som se existir
            if (coletaSound)
                AudioSource.PlayClipAtPoint(coletaSound, transform.position);

            // Instancia partícula e destrói após o tempo
            // if (coletaVFX)
            // {
            //     ParticleSystem vfx = Instantiate(coletaVFX, transform.position, Quaternion.identity);
            //     Destroy(vfx.gameObject, vfx.main.duration);
            // }

            // Destroi o orb
            Destroy(gameObject);
        }
    }
}