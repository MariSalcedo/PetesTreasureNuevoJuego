using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverInicio : MonoBehaviour
{
    public string CargarEscena;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(CargarEscena);
        }
    }
}
