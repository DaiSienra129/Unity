using UnityEngine;
using UnityEngine.SceneManagement; //para cambiar de escena
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

/*
-------------------------------------------------------------------
Controlar la cantidad de frutas en la escena, actualizar la UI en pantalla
 con la cantidad recolectada, y avanzar de nivel una vez que se hayan recogido 
 todas las frutas.
-------------------------------------------------------------------
*/

public class FruitManager : MonoBehaviour
{
    public int totalFruits;  // Total frutas en la escena
    private int fruitsCollected = 0; // Contador de frutas recogidas

    public TextMeshProUGUI totalFruits2; // Texto UI que muestra el total

    public TextMeshProUGUI fruitCollected; // Texto UI que muestra cuántas quedan

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruits = transform.childCount; // si las frutas están como hijos del manager
                                            // Si no están como hijos, asigna manualmente totalFruits desde el inspector o desde otro método
        totalFruitsInLevel = transform.childCount;
    }

//Actualiza los textos de UI cada frame
    public void Update()
    {
        // Actualiza los textos en pantalla, si están asignados
        if (totalFruits2 != null)
        {
            totalFruits2.text = totalFruitsInLevel.ToString();
        }

        if (fruitCollected != null)
        {
            fruitCollected.text = transform.childCount.ToString();
        }

    }

//Lo llama cada fruta al recogerse; si se juntan todas, cambia de escena
    public void FruitCollected()
    {
        fruitsCollected++; // Aumenta el contador interno
        Debug.Log("Frutas recogidas: " + fruitsCollected);

        if (fruitsCollected >= totalFruits)
        {
            Debug.Log("¡No quedan frutas, victoria!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
