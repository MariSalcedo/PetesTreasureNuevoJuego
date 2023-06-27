using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoGO : MonoBehaviour
{
    //Cuando Pete choque con este objeto, lo llevara a la escena GameOver.
    public string CargarEscenaDaño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(CargarEscenaDaño);
        }
    }
}
