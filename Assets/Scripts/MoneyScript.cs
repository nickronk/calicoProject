using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{

    float money;
    TextMeshProUGUI textM;

    void Start()
    {
        textM = GetComponent<TextMeshProUGUI>();
        textM.text = "$" + PlayerPrefs.GetFloat("Money");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textM.text);
    }

    public void AddMoney(float cash)
    {
        money += cash;
        textM.text = "$"+ money.ToString();
        PlayerPrefs.SetFloat("Money", money);
    }
}
