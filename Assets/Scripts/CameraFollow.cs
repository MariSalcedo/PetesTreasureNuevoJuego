using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform quienEsElJugador;
    public float offset = 0f;

    // Update is called once per frame
    void Update()
    {
        //Nombre de la variable
        transform.position = new Vector3(quienEsElJugador.position.x + offset, quienEsElJugador.position.y + offset, transform.position.z);
    }
}