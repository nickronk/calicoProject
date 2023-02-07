using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnipScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedNip()
    {
        //bait type playerpref goes here
        // 1 is 75% miss, 22% common, 3% rare

        //location playerpref goes here

        //If Location = 1 and Bait = 1

        int randomChance = Random.Range(0, 100);

        if (randomChance<4)
        {
            //rare
        }
        else if (randomChance<25)
        {
            //common
        }
        else
        {
            //nothing
        }


    }
}
