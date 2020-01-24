using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    private Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //蜘蛛
    public GameObject spiders;

    private Vector3 pos;

    //プレイヤーと蜘蛛の距離
    public Vector3 move;

    //移動速度
    public float speed;
    public float dashSpeed;

    //視覚範囲の数値
    public float searchOn;
    public float searchOff;

    //カウント
    public float[] times = new float[5];

    public bool hit;

    public float dis;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = spiders.transform.position;

        hit = false;

        for (int i = 0; i < 5; i++)
        {
            times[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = player.transform.position - pos;
        move.Normalize();

        dis = Vector3.Distance(player.transform.position, spiders.transform.position);

        EenmyAIOff();

        //EnemyAIOn();
    }

    private void EenmyAIOff()
    {
        //視覚範囲入ってない時、通常行動
        if (dis >= searchOff && hit == false)
        {
            times[2] = 0;
            times[3] = 0;

            //0秒以上の時、下に移動
            if (times[0] >= 0)
            {
                times[1] = -1;

                times[0] += 1.0f / 60f;
                
                pos = spiders.transform.position;
                pos.y -= speed * Time.deltaTime;
                spiders.transform.position = pos;
            }

            //4秒以上の時、反対に移動
            if (times[0] >= 4)
            {
                times[0] = -1;
                times[1] = 0;
            }

            //0秒以上の時、上に移動
            if (times[1] >= 0)
            {
                times[1] += 1.0f / 60f;
                
                pos = spiders.transform.position;
                pos.y += speed * Time.deltaTime;
                spiders.transform.position = pos;
            }

            //4秒以上の時、反対に移動
            if (times[1] >= 4)
            {
                times[1] = -1;
                times[0] = 0;
            }

        }
    }

    /*
    //視覚範囲内の場合、動くスピードを上げる
    private void EnemyAIOn()
    {
        if (dis <= searchOn && hit == false)
        {
            times[0] = 0;
            times[1] = 0;

            if (spiders.transform.position.x >= player.transform.position.x)
            {

                times[2] += 1.0f / 60f;
                times[3] = 0;

                if (times[2] >= 0)
                {

                    dashSpeed = 0;
                }

                if (times[2] > 2)
                {
                    dashSpeed = 0.01f;
                }
                
                pos = spiders.transform.position;
                pos.y = move.y * dashSpeed * Time.deltaTime;
                spiders.transform.position = pos;
            }

            if (spiders.transform.position.x <= player.transform.position.x)
            {
                times[2] = 0;
                times[3] += 1.0f / 60.0f;

                if (times[3] >= 0)
                {
                    dashSpeed = 0;
                }

                if (times[3] > 2)
                {
                    dashSpeed = 0.01f;
                }
                

                pos = spiders.transform.position;
                pos.y += move.y * dashSpeed * Time.deltaTime;
                spiders.transform.position = pos;

            }
        }
    }
    */
}
