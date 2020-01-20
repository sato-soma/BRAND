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
    private float Alfa; //透明度

    public static bool FadeOut = false; //明るくする
    public static bool FadeIn = false; //暗くする

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
        transform.GetChild(1).gameObject.SetActive(false);

        if (FadeIn == true) //画面を真っ暗にする
        {
            Alfa = AlfaMax;
        }

        if (FadeOut == true) //徐々に画面を明るくする
        {
            Alfa -= 0.01f;

            if (Alfa < AlfaMin)
            {
                FadeOut = false;
            }
        }

        //とりあえずダメージを受けた時画面を暗くする画像表示
        if (PlayerDeath.HitCount > 0)
        {
            if (PlayerDeath.HitCount == 2)
            {
                transform.GetChild(0).gameObject.SetActive(true); //Spriteを表示
            }
            else if (PlayerDeath.HitCount == 1)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
