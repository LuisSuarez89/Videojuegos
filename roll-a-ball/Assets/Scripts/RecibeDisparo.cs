using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibeDisparo : MonoBehaviour
{
   private bool mueve = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (mueve)
        {
            transform.position = 
                Vector3.Lerp (transform.position, new Vector3 (Random.Range (-10.0f, 10.0f),0.97f, Random.Range (-10.0f,10.0f)),10f * Time.deltaTime);
                mueve = false;
        }
    }

    public void RegistrarImpacto (Vector3 puntoImpacto)
    {
        mueve = true;
    }
}
