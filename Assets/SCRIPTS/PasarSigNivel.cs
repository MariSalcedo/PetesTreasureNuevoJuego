using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarSigNivel : MonoBehaviour
{
    //Cuando Pete choque con este objeto, lo llevara al siguiente nivel.
    public string IrAlNivel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(IrAlNivel);
        }
    }
}
