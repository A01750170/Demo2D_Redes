using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
*Controla el menu
*/
public class Menu : MonoBehaviour
{
    //cambiar escena
    public void IniciarJuego(){
        SceneManager.LoadScene("EscenaMapa");
    }

    public void SalirJuego(){
        Application.Quit();
    }
    
}
