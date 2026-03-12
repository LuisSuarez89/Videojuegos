using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    private int vida;
    public Text textoVida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        textoVida.text = "Vida: " + vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BajarVida()
    {
        if (vida > 1)
        {
            vida--;
            textoVida.text = "Vida: " + vida.ToString();
        }
        else
        {
            SceneManager.LoadScene("proyectoFinal1");
        }
        
    }

    public void SubirVida()
    {
        if (vida <= 80)
        {
            vida += 20;
            textoVida.text = "Vida: " + vida.ToString();
        }
        
    }
}
