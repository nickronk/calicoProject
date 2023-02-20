using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseScript : MonoBehaviour
{

    float cash;
    int nip1, nip2, nip3;
    public TextMeshProUGUI rightsideText;

    void Start()
    {
        nip1 = PlayerPrefs.GetInt("N1");
        nip2 = PlayerPrefs.GetInt("N2");
        nip3 = PlayerPrefs.GetInt("N3");
        cash = PlayerPrefs.GetFloat("Money");
        SetText();

    }

    public void Update()
    {
        Debug.Log(nip2);
    }
    // Update is called once per frame
    public void Sale(float code)
        //1 = nip
    {

        nip1=PlayerPrefs.GetInt("N1");
        nip2=PlayerPrefs.GetInt("N2");
        nip3=PlayerPrefs.GetInt("N3");

        if (code==1)
        {
            if (cash>=10)
            {
                cash = cash - 10;
                PlayerPrefs.SetFloat("Money",cash);
                nip1++;
                PlayerPrefs.SetInt("N1", nip1);
            }
        }
        if (code == 2)
        {
            if (cash >= 100)
            {
                cash = cash - 100;
                PlayerPrefs.SetFloat("Money", cash);
                nip2++;
                PlayerPrefs.SetInt("N2", nip2);
            }
        }
        if (code == 3)
        {
            if (cash >= 250)
            {
                cash = cash - 250;
                PlayerPrefs.SetFloat("Money", cash);
                nip3++;
                PlayerPrefs.SetInt("N3", nip3);
            }
        }
        SetText();
        
    }
    private void OnApplicationQuit()
    {
        SaveAll();
    }

    void SetText()
    {
        rightsideText.text = "$" + cash + " \n " + nip1 + " Nip " + "\n" + nip2 + " Super Nip" + "\n" + nip3 + " Uber Nip";
    }

    public void SaveAll()
    {
        PlayerPrefs.SetFloat("Money", cash);
        PlayerPrefs.SetInt("N1", nip1);
        PlayerPrefs.SetInt("N2", nip2);
        PlayerPrefs.SetInt("N3", nip3);
    }

}
