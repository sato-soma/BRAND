using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event1Image : MonoBehaviour
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

    public static bool StopTime1;

    public float Event1ImageTime = 12.0f; //一枚の表示時間
    public float MaxTime = 12.0f; //上と数字を合わせる(今のところ)

    public float EventImage0 = 9; //それぞれ何秒になるまで表示するか(仮)
    public float EventImage1 = 6;
    public float EventImage2 = 3;

   // private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Red = Panel.GetComponent<Image>().color.r;
        //Green = Panel.GetComponent<Image>().color.g;
        //Blue = Panel.GetComponent<Image>().color.b;
        //Alfa = Panel.GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        //Panel.GetComponent<Image>().color = new Color(Red, Green, Blue, Alfa);

        Debug.Log(Event1ImageTime);

        ResetImage(); //画像を非表示

        if (StopTime1 == false) //カウントが止まってないなら
        {
            Event1ImageTime -= 1.0f / 60.0f;
        }

        //Event1ImageTimeを減らしていき一定以下になったらSpriteを消す
        if (Event1ImageTime < EventImage0)
        {
            transform.GetChild(0).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (Event1ImageTime < EventImage1)
        {
            transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す
            transform.GetChild(2).gameObject.SetActive(true);
        }
        if (Event1ImageTime < EventImage2)
        {
            StopTime1 = true;
            transform.GetChild(2).gameObject.SetActive(true);
            Event1ImageTime = MaxTime;                 
        }
    }

    void ResetImage() //画像のリセット
    {
        transform.GetChild(1).gameObject.SetActive(false); //Spriteを消す
        transform.GetChild(2).gameObject.SetActive(false); //Spriteを消す
    }
}
