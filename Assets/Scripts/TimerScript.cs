using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public bool timerSet, timerSet2;
    public float theTime,theTime2;
    public string objective,objective2;
    //used by other scripts
    public TextMeshProUGUI howLong,textfortimer, textforlower, textfortimer2, textforlower2, textforNewTaskButton,textforNewTaskButton2;
    public GameObject newTaskPanel,newTaskPanelTime,completeTask1,completeTask2,img1,img2,firstTaskButton,secondTaskButton,cashObj;
    public int newTaskState,newTaskState2;
    public TMP_InputField newTaskName,hourAmt,minAmt;
    public Slider sl1, sl2;

    int timerStatus;
    float originT1, originT2;
    public GameObject shopButton,galButton;

    void Start()
    {
        textforNewTaskButton.text = "Add Task 1";
        newTaskState = 0;
        newTaskState2 = 0;
        sl1.gameObject.SetActive(false);
        sl2.gameObject.SetActive(false);

        if (PlayerPrefs.GetFloat("FirstTimer")>0)
        {
            timerSet = true;
            theTime = PlayerPrefs.GetFloat("FirstTimer");
            newTaskState = 2;
            sl1.gameObject.SetActive(true);
            img1.gameObject.SetActive(true);
            objective = PlayerPrefs.GetString("Ob1");
            sl1.maxValue = PlayerPrefs.GetFloat("FirstOrigin");
        }

        if (PlayerPrefs.GetFloat("SecondTimer") > 0)
        {
            timerSet2 = true;
            theTime2 = PlayerPrefs.GetFloat("SecondTimer");
            newTaskState2 = 2;
            img2.gameObject.SetActive(true);
            sl2.gameObject.SetActive(true);
            objective2 = PlayerPrefs.GetString("Ob2");
            sl2.maxValue = PlayerPrefs.GetFloat("SecondOrigin");
        }
    }

    void Update()
    {
        
        if (completeTask1.activeSelf==false && completeTask2.activeSelf == false)
        {
            shopButton.SetActive(true);
            firstTaskButton.SetActive(true);
            secondTaskButton.SetActive(true);
            galButton.SetActive(true);

        }
        else
        {
            shopButton.SetActive(false);
            galButton.SetActive(false);
            firstTaskButton.SetActive(false);
            secondTaskButton.SetActive(false);
        }

        if (timerSet&&!timerSet2)
        {
            timerStatus = 1;
        }
        else if (timerSet && timerSet2)
        {
            timerStatus = 2;
        }
        else if (!timerSet && timerSet2)
        {
            timerStatus = 3;
        }
        else if (!timerSet && !timerSet2)
        {
            timerStatus = 0;
            secondTaskButton.SetActive(false);

        }

        ///TIMER 1
        ///
        if (timerSet==true)
        {
            
            theTime -= Time.deltaTime;
            TimeSpan time1 = TimeSpan.FromSeconds(theTime);
            //Debug.Log(theTime);
            if (theTime>86400)
                textfortimer.text = time1.ToString("dd':'hh':'mm':'ss");
            else if (theTime>3600)
                textfortimer.text = time1.ToString("hh':'mm':'ss");
            else
                textfortimer.text = time1.ToString("mm':'ss");
            textforlower.text = objective;
            sl1.value = theTime;
            if (theTime<0 && theTime>-99999)
            {
                timerSet = false;
                completeTask1.SetActive(true);
            }
            textforNewTaskButton.text = "Delete "+objective;
            secondTaskButton.SetActive(true);
            newTaskState = 2;
        }
        else
        {
            sl1.gameObject.SetActive(false);
            PlayerPrefs.DeleteKey("Ob1");
            PlayerPrefs.DeleteKey("FirstTimer");
            textfortimer.text = "00:00";
            textforlower.text = "There is no timer set.";
        }

        ///TIMER 2
        ///
        if (timerSet2 == true)
        {
            secondTaskButton.SetActive(true);
            theTime2 -= Time.deltaTime;
            TimeSpan time2 = TimeSpan.FromSeconds(theTime2);
            if (theTime2 > 86400)
                textfortimer2.text = time2.ToString("dd':'hh':'mm':'ss");
            else if (theTime2 > 3600)
                textfortimer2.text = time2.ToString("hh':'mm':'ss");
            else
                textfortimer2.text = time2.ToString("mm':'ss");
            textforlower2.text = objective2;
            sl2.value = theTime2;
            if (theTime2 < 0 && theTime2 > -99999)
            {
                timerSet2 = false;
                completeTask2.SetActive(true);
            }
            textforNewTaskButton2.text = "Delete " + objective2;
            secondTaskButton.SetActive(true);
            newTaskState2 = 2;
        }
        else
        {
            sl2.gameObject.SetActive(false);
            PlayerPrefs.DeleteKey("Ob2");
            PlayerPrefs.DeleteKey("SecondTimer");
            textfortimer2.text = "00:00";
            textforlower2.text = "There is no timer set.";
        }

    }

    public void NewTaskButtonPress(int numb)
    {
        if (numb == 1)
        {
            if (newTaskState == 2)
            {
                ResetTask(1);
            }
            else if (timerSet == true)
            {
                if (newTaskState == 0)
                {
                    objective = "";
                    textfortimer.text = "";
                    sl1.gameObject.SetActive(false);

                    textforlower.text = "There is no timer set.";
                }
            }
            else if (newTaskState == 0)
            {
                textforNewTaskButton.text = "Cancel";
                newTaskPanel.SetActive(true);
                newTaskPanel.SetActive(true);

                newTaskPanelTime.SetActive(false);
                newTaskState = 1;
            }
            else if (newTaskState == 1)
            {
                textforNewTaskButton.text = "Add Task 1";
                newTaskPanel.SetActive(false);
                newTaskPanelTime.SetActive(false);
                newTaskState = 0;
            }
        }
        else if (numb==2)
        {
            if (newTaskState2 == 2)
            {
                ResetTask(2);
            }
            else if (timerSet2 == true)
            {
                if (newTaskState2 == 0)
                {
                    sl2.gameObject.SetActive(false);

                    objective = "";
                    textfortimer2.text = "";
                    textforlower2.text = "There is no timer set.";
                }
            }
            else if (newTaskState2 == 0)
            {
                textforNewTaskButton2.text = "Cancel";
                newTaskPanel.SetActive(true);
                newTaskPanel.SetActive(true);

                newTaskPanelTime.SetActive(false);
                newTaskState2 = 1;
            }
            else if (newTaskState2 == 1)
            {
                textforNewTaskButton2.text = "Add Task 2";
                newTaskPanel.SetActive(false);
                newTaskPanelTime.SetActive(false);
                newTaskState2 = 0;
            }
        }
    }

    public void NewTaskNameGiven()
    {
        if (newTaskName.text != null && newTaskName.text!="")
        {
            newTaskPanelTime.SetActive(true);
        }
        else
        {
            Debug.Log(newTaskName.text);
        }


    }

    public void TimeSet()
    {
        if (hourAmt.text == "" && minAmt.text == "" || ((hourAmt.text == "0" || hourAmt.text == "00") && (minAmt.text == "0" || minAmt.text == "00")))
        {
            howLong.text = "Insert a valid time.";
            return;
        }
        else if (hourAmt.text=="")
        {
            hourAmt.text = "0";
        }
        else if (minAmt.text == "")
        {
            minAmt.text = "0";
        }

        //


        if (timerStatus==0||timerStatus==3)
        {
            img1.SetActive(true);
            objective = newTaskName.text;
            theTime = int.Parse(hourAmt.text) * 60 * 60 + int.Parse(minAmt.text) * 60;
            hourAmt.text = "";
            minAmt.text = "";
            newTaskName.text = "";
            newTaskPanel.SetActive(false);
            newTaskPanelTime.SetActive(false);
            textforlower.text = objective;
            originT1 = theTime;
            PlayerPrefs.SetFloat("FirstOrigin", originT1);
            timerSet = true;
            newTaskState = 0;
            textforNewTaskButton.text = "Add Task 1";
            //deleteTask.SetActive(true);
            sl1.minValue = 0;
            sl1.maxValue = theTime;
            sl1.gameObject.SetActive(true);
            howLong.text = "For how long?";
        }
        else if (timerStatus==1)
        {
            img2.SetActive(true);
            objective2 = newTaskName.text;
            theTime2 = int.Parse(hourAmt.text) * 60 * 60 + int.Parse(minAmt.text) * 60;
            hourAmt.text = "";
            minAmt.text = "";
            newTaskName.text = "";
            newTaskPanel.SetActive(false);
            newTaskPanelTime.SetActive(false);
            textforlower2.text = objective2;
            timerSet2 = true;
            newTaskState2 = 0;
            textforNewTaskButton2.text = "Add Task 2";
            originT2 = theTime2;
            PlayerPrefs.SetFloat("SecondOrigin", originT2);
            sl2.minValue = 0;
            sl2.maxValue = theTime2;
            sl2.gameObject.SetActive(true);
            howLong.text = "For how long?";
        }
    }


    public void Completion(int numb)
    {
        if (numb==1)
        {
            sl1.gameObject.SetActive(false);
            ResetTask(1);
            originT1 = PlayerPrefs.GetFloat("FirstOrigin");
            cashObj.GetComponent<MoneyScript>().AddMoney(originT1);
        } 
        else if (numb==2)
        {
            sl2.gameObject.SetActive(false);
            ResetTask(2);
            originT2 = PlayerPrefs.GetFloat("SecondOrigin");
            cashObj.GetComponent<MoneyScript>().AddMoney(originT2);

        }
    }

    public void ResetTask(int i)
    {
        if (i==1)
        {
            textforNewTaskButton.text = "Add Task 1";
            Debug.Log("AAAAA");

            img1.SetActive(false);
            theTime = -100000;
            hourAmt.text = "";
            minAmt.text = "";
            newTaskName.text = "";
            newTaskPanel.SetActive(false);
            newTaskPanelTime.SetActive(false);
            textforlower.text = "No timer set.";
            timerSet = false;
            objective = "";
            newTaskState = 0;
            //deleteTask.SetActive(true);
            sl1.minValue = 0;
            sl1.maxValue = theTime;
            sl1.gameObject.SetActive(false);
            howLong.text = "For how long?";
            completeTask1.SetActive(false);
            newTaskState = 0;
        }
        if (i == 2)
        {
            textforNewTaskButton2.text = "Add Task 2";
            Debug.Log("AAAAAB");

            img2.SetActive(false);
            theTime2 = -100000;
            hourAmt.text = "";
            minAmt.text = "";
            newTaskName.text = "";
            newTaskPanel.SetActive(false);
            newTaskPanelTime.SetActive(false);
            textforlower2.text = "No timer set.";
            timerSet2 = false;
            newTaskState2 = 0;
            objective2 = "";
            //deleteTask.SetActive(true);
            sl2.minValue = 0;
            sl2.maxValue = theTime;
            sl2.gameObject.SetActive(false);
            howLong.text = "For how long?";
            completeTask2.SetActive(false);
            newTaskState2 = 0;
        }
    }

    public void OnSceneExit(string where)
    {
        if (timerSet == true)
        {
            PlayerPrefs.SetFloat("FirstTimer", theTime);
            PlayerPrefs.SetString("Ob1", objective);
        }
        if (timerSet2 == true)
        {
            PlayerPrefs.SetString("Ob2", objective2);
            PlayerPrefs.SetFloat("SecondTimer", theTime2);
        }

        if (where == "timer")
        {
            SceneManager.LoadScene(0);
        }

        if (where == "shop")
        {
            SceneManager.LoadScene(1);
        }
        if (where == "gallery")
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnApplicationQuit()
    {
        if (timerSet == true)
        {
            PlayerPrefs.SetFloat("FirstTimer", theTime);
            PlayerPrefs.SetString("Ob1", objective);
        }
        if (timerSet2 == true)
        {
            PlayerPrefs.SetString("Ob2", objective2);
            PlayerPrefs.SetFloat("SecondTimer", theTime2);
        }
    }
}
