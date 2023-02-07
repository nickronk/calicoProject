using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseScript : MonoBehaviour
{

    float cash = PlayerPrefs.GetFloat("money");
    void Start()
    {
        
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
                PlayerPrefs.SetFloat("money",cash);
            }
        }
    }
}
