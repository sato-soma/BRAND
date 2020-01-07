using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float ReStartPosX = ReturmGame.PlayerRestartPosition.x;
    private float ReStartPosY = ReturmGame.PlayerRestartPosition.y;
    private float RestartPosZ = ReturmGame.PlayerRestartPosition.z;

    public static bool EnemyHit = false;
    public static bool MidPointFlag = false;
    private bool EventTime = false;
    public static bool Event1EndFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ReturmGame.RestartFlag1 == true)
        {
            EventTime = true;
        }

        if(EventTime==true)
        {
            //イベント以降前のポジションにワープ
            transform.position = new Vector3(ReStartPosX, ReStartPosY, RestartPosZ);
            EventTime = false;
            //ReturmGame.RestartFlag1 = false;
        }
    }

    //当たったら
    private void OnCollisionEnter(Collision collision) 
    {
        //敵と当たったら
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (EnemyHit == false)
            {
                EnemyHit = true;
            }
        }
    }

    //敵と離れたら
    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            EnemyHit = false;
        }

       
    }

    //当たったら
    private void OnTriggerEnter(Collider collision) 
    {
        //中間ポイントにきたら
        if (collision.gameObject.CompareTag("MidPoint")) 
        {
            MidPointFlag = true;
        }

        //一つ目の橋にきたら
        if (collision.gameObject.CompareTag("BridgeStart")) 
        {
            FallingFloor.PassFlag = true;
        }

        //二つ目の橋にきたら
        if (collision.gameObject.CompareTag("BridgeStart2")) 
        {
            LongFallingFloor.LongPassFlag = true;
        }
        

    }

    //離れたら
    private void OnTriggerExit(Collider other) 
    {
       
    }
}
