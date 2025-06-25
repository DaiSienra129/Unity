using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public TextMeshProUGUI LevelCleard;

    void Start()
    {
        LevelCleard.text = "";
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
    }
}
