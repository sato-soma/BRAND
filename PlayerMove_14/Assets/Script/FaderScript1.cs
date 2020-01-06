using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 1; //透明化のスピード
    float Alfa;
    float red, green, blue;


    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, Alfa);

        if (Input.GetKey(KeyCode.W))
        {
            Alfa += Speed;
        }
    }
}
