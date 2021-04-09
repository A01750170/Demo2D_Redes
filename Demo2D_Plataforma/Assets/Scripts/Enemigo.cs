using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Networking;
public class Enemigo : MonoBehaviour
{
    public AudioSource efectoEnemigo;
    public struct Jugador{
        public string nombreUsuario;
    }
    public Jugador datos;
    private IEnumerator SubirRegistroJSON()
   {
    datos.nombreUsuario = Red.nombreUsuarioJugador;
    //Encapsular los datos que suben a la red
    WWWForm forma = new WWWForm();
    //Se crea el JSON llamado "datosJSON"
    forma.AddField("datosJSON", JsonUtility.ToJson(datos));
    //se envía el request
    UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/FinalizarJuego",forma);
    yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
    if (request.result != UnityWebRequest.Result.Success){// 200
        StartCoroutine(SubirRegistroJSON());
        print(request.result.ToString());
    }
}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            efectoEnemigo.Play();
            //Descontar una vida
            SaludPersonaje.instance.vidas--;
            //Actualizar corazones
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0){
                StartCoroutine(SubirRegistroJSON());
                SceneManager.LoadScene("Registro");//Regresa al menu si pierde
                Destroy(other.gameObject,0.3f);
            }
        }
    }
}

