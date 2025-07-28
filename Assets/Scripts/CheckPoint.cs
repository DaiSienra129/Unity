using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/*
----------------------------------------------------------
Este script detecta cuando el jugador llega al final del nivel (check point), 
muestra un mensaje de "¡Juego Terminado!" en pantalla, activa una animación,
 guarda la posición alcanzada para el respawn y, tras 2 segundos, cambia 
 automáticamente a la siguiente escena o reinicia el juego.
 ---------------------------------------------------------
*/
public class CheckPoint : MonoBehaviour
{
    public TextMeshProUGUI LevelCleard; //es el sistema moderno de textos en Unity

    void Start()
    {
    //Al iniciar la escena, limpia el texto para que no aparezca ningún mensaje visible antes de llegar al checkpoint.
        LevelCleard.text = " ";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>()
                .ReachedCheckPoint(transform.position.x, transform.position.y);

            GetComponent<Animator>().enabled = true;

            LevelCleard.text = "¡Juego Terminado!!";
//Inicia una corrutina que cambiará de escena luego de 2 segundos.
            StartCoroutine(NextLevel());
        }
    }

    System.Collections.IEnumerator NextLevel()
    {
        //Espera 2 segundos tras tocar el checkpoint para dejar tiempo al mensaje y a la animación.
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Reiniciar datos de progreso si querés empezar desde cero
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        PlayerPrefs.DeleteKey("playerLives");
        PlayerPrefs.DeleteKey("nivelAlcanzado");

        // Cargar el primer nivel
        SceneManager.LoadScene(0); // 
    }
}
