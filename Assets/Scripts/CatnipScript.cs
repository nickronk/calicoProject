using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatnipScript : MonoBehaviour
{
    public Image yarnBG, yarnCT, bedBG, bedCT, postBG, postCT;
    public Dropdown catnipDropdown, catplaceDropDropdown;
    public Sprite[] spritelist;
    int catRarity;

    public void OnClickedNip()
    {
        
        int nipNum = catnipDropdown.value + 1;
        int plaNum = catnipDropdown.value + 1;
        
        //0 - none
        //1 - common
        //2 - rare
        //3 - super rare
        //4 - unique




        //bait type playerpref goes here

        // 1 is 75% miss, 22% common, 3% rare
        // 2 is 14% miss, 60% common, 20% rare, 5% super rare, 1% unique
        // 3 is 1% miss, 44% common, 25% rare, 20% super rare, 10% unique

        //location playerpref goes here

        //If Location = 1 and Bait = 1

        int randomChance = Random.Range(0, 100);
        if (nipNum == 1)
        {
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
        else if (nipNum==2)
        {
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
        else if (nipNum == 3)
        {
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

        if (plaNum==1)
        {
            //function that recieves a sprite
        }
    }
}
