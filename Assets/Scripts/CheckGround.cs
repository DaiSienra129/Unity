using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    // Cuando entra en contacto con el suelo
    void OnTriggerEnter2D(Collider2D col)
    {
        isGrounded = true;
        Debug.Log("✅ Piso detectado por CheckGround");
    }

    // Mientras está tocando el suelo
    void OnTriggerStay2D(Collider2D col)
    {
        isGrounded = true;
    }

    // Cuando deja de tocar el suelo
    void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
        Debug.Log("🚀 Frog dejó el suelo");
    }
}

/*public class CheckGround : MonoBehaviour
{
    //public static bool isGrounded;
    //void OnTriggerStay2D(Collider2D col) => isGrounded = true;

    public static bool isGrounded;

    void OnTriggerEnter2D(Collider2D col) => isGrounded = true;
    void OnTriggerStay2D (Collider2D col) => isGrounded = true;
    void OnTriggerExit2D (Collider2D col) => isGrounded = false;

     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Ground"))
         {
              isGrounded = true;
         }

     }

     private void OnTriggerExit2D(Collider2D collision)
     {

         if (collision.CompareTag("Ground"))
         {
              isGrounded = false;
         }
     }*/

