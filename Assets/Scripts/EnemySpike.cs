using UnityEngine;


/*
---------------------------------------------------------
Detectar cuándo el jugador choca con un enemigo tipo trampa, 
como un pincho, y aplicarle daño inmediatamente a través del sistema 
de PlayerRespawn
---------------------------------------------------------
*/

//Mismo codigo que DamageObject para mayor organizacion y deteccion de errores

public class EnemySpike : MonoBehaviour
{

    //Este método se ejecuta cuando este objeto (el enemigo pincho) colisiona físicamente con otro objeto, usando Collider2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();

        }
    }
}
