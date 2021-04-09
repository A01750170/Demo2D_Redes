using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //Para red. UnityWebRequest
using Newtonsoft.Json; //jSON CONVERT
using UnityEngine.SceneManagement;
/*
* Registra un usuario haciendo uso de una solicitud GET
* a través de NodeJS para insertar los datos en una base de datos de SQL Express
* Autor: Erick Hernandezx SIlva
*/

public class Red : MonoBehaviour
{
   public DateTime Today { get; }
   public static string nombreUsuarioJugador;
   //Campos con la información usuario y password
   public Text textoUsuarioRegistro;
   public Text textoPasswordRegistro;
   public Text textoUsuarioInicio;
   public Text textoPasswordInicio;
   
   public Text textoCorreo;
   //Variable para guardar el resultado de la operación
   public Text resultado;

   //Se declara la estructura que guarda los datos del usuario
   public struct DatosUsuario{
      public string nombreUsuario;
      public string clave;
      public string correo;
      public string fechaInicioJuego;
      public string fechaFinalizacionJuego;
      public string fechaRegistro;
   }
   //Estructura que guarda los datos del usuario
   public DatosUsuario datos;

    public void RegistrarURL(){ //Metodo asociado al botón
      //Concurrente
      StartCoroutine(SubirRegistroURL()); //Paralelo
   }

   //Sube los datos en la URL con una peticion GET :D.
   private IEnumerator SubirRegistroURL()
   {
      string cadena = "http://localhost:8080/usuario/registro" + textoUsuarioRegistro.text + "/" + textoPasswordRegistro.text;
      print(cadena);
      UnityWebRequest request = UnityWebRequest.Get(cadena);
      yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
      if (request.result == UnityWebRequest.Result.Success){// 200
         string textoPLano = request.downloadHandler.text;
         resultado.text = "Registro exitoso";
      }
      else{
         resultado.text = "Error en el registro: " + request.responseCode;
      }
   }

   public void RegistrarJSON(){ //Metodo asociado al botón
      //Concurrente
      StartCoroutine(SubirRegistroJSON()); //Paralelo
   }
   //Sube los datos en un JSON con una peticion POST :D.
   private IEnumerator SubirRegistroJSON()
   {
      datos.nombreUsuario = textoUsuarioRegistro.text;
      datos.clave = textoPasswordRegistro.text;
      datos.correo = textoCorreo.text;
      //Encapsular los datos que suben a la red
      WWWForm forma = new WWWForm();
      //Se crea el JSON llamado "datosJSON"
      forma.AddField("datosJSON", JsonUtility.ToJson(datos));
      //se envía el request
      UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/registro",forma);
      yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
      if (request.result == UnityWebRequest.Result.Success){// 200
         string textoPLano = request.downloadHandler.text;
         resultado.text = textoPLano;
      }
      else{
         resultado.text = "Error en la subida: " + request.responseCode;
      }
   }
   
   public void IniciarSesion(){ //Metodo asociado al botón
      //Concurrente
      StartCoroutine(IniciarSesionJugador()); //Paralelo
   }
   //Sube los datos en un JSON con una peticion POST :D.
   private IEnumerator IniciarSesionJugador()
   {
      datos.nombreUsuario = textoUsuarioInicio.text;
      datos.clave = textoPasswordInicio.text;
      //Encapsular los datos que suben a la red
      WWWForm forma = new WWWForm();
      //Se crea el JSON llamado "datosJSON"
      forma.AddField("datosJSON", JsonUtility.ToJson(datos));
      //se envía el request
      UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/iniciarSesion",forma);
      yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
      if (request.result == UnityWebRequest.Result.Success){// 200
         string result = request.downloadHandler.text;
         if (result == "success"){
            //resultado.text = "Sesión iniciada";
            //System.Threading.Thread.Sleep(10000);
            nombreUsuarioJugador = textoUsuarioInicio.text;
            SceneManager.LoadScene("EscenaMapa");

         }else{
            resultado.text = "Correo o contraseña inválidos";
         }
      }
      else{
         resultado.text = "Error en la subida: " + request.responseCode;
      }
   }
}