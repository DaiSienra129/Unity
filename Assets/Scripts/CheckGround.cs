using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//----------------------------------------------------------
//Detectar si el personaje está en contacto con el suelo. 
//---------------------------------------------------------
public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    // Cuando entra en contacto con el suelo
    void OnTriggerEnter2D(Collider2D col)
    {
        //Se ejecuta una vez cuando el collider del personaje entra en contacto con un collider tipo “Trigger” (generalmente el suelo).
        isGrounded = true;
        Debug.Log("✅ Piso detectado por CheckGround");
    }

    // Mientras está tocando el suelo
    void OnTriggerStay2D(Collider2D col)
    {
        //Se ejecuta constantemente mientras el personaje siga en contacto con el suelo.
        isGrounded = true;
    }

    // Cuando deja de tocar el suelo
    void OnTriggerExit2D(Collider2D col)
    {
        //Se ejecuta cuando el personaje deja de tocar el suelo.
        isGrounded = false;
        Debug.Log("🚀 Frog dejó el suelo");
    }
}



