using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSalto : MonoBehaviour
{
    // Estas son las variables para saltar.
    public LayerMask capaDePiso;
    public Transform sensorParaPiso;
    public float fuerzaDeSalto;
    private bool estaEnElPiso;
    private float radioDelSensor = 0.07f;

    private Rigidbody2D cuerpoDelJugador;
    private Animator animatorDelJugador;
   

    // Start is called before the first frame update
    void Start()
    {
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
