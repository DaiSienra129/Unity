using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CheckGround : MonoBehaviour
{
    //public static bool isGrounded;
    //void OnTriggerStay2D(Collider2D col) => isGrounded = true;

    public static bool isGrounded;

    void OnTriggerEnter2D(Collider2D col) => isGrounded = true;
    void OnTriggerStay2D (Collider2D col) => isGrounded = true;
    void OnTriggerExit2D (Collider2D col) => isGrounded = false;

    /* private void OnTriggerEnter2D(Collider2D collision)
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
}
