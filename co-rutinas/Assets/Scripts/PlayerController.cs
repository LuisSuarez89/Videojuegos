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

    private int contador;

    private AudioSource audioRecoleccion;

    public Text textoContador;

    public GameObject CuboMovible;

    public GameObject CuboDesaparece;

    public GameObject CuboIntermitente;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Para obtener el sistema de particulas y detenerlo 
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();

        contador = 0;

        audioRecoleccion = GetComponent<AudioSource>();
        
        textoContador.text = "Contador: " + contador.ToString();

        StartCoroutine ("Movimiento");

        StartCoroutine("Desaparecer");

        StartCoroutine("Intermitente");
        

    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (other.gameObject.CompareTag ("Recolectable"))
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

            contador++;
            textoContador.text = "Contador: " + contador.ToString();

            audioRecoleccion.Play();

            if (contador >= 12)
            {
                //Cambio de escena: falta agregar un mecanismo de puntaje para que ocurra al recolectar todo
                SceneManager.LoadScene(1);
            }
        }
    }

    //Esto es una corutina
    public IEnumerator DetenerParticulas (ParticleSystem part){
        yield return new WaitForSecondsRealtime (3);
        part.Stop();
    }

    public IEnumerator Movimiento(){
        for(;;){
            if (Vector3.Distance (transform.position, CuboMovible.transform.position)<6f){
                CuboMovible.transform.position = 
                Vector3.Lerp (CuboMovible.transform.position, new Vector3 (Random.Range (-10.0f, 10.0f),0.97f, Random.Range (-10.0f,10.0f)),10f * Time.deltaTime);
            }
            yield return new WaitForSecondsRealtime (0.1f);
        }
    }

    public IEnumerator Desaparecer(){
        yield return new WaitForSecondsRealtime (10);
        Destroy(CuboDesaparece.gameObject);
    }

    public IEnumerator Intermitente(){
        material = CuboIntermitente.GetComponent<Renderer>().material;
        for ( ;;)
        {
            material.color = Color.green;
            CuboIntermitente.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime (3);
            CuboIntermitente.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime (5);

            material.color = Color.black;
            CuboIntermitente.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime (3);
            CuboIntermitente.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime (5);

            material.color = Color.red;
            CuboIntermitente.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime (3);
            CuboIntermitente.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime (5);

            material.color = Color.white;
            CuboIntermitente.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime (3);
            CuboIntermitente.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime (5);

            material.color = Color.blue;
            CuboIntermitente.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime (3);
            CuboIntermitente.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime (5);
        }
        
    }
}
