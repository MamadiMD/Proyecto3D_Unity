using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    public void OpenMain()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
