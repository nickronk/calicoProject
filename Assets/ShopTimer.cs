using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTimer : MonoBehaviour
{

    float timer1, timer2;
    bool t1set, t2set;
    // Start is called before the first frame update
    void Start()
    {
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
            timer1 -= Time.deltaTime;
        }
        if (t2set == true)
        {
            timer2 -= Time.deltaTime;
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

        if (where == "timer")
        {
            SceneManager.LoadScene(0);
        }

    }
}
