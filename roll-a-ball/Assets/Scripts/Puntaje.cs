using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{

    private int contador;
    public Text textoContador;
    
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        textoContador.text = "Puntaje: " + contador.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Puntuar (string tag)
    {
        if (tag == ("Recolectable"))
        {
            contador++;
            textoContador.text = "Puntaje: " + contador.ToString();
        }
        if (tag == ("Enemigo"))
        {
            contador += 2;
            textoContador.text = "Puntaje: " + contador.ToString();
        }
    }
}
