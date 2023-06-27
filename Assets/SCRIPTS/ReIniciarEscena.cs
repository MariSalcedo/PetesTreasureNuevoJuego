using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReIniciarEscena : MonoBehaviour
{
    // Cargar la misma escena cuando Pete cae al vacio negro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //Ordena al SceneManager ubicar el nombre de la escena donde esta actualmente y volver a cargarla.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
