using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerMove playerMove;

    public GameObject Player;
    public GameObject StartPoint; //スタート位置
    public GameObject MidPoint; //中間スタート位置

    public static int HitCount; //体力
    public static int HitCuntMax = 3; //MAX体力

    private int PlayerDamage = 1; //playerが受けるダメージ

    public float StageY_Min;
   
    private float ReStartWarpTime; //死んだときの暗転している時間
    private float ReStartWarpTimeMax = 2;

    public static bool DeathFlag = false;

    public static bool ReStartFlag = false;
   
  
    // Start is called before the first frame update
    void Start()
    {
        ReStartWarpTime = ReStartWarpTimeMax;
        HitCount = HitCuntMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        HPCount();

        PlayerDrop();

        Death();

        //暗転がおわるまでその場で停止
        if (ReStartFlag==true) 
        {
            PlayerMove.RotFlag = false;
            Player.transform.position = StartPoint.transform.position;

            if (PlayerState.MidPointFlag == true)
            {
                Player.transform.position = MidPoint.transform.position;
            }
        }

        if(PlayerHP.FadeOut==false)
        {
            ReStartFlag = false;
        }   
    }

    void PlayerDrop()
    { 
        //一定以上落ちたら
        if (Player.transform.position.y < StageY_Min)
        {
            DeathFlag = true;
        }  
    }

    void HPCount()
    {
        //敵と当たったら
        if (PlayerState.EnemyHit == true) 
        {
            HitCount -= PlayerDamage;

            PlayerHP.Damage1 -= PlayerDamage;

            PlayerState.EnemyHit = false;
        }

        if (HitCount <= 0)
        {
            DeathFlag = true;
        }
    }

    void Death()
    {
        //死んだときワープ
        if (DeathFlag == true) 
        {
            PlayerHP.FadeIn = true;
            ReStartWarpTime -= 1.0f / 60.0f;

            PlayerHP.Damage1 = 0; //仮

            if (ReStartWarpTime < 0)
            {
                PlayerHP.FadeIn = false;
                PlayerHP.FadeOut = true;
                ReStartWarpTime = ReStartWarpTimeMax;
                HitCount = HitCuntMax;

                PlayerHP.Damage1 = 3; //仮
            }

            if (PlayerHP.FadeIn == false)
            {
                Player.transform.position = StartPoint.transform.position;

                if (PlayerState.MidPointFlag == true)
                {
                    Player.transform.position = MidPoint.transform.position;
                }

                ReStartFlag = true;
            }

            DeathFlag = false;
        }
    }

    

   
}
