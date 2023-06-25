using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeclaCargarEscena : MonoBehaviour
{
    //Script para cambiar de escena presionando una tecla
    public string CualEscenaCargar;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(CualEscenaCargar);
        }
    }
}
