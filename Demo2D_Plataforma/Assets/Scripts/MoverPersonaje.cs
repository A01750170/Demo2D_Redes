using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*autor: Erick Hernández silva
*/
public class MoverPersonaje : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadX = 10; //Movimiento horizontal <- ->
    public float maxVelocidadY = 6; //Movimiento vertical ^

    private Rigidbody2D rigidbody; //Para fisica

    //METODOS

    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>(); //Enlazar RB -> Script
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");// [-1, 1]
        float movVertical = Input.GetAxis("Vertical");
        rigidbody.velocity =new Vector2(movHorizontal*maxVelocidadX, rigidbody.velocity.y);
        if (movVertical > 0 && PruebaPiso.estaEnPiso){
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocidadY);
        }
    }
}
