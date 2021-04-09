using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Permite que la cámara siga al personaje
* Autor: Erick Hernández Silva.
*/

public class MoverCamara : MonoBehaviour
{
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float x = Mathf.Clamp(personaje.transform.position.x, 0, 15.4f);
       float y = Mathf.Clamp(personaje.transform.position.y,0,6.6f); 
       float z = transform.position.z;
       transform.position = new Vector3(x,y,z);
    }
}
