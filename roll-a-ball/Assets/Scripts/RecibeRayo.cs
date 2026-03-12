using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibeRayo : MonoBehaviour
{
    private bool rota = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (rota)
        {
            transform.Rotate (new Vector3 (60,60,60)*Time.deltaTime);
        }
    }

    public void RegistrarImpacto (Vector3 puntoImpacto)
    {
        rota = !rota;
    }
}
