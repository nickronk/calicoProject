using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TabInputField : MonoBehaviour
{
    public TMP_InputField nameF, hrF, mnF;
    public int inputNum;
    void Update()
    {
        Time.timeScale = 100;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputNum++;
            if (inputNum > 2) inputNum = 0;
        }       
        if (inputNum == 0)
            nameF.Select();
        if (inputNum == 1)
            hrF.Select();
        if (inputNum == 2)
            mnF.Select();
    }

    public void Select0()
    {
        nameF.Select();
        inputNum = 0;
    }
    public void Select1()
    {
        hrF.Select();
        inputNum = 1;
    }
    public void Select2()
    {
        mnF.Select();
        inputNum = 2;
    }
}
