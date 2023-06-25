using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    // Variables para caminar:
    private Rigidbody2D cuerpoDelJugador;
    private Animator animatorDelJugador;
    private bool estaCaminandoEnElEspacio;
    private float speed = 3.5f;

    // Estas son las variables para saltar.
    public LayerMask capaDePiso;
    public Transform sensorParaPiso;
    public float fuerzaDeSalto;
    private bool estaEnElPiso;
    private float radioDelSensor = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        // Carga en cuanto abre la escena, solo una vez.
        //Para "agarrar" u obtener un componente del Inspector.
        cuerpoDelJugador = GetComponent<Rigidbody2D>();
        animatorDelJugador = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // ¿Qué cosa del Physics2D voy a utilizar?
        // OverlapCircle: Detecta cuando un grupo de objetos está chocando con otro.
        estaEnElPiso = Physics2D.OverlapCircle(sensorParaPiso.position, radioDelSensor, capaDePiso);
        animatorDelJugador.SetBool("saltando", !estaEnElPiso);
    }

    // Update is called once per frame
    void Update()
    {
        // Carga 60 veces por segundo.
        // Para que el personaje pueda moverse hacia ambos lados.
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", true);
            // Para que vuelva a rotar a la derecha después de mirar hacia la izquierda.
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            estaCaminandoEnElEspacio = true;
            speed = 3.5f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", false);
            estaCaminandoEnElEspacio = false;
        }

        // Mover a la izquierda.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", true);
            // Para que rote hacia la izquierda
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            estaCaminandoEnElEspacio = true;
            speed = -3.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", false);
            estaCaminandoEnElEspacio = false;
        }

        // Código para caminar (Se mueve en horizontal).
        if (estaCaminandoEnElEspacio)
        {
            cuerpoDelJugador.velocity = new Vector2(speed, cuerpoDelJugador.velocity.y);
        }
        //else
        //{
        //    cuerpoDelJugador.velocity = new Vector2(0f, cuerpoDelJugador.velocity.y);
        //}

        // Código para saltar
        // Siempre que se añada algo al escenario para que el jugador pueda caminar sobre él, se le debe añadir a la capa piso.
        if (estaEnElPiso)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                cuerpoDelJugador.AddForce(new Vector2(0, fuerzaDeSalto));
            }
        }
    }
}