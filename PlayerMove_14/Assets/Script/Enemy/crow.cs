using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crow : MonoBehaviour
{
    //プレイヤー用オブジェクト
    public GameObject player;

    //カラス
    public GameObject raven;

    private Rigidbody rigid;

    private Vector3 pos;
    
    public float speed;
    public float down;
    public float up;

    public float dis;

    public bool[] confirmation = new bool[2];

    public bool hit;

    //視覚範囲の数値
    public float search;

    //カウント
    public float[] times = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = raven.transform.position;

        confirmation[0] = confirmation[1] = false;

        hit = false;

        for (int i = 0; i < 5; i++)
        {
            times[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(player.transform.position, pos);

        EnemyNomal();
    }

    private void EnemyNomal()
    {
        //プレイヤーに当たった時その場で3秒止まる
        if (hit == true)
        {
            if (times[4] < 3)
            {
                times[4] += 1.0f / 60.0f;
            }
            else
            {
                times[4] = 0;
                hit = false;
            }
        }

        //プレイヤーがカラスの範囲内に入ったら行動する
        if (dis <= search && hit == false)
        {
            //下降飛行
            if (times[0] >= 0)
            {
                times[1] = -1;
                times[2] = -1;
                times[0] += 1.0f / 60.0f;

                pos = raven.transform.position;
                pos.x -= speed * Time.deltaTime;
                pos.y -= down * Time.deltaTime;
                raven.transform.position = pos;
            }

            if (times[0] > 2)
            {
                times[0] = -1;
                times[1] = 0;
                pos.y = pos.y + 0;
                confirmation[0] = true;
                confirmation[1] = false;
            }

            //どちらかtrueの場合、直進
            if (confirmation[0] == true || confirmation[1] == true)
            {
                if (times[1] >= 0)
                {
                    times[1] += 1.0f / 60.0f;

                    pos = raven.transform.position;
                    pos.x -= speed * Time.deltaTime;
                    raven.transform.position = pos;
                }

                if (times[1] > 4)
                {
                    times[1] = -1;

                    if (confirmation[0] == true)
                    {
                        times[2] = 0;
                    }

                    if (confirmation[1] == true)
                    {
                        times[0] = 0;
                    }
                }

            }

            //上昇飛行
            if (times[2] >= 0)
            {
                times[2] += 1.0f / 60.0f;

                pos = raven.transform.position;
                pos.x -= speed * Time.deltaTime;
                pos.y += up * Time.deltaTime;
                raven.transform.position = pos;
            }

            if (times[2] > 2)
            {
                times[1] = 0;
                times[2] = -1;
                pos.y = pos.y + 0;
                confirmation[0] = false;
                confirmation[1] = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
    }
}
