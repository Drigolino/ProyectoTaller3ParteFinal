using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void NivelDos()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void NivelTres()
    {
        SceneManager.LoadScene("Nivel3");
    }
}
