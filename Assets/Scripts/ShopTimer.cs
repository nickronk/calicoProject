using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Timers;

public class ShopTimer : MonoBehaviour
{

    float timer1, timer2;
    bool t1set, t2set;
    string ob1, ob2;
    public TextMeshProUGUI leftsideText;
    public PurchaseScript purchaseScript;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 100;
        ob1 = PlayerPrefs.GetString("Ob1");
        ob2 = PlayerPrefs.GetString("Ob2");
        t2set = false;
        t1set = false;
        if (PlayerPrefs.GetFloat("FirstTimer") > 0)
        {
            timer1 = PlayerPrefs.GetFloat("FirstTimer");
            t1set = true;
        }

        if (PlayerPrefs.GetFloat("SecondTimer") > 0)
        {
            timer2 = PlayerPrefs.GetFloat("SecondTimer");
            t2set = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (t1set==true)
        {
            if (timer1 < 10)
            {
                leftsideText.text = ob1 + " completed.";
            }
            else
            {
                timer1 -= Time.deltaTime;
                TimeSpan time1 = TimeSpan.FromSeconds(timer1);
                leftsideText.text = ob1 + ": " + time1.ToString("hh':'mm':'ss");
            }
        }
        if (t2set == true)
        {
            if (timer2 < 10)
            {
                leftsideText.text = leftsideText.text + "\n" + ob2 + " completed.";
            }
            else
            {
                timer2 -= Time.deltaTime;
                TimeSpan time2 = TimeSpan.FromSeconds(timer2);
                leftsideText.text = leftsideText.text + "\n" + ob2 + ": " + time2.ToString("hh':'mm':'ss");
            }
        }
    }

    public void OnSceneExit(string where)
    {
        if (t1set == true)
        {
            PlayerPrefs.SetFloat("FirstTimer", timer1);

        }
        if (t2set == true)
        {
            PlayerPrefs.SetFloat("SecondTimer", timer2);
        }

        purchaseScript.SaveAll();

        if (where == "timer")
        {
            SceneManager.LoadScene(0);
        }

    }

    private void OnApplicationQuit()
    {
        if (t1set == true)
        {
            PlayerPrefs.SetFloat("FirstTimer", timer1);

        }
        if (t2set == true)
        {
            PlayerPrefs.SetFloat("SecondTimer", timer2);
        }

    }

    
}
