using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player")){
          
             collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
            
        }
    }
}
