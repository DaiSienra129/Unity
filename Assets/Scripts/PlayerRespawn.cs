using UnityEngine;
using UnityEngine.SceneManagement;

/*
----------------------------------------------------------------
gestiona el sistema de vidas, puntos de control (checkpoint) y reseteo de la escena al recibir daño. 
---------------------------------------------------------------
*/

public class PlayerRespawn : MonoBehaviour
{

//Referencias a los corazones/vidas visibles en pantalla (no se usa)
    public GameObject[] hearts;
//Variables internas
    private int life;
    private float checkPointPositionX, checkPointPositionY;

    void Start()
    {
        //Cantidad de vidas iniciales según cantidad de corazones en pantalla (no se usa)
        life = hearts.Length;
        //Reposicionar si hay checkpoint guardado
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }
    //Al llegar al checkpoint, guarda la posición en memoria (no se borra entre escenas)
    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

//Animación de daño
    public Animator animator;
    //Al recibir daño, reinicia la escena actual
    public void PlayerDamaged()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
