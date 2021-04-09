using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public Text textoMonedas;
    public static HUD instance;
    private void Awake()
    {
        instance = this;
    }
    public void ActualizarVidas(){
        int vidas = SaludPersonaje.instance.vidas;
        if (vidas == 2){
            imagen3.enabled = false;
        }
        if (vidas == 1){
            imagen2.enabled = false;
        }
    }
    public void ActualizarMonedas(){
        textoMonedas.text = SaludPersonaje.instance.monedas.ToString();
    }
}
