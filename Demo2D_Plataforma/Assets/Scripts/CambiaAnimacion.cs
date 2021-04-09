using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*Permite modificar el parametro velocidad del animator
*para hacer las transiciones
*autor: Erick Hernández silva
*/
public class CambiaAnimacion : MonoBehaviour
{
    //Animator
    private Animator anim; //Actualizar el parametro velocidad
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    private SpriteRenderer rend; //Para hacer el Flipx en X y Y
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocidad
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        if (rb2D.velocity.x>0){
            rend.flipX = false;
        }
        else if (rb2D.velocity.x<0){
            rend.flipX = true;
        }
        anim.SetFloat("velocidad",velocidad);

        //saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);
    }
}
