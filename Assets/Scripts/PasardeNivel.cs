using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasardeNivel : MonoBehaviour
{
    //Script para pasar de nivel sin necesidad de presionar una tecla, mas bien al chocar con el objeto "puerta"
    public string AQueNivelIr;
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(AQueNivelIr);
        }
    }
}