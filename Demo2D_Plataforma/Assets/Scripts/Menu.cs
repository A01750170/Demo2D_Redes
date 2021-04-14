using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
*Controla el menu
*/
public class Menu : MonoBehaviour

{
    public Image imagenFondo;
    //cambiar escena
    private IEnumerator CambiarEscena(){
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("EscenaMapa");
    }
    public void IniciarJuego(){
        //FadeOut
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1,0.7f,true);
        StartCoroutine(CambiarEscena());
        //SceneManager.LoadScene("EscenaMapa");
    }

    public void SalirJuego(){
        Application.Quit();
    }
    
}
