using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image imagenFondo;
    // Start is called before the first frame update
    void Start()
    {
        imagenFondo.CrossFadeAlpha(0,0.7f,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
