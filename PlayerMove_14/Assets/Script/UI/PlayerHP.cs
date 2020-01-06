using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject Panel;

    private float Red;
    private float Green;
    private float Blue;
    private float AlfaMax = 1; //固定
    private float AlfaMin = 0; //固定
    //private float DamageAlfaSpeed = 0.34f; //アルファ値の変更スピード
    private float Alfa; //透明度

    public static bool FadeOut = false; //明るくする
    public static bool FadeIn = false; //暗くする

    public static int Damage1 = 3; //仮

    // Start is called before the first frame update
    void Start()
    {
        Red = Panel.GetComponent<Image>().color.r;
        Green = Panel.GetComponent<Image>().color.g;
        Blue = Panel.GetComponent<Image>().color.b;
        Alfa = Panel.GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
     
        Panel.GetComponent<Image>().color = new Color(Red, Green, Blue, Alfa);

        transform.GetChild(0).gameObject.SetActive(false); //Spriteを消す
        transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す



        if (FadeIn==true) //暗くする
        {
            Alfa = AlfaMax;

        }

        if (FadeOut == true) //明るくする
        {
            Alfa -= 0.01f;

            if (Alfa < AlfaMin)
            {
                FadeOut = false;
            }
        }

        //とりあえず
        if (Damage1 > 0)
        {
            if (Damage1 == 2)
            {     
                transform.GetChild(0).gameObject.SetActive(true); //Spriteを表示
            }
            else if (Damage1 == 1)
            {
                transform.GetChild(1).gameObject.SetActive(true);             
            }
        }
    }
}
