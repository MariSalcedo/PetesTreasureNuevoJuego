using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject objetoMover;
    public float vel;
    public Transform puntoActual;
    public Transform[] puntos;
    public int puntoSeleccionado;

    void Start()
    {
        puntoActual = puntos[puntoSeleccionado];
    }

    void FixedUpdate()
    {
        //C�digo para hacer que el enemigo se mueva de lado a lado:
        //La posici�n del objeto a mover va a estar cambiando. Hacia d�nde se va a mover, va entre los par�ntesis.
        objetoMover.transform.position = Vector3.MoveTowards(objetoMover.transform.position, puntoActual.position, Time.deltaTime * vel);

        if (objetoMover.transform.position == puntoActual.position)
        {
            puntoSeleccionado += 1;
            //Longitud de un Array determinado.
            if(puntoSeleccionado == puntos.Length)
            {
                puntoSeleccionado = 0;
            }
            puntoActual = puntos[puntoSeleccionado];
        }
    }
}