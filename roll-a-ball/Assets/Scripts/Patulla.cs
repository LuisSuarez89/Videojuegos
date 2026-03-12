using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
public class Patulla : MonoBehaviour
{
    
    public Transform player;

    private Vida vida;

    Transform posicionJugador;
    NavMeshAgent agente;

    Animator anim;
    public GameObject poder;

    private Vector3 pos1;
    private Vector3 pos2;

    private int destPoint = 0;
    public float speed = 6.0f;

    public ThirdPersonCharacter character { get; private set; } // the character we are controlling

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<ThirdPersonCharacter>();
        pos1 = new Vector3 (transform.position.x, transform.position.z+5.0f);
        pos2 = new Vector3 (transform.position.x, transform.position.z-5.0f);
        // print("Posicion "+transform.position);
        // print("Posicion "+pos1);
        // print("Posicion "+pos2);
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            float distancePlayer = Vector3.Distance(player.position, transform.position);
            float distancePoint1 = Vector3.Distance(pos1, transform.position);
            float distancePoint2 = Vector3.Distance(pos2, transform.position);
            //print("DistancePlayerance to player: " + distancePlayer);
            //print("Posicion actual: "+transform.position);
            //print("Posicion 1: "+pos1);
            if (distancePlayer <= 20)
            {
                //print("Persigue y ataca");
                posicionJugador = GameObject.FindGameObjectWithTag ("Jugador").transform;
                agente = GetComponent<NavMeshAgent>();
                agente.SetDestination (posicionJugador.position);
                character.Move(new Vector3(1,1,1)*speed, false, false);
                if (distancePlayer < 10)
                {
                    Animar();
                }
                
                if (distancePlayer < 3)
                {
                    vida = FindObjectOfType<Vida>();
                    vida.BajarVida();
                }
            }
            if (distancePlayer > 20)
            {
                //print("agente.remainingDistancePlayerance: "+agente.remainingDistancePlayerance);
                if (distancePoint1 < 0.05f) GotoNextPoint();
                if (distancePoint2 < 0.05f) GotoNextPoint();

            }
        }
    }

   void GotoNextPoint() {
            if ((destPoint%2)==0)
            {
                //print("Se mueve al 1");
                agente = GetComponent<NavMeshAgent>();
                agente.SetDestination (pos1);
                character.Move(new Vector3(1,1,1)*speed, false, false);
                
            }
            if ((destPoint%2)!=0)
            {
                //print("Se mueve al 2");
                agente = GetComponent<NavMeshAgent>();
                agente.SetDestination (pos2);
                character.Move(new Vector3(1,1,1)*speed, false, false);
                
            }

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint++;
            

        } 

        public void Animar(){
        StartCoroutine(Reiniciar());
    }  

    public IEnumerator Reiniciar(){
        anim.SetBool("isSendingMagic", true);
        yield return new WaitForSecondsRealtime(1.0f);
        poder.transform.position = transform.position;
        poder.SendMessage ("Shoot");
        anim.SetBool("isSendingMagic", false);
        yield return new WaitForSecondsRealtime(10.0f);
    }

}
}
