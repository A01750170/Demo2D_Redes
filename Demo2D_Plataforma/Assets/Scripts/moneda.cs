using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class moneda : MonoBehaviour
{
    public AudioSource efectoMoneda;
   //la moneda colisionó con otro objeto
   public ParticleSystem hit;
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.CompareTag("Player")){
           //recolectar
           //print(message:"recolectando...");
           //dejar de dibujar moneda
           hit.Play();
           efectoMoneda.Play();
           GetComponent<SpriteRenderer>().enabled = false;
           //prender la explosión
           //moneda.transform.hijo del tranform  (explosion).explosion.se activa
           gameObject.transform.GetChild(0).gameObject.SetActive(true);
           Destroy(gameObject,0.5f);
           //Contar monedas
           SaludPersonaje.instance.monedas += 25;
           HUD.instance.ActualizarMonedas();
       }
   }
}
