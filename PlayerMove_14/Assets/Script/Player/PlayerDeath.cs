using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject Player;
    public GameObject StartPoint; //スタート位置
    public GameObject MidPoint; //中間スタート位置

    public static int HitCount; //体力
    public static int HitCuntMax = 3; //MAX体力

    private int PlayerDamage = 1; //playerが受けるダメージ

    public float Stage1Y_Min; //ステージ１でどこまで行ったら(落ちたら)死んだ扱いになるか
    public float Stage2Y_Min; //ステージ２でどこまで行ったら(落ちたら)死んだ扱いになるか

    private float ReStartWarpTime; //死んだときの暗転している時間
    private float ReStartWarpTimeMax = 2; //どれぐらい暗転しているか

    public static bool DeathFlag = false; //死んだかどうか

    public static bool ReStartFlag = false; //復帰しているか


    // Start is called before the first frame update
    void Start()
    {
        ReStartWarpTime = ReStartWarpTimeMax;
        HitCount = HitCuntMax;
    }

    // Update is called once per frame
    void Update()
    {
        HPCount(); //敵と当たった時の処理

        PlayerDrop(); //ステージから落ちたか

        Death(); //死んだ時の処理

        //暗転がおわるまでワープした所で停止
        if (ReStartFlag == true)
        {
            PlayerMove.RotFlag = false;
            Player.transform.position = StartPoint.transform.position;

            if (PlayerState.MidPointFlag == true)
            {
                Player.transform.position = MidPoint.transform.position;
                MidPointDisplay.PointDisplay = true;
            }
        }

        if (PlayerHP.FadeOut == false) //画面が明るくなったら
        {
            ReStartFlag = false;
        }
    }

    void PlayerDrop() //ステージから落ちたか
    {
        if (SceneManager.GetActiveScene().name == "playerMove")
        {//一定以上落ちたら
            if (Player.transform.position.y < Stage1Y_Min)
            {
                DeathFlag = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "stage2")
        {//一定以上落ちたら
            if (Player.transform.position.y < Stage2Y_Min)
            {
                DeathFlag = true;
            }
        }
    }

    void HPCount() //敵と当たった時の処理
    {
        //敵と当たったら
        if (PlayerState.EnemyHit == true)
        {
            HitCount -= PlayerDamage;

            PlayerState.EnemyHit = false;
        }

        if (HitCount <= 0)
        {
            DeathFlag = true;
        }
    }

    void Death() //死んだ時の処理
    {
        //死んだときワープ
        if (DeathFlag == true)
        {
            PlayerHP.FadeIn = true;
            ReStartWarpTime -= 1.0f / 60.0f;

            HitCount = 0; //体力をゼロにする

            if (ReStartWarpTime < 0)
            {
                PlayerHP.FadeIn = false;
                PlayerHP.FadeOut = true;
                ReStartWarpTime = ReStartWarpTimeMax;
                HitCount = HitCuntMax; //体力全回復              
            }

            // 死んだときスタート地点にワープする
            if (PlayerHP.FadeIn == false)
            {
                //Player.transform.position = StartPoint.transform.position;

                //// 中間ポイントに来ていたら中間ポイントにワープ
                //if (PlayerState.MidPointFlag == true)
                //{
                //    Player.transform.position = MidPoint.transform.position;
                //}

                ReStartFlag = true;
            }

            DeathFlag = false;
        }
    }




}
