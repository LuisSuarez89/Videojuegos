using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moverse : MonoBehaviour
{
    private bool impacta = false;
    Transform cuboVerde;
    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (impacta)
        {
            cuboVerde = GameObject.FindGameObjectWithTag ("RecolectableVerde").transform;
            agente = GetComponent<NavMeshAgent>();
            agente.SetDestination (cuboVerde.position);

            if (transform.position.x == cuboVerde.position.x && transform.position.z == cuboVerde.position.z)
            {
                Destroy (transform.gameObject);
            }
        }

        
    }

    void OnParticleCollision(GameObject other)
    {
        impacta = true;
    }
}
