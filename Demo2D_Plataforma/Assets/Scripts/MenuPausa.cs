using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*Controlador dle menu pausa
*Autor: Erick Hernández Silva
*/

public class MenuPausa : MonoBehaviour
{
    private bool estaPausado; //true = pausa ; false = no pausa/jugando
    public GameObject pantallaPausa;
    public void Pausar(){
        estaPausado = !estaPausado; 
        //apaga o prende la pantalla 
        pantallaPausa.SetActive(estaPausado);
        //Escala de tiempo
        Time.timeScale = estaPausado ? 0 : 1;
    }
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Pausar();
        }
    }

     
}
