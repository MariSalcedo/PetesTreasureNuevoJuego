using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform quienEsElJugador;
    public float offset = 0f;

    public Vector2 minLim;
    public Vector2 maxLim;

    // Update is called once per frame
    void Update()
    {
        float targetX = quienEsElJugador.position.x + offset;
        float targetY = quienEsElJugador.position.y + offset;

        if (targetX < minLim.x)
        {
            targetX = minLim.x;
        }
        else if (targetX > maxLim.x)
        {
            targetX = maxLim.x;
        }
        if (targetY < minLim.y)
        {
            targetY = minLim.y;
        }
        else if (targetY > maxLim.y)
        {
            targetY = maxLim.y;
        }

        transform.position = new Vector3(targetX, targetY, transform.position.z);

        //Nombre de la variable
        //transform.position = new Vector3(quienEsElJugador.position.x + offset, quienEsElJugador.position.y + offset, transform.position.z);
    }
}