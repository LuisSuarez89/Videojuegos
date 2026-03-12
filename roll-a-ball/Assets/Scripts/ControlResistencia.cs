using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResistencia : MonoBehaviour
{
    public int resistencia;
    public GameObject destruccion;

    private Puntaje puntaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("colision con objeto");
        resistencia--;
        if (resistencia < 1)
        {
            Instantiate(destruccion);
            Destroy (transform.gameObject);
            puntaje = FindObjectOfType<Puntaje>();
            puntaje.Puntuar("Recolectable");
        }
    }

    public void RegistrarImpacto (Vector3 puntoImpacto)
    {
        resistencia--;
        if (resistencia < 1)
        {
            Instantiate(destruccion);
            Destroy (transform.gameObject);
            puntaje = FindObjectOfType<Puntaje>();
            puntaje.Puntuar("Recolectable");
        }
    }
}
