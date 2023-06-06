using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    // Variables para caminar:
    private Rigidbody2D cuerpoDelJugador;
    private Animator animatorDelJugador;
    private bool caminandoEnElEspacio;
    private float speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Carga en cuanto abre la escena, solo una vez.
        //Para "agarrar" u obtener un componente del Inspector.
        cuerpoDelJugador = GetComponent<Rigidbody2D>();
        animatorDelJugador = GetComponent<Animator>();
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
            caminandoEnElEspacio = true;
            speed = 3.5f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", false);
            caminandoEnElEspacio = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", true);
            // Para que rote hacia la izquierda
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            caminandoEnElEspacio = true;
            speed = -3.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Lleva el nombre del booleano de Unity.
            animatorDelJugador.SetBool("caminando", false);
            caminandoEnElEspacio = false;
        }
        if (caminandoEnElEspacio)
        {
            cuerpoDelJugador.velocity = new Vector2(speed, cuerpoDelJugador.velocity.y);
        }
    }
}