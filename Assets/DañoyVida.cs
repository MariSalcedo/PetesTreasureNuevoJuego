/*
DESARROLLADOR: Estefannia Lizzet Garcia Zepeda
ASIGNATURA: Estructura de Datos
PROFESOR: Josue Israel Rivas Diaz
DESCRIPCIÓN: Este script tiene la funcion de contener un arreglo de las vidas y que cada vez que Pete reciba un daño
    por una bala de cañon, bomba o alimento podrido, este pierda una vida.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoyVida : MonoBehaviour
{
    public GameObject[]VIDAS;
    public int vidas = 5;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Jugador")
        {
            DañoVIDA();
            if(vidas < 1)
            {
                Destroy(VIDAS[0].gameObject);
                Debug.Log("Perdiste");
            }
        }
    }

    private void DañoVIDA()
    {
        vidas--;
        if(vidas < 5)
             {
                Debug.Log("Ouch");
                Destroy(VIDAS[4].gameObject);
             }
    }
}
