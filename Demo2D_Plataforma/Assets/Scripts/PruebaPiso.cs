using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*autor: Erick Hernández silva
*Prueba si el collider está DENTRO o FUERA de una plataforma
*/
public class PruebaPiso : MonoBehaviour
{
    public static bool estaEnPiso = false;
    //Se ejecuta cuando el collider entra en contacto con otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Map")){
            estaEnPiso = true;
            print("Está en piso");
        }
        
    }
    //Se ejecuta cuando el collider deja de tener contacto con otro collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Map")){
            estaEnPiso = false;
            print("No está en piso");
        }
    }
}
