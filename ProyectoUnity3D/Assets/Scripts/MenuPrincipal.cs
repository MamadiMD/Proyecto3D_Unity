using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject instructionMenu;
    public GameObject mainMenu;

    public void OpenInstructions()
    {
        mainMenu.SetActive(false);
        instructionMenu.SetActive(true);
    }

    public void OpenMain()
    {
        instructionMenu.SetActive(false);
        mainMenu.SetActive(true);
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
