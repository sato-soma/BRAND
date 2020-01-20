using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPointDisplay : MonoBehaviour
{

    public static bool PointDisplay = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PointDisplay == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false); //Spriteを消す
        }
        
    }
}
