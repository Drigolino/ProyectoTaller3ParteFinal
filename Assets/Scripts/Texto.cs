﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : MonoBehaviour
{
    string frase = "Felicidades caballero superaste el Nivel Uno sigue ¡asi! ";
    public Text texto;    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
        
    }

    
        IEnumerator Reloj()
        {
            foreach (char caracter in frase)
            {
                texto.text = texto.text + caracter;
                yield return new WaitForSeconds(0.1f);
            }
        }
    
}
