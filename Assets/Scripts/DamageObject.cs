using UnityEngine;

/*
-------------------------------------------------
Este script detecta cuándo el jugador choca contra un objeto dañino 
-------------------------------------------------
*/
public class DamageObject : MonoBehaviour
{


//Este método se ejecuta automáticamente cuando el objeto con este script colisiona físicamente con otro
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))//Verifica si el objeto que chocó tiene el tag "Player",Esto evita que se active si colisiona con otra cosa, como una fruta
        {

            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();

        }
    }
}
