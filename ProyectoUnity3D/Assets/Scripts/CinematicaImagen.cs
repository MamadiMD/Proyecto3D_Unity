using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicaImagen : MonoBehaviour
{
    public int contadorGolpes = 0;

    public Camera camOrbital;
    public Camera camCanvas;

    [Header("UI")]
    public GameObject canvasFinal;
    public TMP_Text textoPerfecto;
    public TMP_Text textoBien;
    public TMP_Text textoRegular;

    public TMP_Text textoFinal;

    public AudioSource audioSource;
    public AudioClip hoyo;


    private void Start()
    {
        canvasFinal.SetActive(false);
        textoPerfecto.gameObject.SetActive(false);
        textoBien.gameObject.SetActive(false);
        textoRegular.gameObject.SetActive(false);
        textoFinal.gameObject.SetActive(false);
        camOrbital.enabled = true;
        camCanvas.enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("AgujeroFinal"))
        {
            audioSource.PlayOneShot(hoyo);
            canvasFinal.SetActive(true);
            TMP_Text elegido = null;
            elegido = textoFinal;
            elegido.gameObject.SetActive(true);
            SceneManager.LoadScene("MenuInicio");
        }
        
        if (collision.collider.CompareTag("Agujero"))
    {
        audioSource.PlayOneShot(hoyo);
        CambiarACamaraCanvas();
        StartCoroutine(MostrarResultado());
    }
    }

    IEnumerator MostrarResultado()
    {
        canvasFinal.SetActive(true);

        TMP_Text elegido = null;
        if (contadorGolpes <= 8)
            elegido = textoPerfecto;
        else if ( contadorGolpes > 8 && contadorGolpes <= 16)
            elegido = textoBien;
        else
            elegido = textoRegular;

        elegido.gameObject.SetActive(true);

        elegido.alpha = 0;
        float tiempo = 0;

        while (tiempo < 2f)
        {
            tiempo += Time.deltaTime;
            elegido.alpha = Mathf.Lerp(0, 1, tiempo / 2f);
            yield return null;
        }

        int indiceActual = SceneManager.GetActiveScene().buildIndex;

        int indiceSiguiente = indiceActual + 1;

        SceneManager.LoadScene(indiceSiguiente);
    }

    void CambiarACamaraCanvas()
{
    camOrbital.enabled = false;
    camCanvas.enabled = true;
}
}
