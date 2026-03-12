using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResistenciaPlayer : MonoBehaviour
{

    private Vida vida;
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
        vida = FindObjectOfType<Vida>();
        vida.BajarVida();
    }

    public void RegistrarImpacto (Vector3 puntoImpacto)
    {
        vida = FindObjectOfType<Vida>();
        vida.BajarVida();
    }
}
