using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
[SerializeField] TextMeshProUGUI fruitText;

    int fruits;

    public void AddFruit()   // llama desde tu FruitManager
    {
        fruits++;
        fruitText.text = "Frutas: " + fruits;
    }
    
}
