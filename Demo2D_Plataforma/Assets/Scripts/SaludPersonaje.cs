using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPersonaje : MonoBehaviour
{
    //numero de vidas
    public int vidas = 3;
    public int monedas = 0; //Recolectadas
    
    public static SaludPersonaje instance;
    private void Awake()
    {
        instance = this;//
    }

    
}
