
using UnityEngine;



public class Fruit : MonoBehaviour
{
    private FruitManager manager;

    private void Start()
    {
        manager = GameObject.Find("FruitManager").GetComponent<FruitManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactivar el sprite y el collider para evitar múltiples triggers
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Notificar al manager que una fruta fue recogida
            if (manager != null)
            {
                manager.FruitCollected();
            }

            // Destruir el objeto después de un tiempo para que el sonido o animación terminen
            Destroy(gameObject, 0.5f);
        }
    }
}
/*
public class Fruit : MonoBehaviour
{
    private FruitManager manager;

    private void Start()
    {
        manager = GameObject.Find("FruitManager").GetComponent<FruitManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            if (transform.childCount > 0)
                transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);

            if (manager != null)
                manager.CheckAllFruitsCollected();
        }
    }
}*/

/*
public class Fuit : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);
        }
    }
}*/
