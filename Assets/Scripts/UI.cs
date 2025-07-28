using UnityEngine;
using TMPro;

/*
---------------------------------------------------------
gestiona el texto en pantalla que muestra cuántas frutas ha recogido el jugador.
---------------------------------------------------------
*/
public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fruitText; // Texto en la UI que muestra el contador

    int fruits; // Contador interno de frutas recogidas

// Este método lo debe llamar el FruitManager cuando se recolecta una fruta
    public void AddFruit()   // llama desde tu FruitManager
    {
        fruits++; // Incrementa el contador interno
        fruitText.text = "Frutas: " + fruits; // Actualiza el texto en pantalla
    }

}
