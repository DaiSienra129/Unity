using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public TextMeshProUGUI LevelCleard;

    void Start()
    {
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

            StartCoroutine(NextLevel());
        }
    }

    System.Collections.IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Reiniciar datos de progreso si querés empezar desde cero
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        PlayerPrefs.DeleteKey("playerLives");
        PlayerPrefs.DeleteKey("nivelAlcanzado");

        // Cargar el primer nivel
        SceneManager.LoadScene(0); // o "Level 1" si preferís por nombre
    }
}
