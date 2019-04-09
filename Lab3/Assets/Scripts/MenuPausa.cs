using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if(pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
    }
    public void Pausar()
    {
        transform.Find("Pausa").gameObject.SetActive(true);
        transform.Find("BotonReiniciar").gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        pausado = true;
    }

    public void Continuar()
    {
        transform.Find("Pausa").gameObject.SetActive(false);
        transform.Find("BotonReiniciar").gameObject.SetActive(true);x
        Time.timeScale = 1.0f;
        pausado = false;
    }
    public void Regresar(string escena)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(escena);
    }
    public void Reiniciar(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
