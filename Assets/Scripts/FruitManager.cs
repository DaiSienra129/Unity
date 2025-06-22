using UnityEngine;
using UnityEngine.SceneManagement; //para cambiar de escena
using System.Collections;
using System.Collections.Generic;



public class FruitManager : MonoBehaviour
{
    public int totalFruits;  // Total frutas en la escena
    private int fruitsCollected = 0;

    private void Start()
    {
        totalFruits = transform.childCount; // si las frutas están como hijos del manager
        // Si no están como hijos, asigna manualmente totalFruits desde el inspector o desde otro método
    }

    public void FruitCollected()
    {
        fruitsCollected++;
        Debug.Log("Frutas recogidas: " + fruitsCollected);

        if (fruitsCollected >= totalFruits)
        {
            Debug.Log("¡No quedan frutas, victoria!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
/*
public class FruitManager : MonoBehaviour
{
    // Este método será llamado desde el script de cada fruta
    public void CheckAllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("¡No quedan frutas, victoria!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}*/

/*public class FruitManager : MonoBehaviour
{
   private void Update()
    {
        AllFruitsCollected();
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas, Victoria!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //cambiar de escena
        }
    }


}
*/