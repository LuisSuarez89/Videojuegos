using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistenciaEnemigo : MonoBehaviour
{
    public int resistencia;
    public GameObject destruccion;

    private Puntaje puntaje;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        resistencia--;
        Debug.Log("Ataque a enemigo");
        
            
        if (resistencia < 1)
        {
            StartCoroutine(Muere());
            Destroy (transform.gameObject);
            puntaje = FindObjectOfType<Puntaje>();
            puntaje.Puntuar("Enemigo");
            Instantiate(destruccion);
            print("Resistencia enemigo: "+resistencia);
        }
    }

    public void RegistrarImpacto (Vector3 puntoImpacto)
    {
        resistencia--;
        if (resistencia < 1)
        {
            StartCoroutine(Muere());
            Instantiate(destruccion);
            Destroy (transform.gameObject);
            puntaje = FindObjectOfType<Puntaje>();
            puntaje.Puntuar("Enemigo");
            print("Resistencia enemigo: "+resistencia);
        }
    }

    public IEnumerator Muere(){
        print("Animacion de morir");
        anim.SetBool("Die", true);
        yield return new WaitForSecondsRealtime(2.0f);
    }
}
