using UnityEngine;
using UnityEngine.UI;

public class TextFruits : MonoBehaviour
{
    [SerializeField] private Text textFruits;

    private void Update()
    {
        textFruits.text = "Fruits : " + ItemsCollector.Instance.fruits;
    }
}
