using TMPro;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private TextMeshProUGUI text;
    void OnEnable()
    {
        SpawnManager.roundSend += TextRoundChange;
    }
    void OnDisable()
    {
        SpawnManager.roundSend -= TextRoundChange;
    }
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void TextRoundChange(int round)
    {
        text.text = "RONDA: "+(round + 1).ToString();
    }
}
