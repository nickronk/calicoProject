using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatnipScript : MonoBehaviour
{
    public static int[] majorcatlist = new int[37];
    public int[] mclVisible = new int[37];

    public Image yarnBG, yarnCT, bedBG, bedCT, postBG, postCT;
    public TMP_Dropdown catnipDropdown, catplaceDropDropdown;
    public Sprite[] spritelist;
    int catRarity;
    public SaveScript sveScrpt;
    public static float at1, at2, at3;
    Button currentButton;

    private void Start()
    {
        currentButton = GetComponent<Button>();
        GetArray();
        mclVisible = majorcatlist;
        //bool[] majorcatlist = new bool[37];
    }

    private void Update()
    {
        Debug.Log(catplaceDropDropdown.value);
        at1--;
        at2--;
        at3--;
        currentButton.enabled = true;

        if (at1<0)
        {
            postCT.enabled = false;

        }
        else if (catplaceDropDropdown.value==0)
        {
            currentButton.enabled = false;
        }
        if (at2 < 0)
        {
            yarnCT.enabled = false;
        }
        else if (catplaceDropDropdown.value == 1)
        {
            currentButton.enabled = false;
        }
        if (at3 < 0)
        {
            bedCT.enabled = false;
        }
        else if (catplaceDropDropdown.value == 2)
        {
            currentButton.enabled = false;
        }
    }
    public void OnClickedNip()
    {
        Debug.Log(majorcatlist);
        int nipNum = catnipDropdown.value + 1;
        int plaNum = catplaceDropDropdown.value;
        int catnumber = 0;
        //0 - none
        //1 - common
        //2 - rare
        //3 - super rare
        //4 - unique


        //No Nip

        if (PlayerPrefs.GetInt("N1") == 0 && nipNum == 1)
        {
            Debug.Log("No Catnip Available of this type");
            return;

        }
        if (PlayerPrefs.GetInt("N2") == 0 && nipNum == 2)
        {
            Debug.Log("No Catnip Available of this type");
            return;

        }
        if (PlayerPrefs.GetInt("N3") == 0 && nipNum == 3)
        {
            Debug.Log("No Catnip Available of this type");
            return;
        }

        //bait type playerpref goes here

        // 1 is 75% miss, 22% common, 3% rare
        // 2 is 14% miss, 60% common, 20% rare, 5% super rare, 1% unique
        // 3 is 1% miss, 44% common, 25% rare, 20% super rare, 10% unique

        //location playerpref goes here

        //If Location = 1 and Bait = 1


        int randomChance = Random.Range(0, 100);
        if (nipNum == 1 && PlayerPrefs.GetInt("N1")>0)
        {
            PlayerPrefs.SetInt("N1", PlayerPrefs.GetInt("N1") - 1);

            if (randomChance <= 4)
            {
                catRarity = 2;
            }
            else if (randomChance <= 25)
            {
                catRarity = 1;
            }
            else
            {
                catRarity = 0;
            }
        }

        else if (nipNum==2 && PlayerPrefs.GetInt("N2") > 0)
        {
            PlayerPrefs.SetInt("N2", PlayerPrefs.GetInt("N2") - 1);

            if (randomChance == 1)
            {
                catRarity = 4;
            }
            else if (randomChance <= 6)
            {
                catRarity = 3;
            }
            else if (randomChance <= 26)
            {
                catRarity = 2;
            }
            else if (randomChance <= 86)
            {
                catRarity = 1;
            }
            else
            {
                catRarity = 0;
            }
        }
        else if (nipNum == 3 && PlayerPrefs.GetInt("N3") > 0)
        {
            PlayerPrefs.SetInt("N3", PlayerPrefs.GetInt("N3") - 1);
            if (randomChance <= 10)
            {
                catRarity = 4;
            }
            else if (randomChance <= 30)
            {
                catRarity = 3;
            }
            else if (randomChance <= 55)
            {
                catRarity = 2;
            }
            else if (randomChance <= 99)
            {
                catRarity = 1;
            }
            else
            {
                catRarity = 0;
            }
        }






        if (catRarity==0)
        {
            //no Sprite
        }
        else if (catRarity==1)
        {
            catnumber = Random.Range(1, 16);

        }
        else if (catRarity==2)
        {
            catnumber = Random.Range(16,25);
        }
        else if (catRarity==3)
        {
            catnumber = Random.Range(25, 32);
        }
        else if (catRarity==4)
        {
            catnumber = Random.Range(32,37);
        }

        Debug.Log(catRarity + " rarity");
        majorcatlist[catnumber] = 1;
        if (plaNum+1==1)
        {
            postCT.enabled = true;
            postCT.sprite = spritelist[catnumber];
            at1 = 300;
        }
        if (plaNum+1 == 2)
        {
            yarnCT.enabled = true;
            yarnCT.sprite = spritelist[catnumber];
            at2 = 300;
        }
        if (plaNum+1 == 3)
        {
            bedCT.enabled = true;
            bedCT.sprite = spritelist[catnumber];
            at3 = 300;
        }

        for (int i=0;i<majorcatlist.Length; i++)
        {
            PlayerPrefs.SetInt("Cat" + i, majorcatlist[i]);
        }


    }

    void GetArray()
    {
        for (int i=0;i<majorcatlist.Length;i++)
        {
            majorcatlist[i] = PlayerPrefs.GetInt("Cat" + i);
        }
    }
}
