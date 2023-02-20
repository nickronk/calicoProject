using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour
{

    public int[] copiedArray;
    public Image[] catImages;
    void Start()
    {
        copiedArray = CatnipScript.majorcatlist;
        for (int i = 0; i<copiedArray.Length;i++)
        {
            if (copiedArray[i]==1)
            {
                catImages[i].enabled = true;
            }
            else
            {
                catImages[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
