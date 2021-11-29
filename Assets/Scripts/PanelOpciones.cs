using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelOpciones : MonoBehaviour
{
    public GameObject opcionsPanel;

    public void PanelesOpciones()
    {
        Time.timeScale = 0;//Para el tiempo
        opcionsPanel.SetActive(true);
    }
    public void Return()
    {
        Time.timeScale = 1;
        opcionsPanel.SetActive(false);
    }
    public void Ajustes()
    {
        //sonido
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Escenario_Inicial");
    }
    public void Salir()
    {
        Application.Quit();//Solo funciona en el ejecutable
    }
    
}
