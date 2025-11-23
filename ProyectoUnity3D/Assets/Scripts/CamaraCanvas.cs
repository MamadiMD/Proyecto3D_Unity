using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraCanvas : MonoBehaviour
{
    // Botón para ir al menú principal
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MenuInicio"); 
    }
}
