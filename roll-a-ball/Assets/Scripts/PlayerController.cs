using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //public float speed;
    private Rigidbody rb;
    public Transform particulas;
    private ParticleSystem systemaParticulas;
    private Vector3 posicion;
    private int acumulado;
    private AudioSource audioRecoleccion;
    public Text textoAcumulado;
    private int abiertos;

    private Vida vida;
    //public GameObject CuboMovible;
    Animator anim;
    public GameObject poder;
    public ParticleSystem poderPiso;
    // Start is called before the first frame update

    public GameObject sonidoDispara;
    public GameObject sonidoHaceMagia;
    public GameObject sonidoEnviaMagia;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Para obtener el sistema de particulas y detenerlo 
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        acumulado = 0;
        audioRecoleccion = GetComponent<AudioSource>();
        textoAcumulado.text = "Poderes: " + acumulado.ToString();
        //StartCoroutine ("Movimiento");
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Animar();
        }

        if (Input.GetButtonDown("Fire2") && acumulado > 1)
        {
            acumulado -- ;
            textoAcumulado.text = "Poderes: " + acumulado.ToString();
            LanzarPoder();
            
        }
    }
    //se debe escribir exactamente FixedUpdate ya que es de unity asi y se ejecuta una vez cada frame
    //Se ejecuta antes de Update
    void FixedUpdate(){
    //     float moveHorizontal = Input.GetAxis ("Horizontal");
    //     float moveVertical = Input.GetAxis ("Vertical");

    //     Vector3 movimiento = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    //     rb.AddForce (movimiento*speed);
    }

    //Metodo para activar acciones automaticas.
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("Cofre"))
        {
            //Localiza el sistema de particulas y lo inicia a reproducir.
             posicion = other.gameObject.transform.position;
             particulas.position = posicion;
             systemaParticulas = particulas.GetComponent<ParticleSystem>();
             systemaParticulas.Play();
            //Hace inactivo el objeto (Se oculta)
            other.gameObject.SetActive(false);
            //Destruye objeto y lo libera en la memoria
            Destroy(other.gameObject);
            //iniciamos corutina
            StartCoroutine (DetenerParticulas (systemaParticulas));
            
            vida = FindObjectOfType<Vida>();
            vida.SubirVida();
            
            acumulado += 10;
            textoAcumulado.text = "Poderes: " + acumulado.ToString();
            abiertos++;
            //audioRecoleccion.Play();
            if (abiertos >= 7)
            {
                //Cambio de escena: falta agregar un mecanismo de puntaje para que ocurra al recolectar todo
                SceneManager.LoadScene("proyectoFinal2");
            }
        }
    }

    //Esto es una corutina
    public IEnumerator DetenerParticulas (ParticleSystem part){
        yield return new WaitForSecondsRealtime (3);
        part.Stop();
    }

    //Corutina para cubo que se mueve aleatoriamente huyendo de jugador 
    // public IEnumerator Movimiento(){
    //     for(;;){
    //         if (Vector3.Distance (transform.position, CuboMovible.transform.position)<6f){
    //             CuboMovible.transform.position = 
    //             Vector3.Lerp (CuboMovible.transform.position, new Vector3 (Random.Range (-10.0f, 10.0f),0.97f, Random.Range (-10.0f,10.0f)),10f * Time.deltaTime);
    //         }
    //         yield return new WaitForSecondsRealtime (0.1f);
    //     }
    // }

    public void Animar(){
        StartCoroutine(Reiniciar());
    }

    public IEnumerator Reiniciar(){
        anim.SetBool("isSendingMagic", true);
        Instantiate(sonidoDispara);
        yield return new WaitForSecondsRealtime(1.0f);
        poder.transform.position = transform.position;
        poder.SendMessage ("Shoot");
        anim.SetBool("isSendingMagic", false);
    }

    public IEnumerator LanzaPoderCoRoutine()
    {
        anim.SetBool("LanzandoPoder", true);
        Instantiate(sonidoHaceMagia);
        yield return new WaitForSecondsRealtime(2.0f);
        Instantiate(sonidoEnviaMagia);
        poderPiso.Play();
        StartCoroutine(DetenerPoder());
        anim.SetBool("LanzandoPoder", false);
    }

    public void LanzarPoder()
    {
        StartCoroutine(LanzaPoderCoRoutine());
    }

    public IEnumerator DetenerPoder()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        poderPiso.Stop();
    }
}
