using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseScript : MonoBehaviour
{

    float cash;
    int nip1, nip2, nip3;

    void Start()
    {
        cash = PlayerPrefs.GetFloat("Money");
    }

    // Update is called once per frame
    public void Sale(float code)
        //1 = nip
    {
        if (code==1)
        {
            if (cash>10)
            {
                cash = cash - 10;
                PlayerPrefs.SetFloat("Money",cash);
                nip1++;
                PlayerPrefs.SetInt("N1", nip1);
            }
        }
        if (code == 2)
        {
            if (cash > 100)
            {
                cash = cash - 100;
                PlayerPrefs.SetFloat("Money", cash);
                nip2++;
                PlayerPrefs.SetInt("N2", nip2);
            }
        }
        if (code == 3)
        {
            if (cash > 250)
            {
                cash = cash - 250;
                PlayerPrefs.SetFloat("Money", cash);
                nip3++;
                PlayerPrefs.SetInt("N3", nip3);
            }
        }


        
    }
    private void OnApplicationQuit()
    {
        SaveAll();
    }

    public void SaveAll()
    {
        PlayerPrefs.SetFloat("Money", cash);
        PlayerPrefs.SetInt("N1", nip1);
        PlayerPrefs.SetInt("N2", nip2);
        PlayerPrefs.SetInt("N3", nip3);
    }

}
