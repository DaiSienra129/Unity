
using UnityEngine;

/*
------------------------------------------------------
solo recoger la fruta, activar animaciones/hijos, o notificar a un
 sistema central.
------------------------------------------------------
*/

public class Fruit : MonoBehaviour
{
    private FruitManager manager;

    private void Start()
    {
        // Busca el GameObject llamado "FruitManager" en la escena y obtiene su script
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

