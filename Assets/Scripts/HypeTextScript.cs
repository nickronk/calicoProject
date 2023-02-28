using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HypeTextScript : MonoBehaviour
{
    public TextAsset file;
    private TextMeshProUGUI line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<TextMeshProUGUI>();
        string newString = GetRandomLine();
        line.text = newString;
    }

    private string GetRandomLine()
    {
        string[] lines = file.text.Split("\n");
        int randomIndex = Random.Range(0, lines.Length);
        return lines[randomIndex];
    }
}
