using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject menuPause;
    bool pausado = false;

    public AudioClip musicaFundo;
    public AudioClip musicaPause;

    public void RetomarJogo()
    {
        pausado = false;
        menuPause.SetActive(pausado);
        Time.timeScale = 1f;
   	GetComponent<AudioSource>().Pause();
        GetComponent<AudioSource>().clip = musicaFundo;
        GetComponent<AudioSource>().Play();
    }

    public void IrMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pausado = !pausado;
            
            menuPause.SetActive(pausado);
            
            if (pausado)
            {
                Time.timeScale = 0f;
                GetComponent<AudioSource>().Pause();
                GetComponent<AudioSource>().clip = musicaPause;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                Time.timeScale = 1f;
                GetComponent<AudioSource>().Pause();
                GetComponent<AudioSource>().clip = musicaFundo;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}