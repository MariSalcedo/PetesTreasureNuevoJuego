using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{

    // Variables para caminar
    private Rigidbody2D CuerpoDelJugador;
    private Animator AnimatorDelJugador;
    private bool EstaCaminandoEnElEspacio;
    private float speed = 3.5f;

    // Variables para saltar
    public LayerMask CapaDePiso;
    public Transform SensorParaPiso;
    public float FuerzaDeSalto;
    private bool EstaEnElPiso;
    private float RadioDelSensor = 0.07f;


    // Start is called before the first frame update. Carga cuando se abre la escena, solo 1 vez.
    void Start()
    {
        //Agarrar - obtener un componente del Inspector.
        CuerpoDelJugador = GetComponent<Rigidbody2D>();
        AnimatorDelJugador = GetComponent<Animator>();
    }


    //Utilizar cosas del Physics2D
    void FixedUpdate()
    {
        // OverlapCircle: Detecta cuando un grupo de objetos está chocando con otro.
        EstaEnElPiso = Physics2D.OverlapCircle(SensorParaPiso.position, RadioDelSensor, CapaDePiso);
        AnimatorDelJugador.SetBool("saltando", !EstaEnElPiso);
    }


    // Update is called once per frame. Carga 60 veces por segundo
    void Update()
    {
        // Moverse a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Si presiono la tecla. Nombre del booleano de Unity.
            AnimatorDelJugador.SetBool("caminando", true);
            // Para que vuelva a rotar a la derecha después de mirar hacia la izquierda.
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            EstaCaminandoEnElEspacio = true;
            speed = 3.5f;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Si dejo de apretar la tecla. Nombre del booleano de Unity.
            AnimatorDelJugador.SetBool("caminando", false);
            EstaCaminandoEnElEspacio = false;
        }


        // Mover a la izquierda.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Si presiono la tecla. Nombre del booleano de Unity.
            AnimatorDelJugador.SetBool("caminando", true);
            // Para que rote hacia la izquierda
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            EstaCaminandoEnElEspacio = true;
            speed = -3.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Si dejo de presionar la tecla. Nombre del booleano de Unity.
            AnimatorDelJugador.SetBool("caminando", false);
            EstaCaminandoEnElEspacio = false;
        }


        // Caminar
        if (EstaCaminandoEnElEspacio)
        {
            CuerpoDelJugador.velocity = new Vector2(speed, CuerpoDelJugador.velocity.y);
        }
        

        // Saltar. Siempre que se añada algo al escenario para que el jugador pueda caminar sobre él, se le debe añadir a la capa piso.
        if (EstaEnElPiso)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CuerpoDelJugador.AddForce(new Vector2(0, FuerzaDeSalto));
            }
        }
    }
}