using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : MonoBehaviour
{
    private Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //イノシシ
    public GameObject boars;

    public Vector3 pos;

    public Vector3 posSave;

    //プレイヤーとイノシシの距離
    public Vector3 move;

    //移動速度
    public float speed;
    public float dashSpeed;

    //視覚範囲の数値
    public float searchOn;
    public float searchOff;

    public float dis;

    public float posFall;

    //カウント
    public float[] times = new float[5];

    public bool hit;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
        pos = boars.transform.position;

        posSave = pos;

        hit = false;

        for(int i = 0; i < 5; i++)
        {
            times[i] = 0;
        }

        //アニメーション
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとイノシシの距離
        move = player.transform.position - pos;
        move.Normalize();

        //プレイヤーとイノシシの距離が視覚範囲の数値と比較
        dis = Vector3.Distance(player.transform.position, pos);

        EnemyTargetOff();

        EnemyTargetOn();

        if (pos.y < posFall)
        {
            boars.SetActive(false);
            pos = posSave;
        }
        
    }

    //視覚範囲入ってない時、通常移動
    private void EnemyTargetOff()
    {
        if (pos.y > posFall)
        {
            if (dis >= searchOff && hit == false)
            {
                anim.SetFloat("Speed", 5.0f);

                times[2] = 0;
                times[3] = 0;

                //0秒以上の時、前進移動
                if (times[0] >= 0)
                {
                    times[1] = -1;
                    times[0] += 1.0f / 60f;

                    if (boars.transform.localRotation.eulerAngles.y == 0)
                    {
                        boars.transform.Rotate(Vector3.up, 180f);
                    }

                    pos = boars.transform.position;
                    pos.x -= speed * Time.deltaTime;
                    boars.transform.position = pos;
                }

                //4秒以上の時、反対に移動
                if (times[0] >= 4)
                {
                    times[0] = -1;
                    times[1] = 0;
                }

                //0秒以上の時、後退移動
                if (times[1] >= 0)
                {
                    times[1] += 1.0f / 60f;

                    if (boars.transform.localRotation.eulerAngles.y == 180)
                    {
                        boars.transform.Rotate(Vector3.up, -180f);
                    }

                    pos = boars.transform.position;
                    pos.x += speed * Time.deltaTime;
                    boars.transform.position = pos;
                }

                //4秒以上の時、反対に移動
                if (times[1] >= 4)
                {
                    times[1] = -1;
                    times[0] = 0;
                }

            }
        }
    }

    //視覚範囲入った時、プレイヤーを追いかける
    private void EnemyTargetOn()
    {
        //プレイヤーに当たった時3秒止まる
        if (hit == true)
        {
            anim.SetFloat("Speed", 0.0f);

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

        if (pos.y > posFall)
        {
            if (dis <= searchOn && hit == false)
            {
                times[0] = 0;
                times[1] = 0;

                if (boars.transform.position.x >= player.transform.position.x)
                {

                    times[2] += 1.0f / 60f;
                    times[3] = 0;

                    if (times[2] >= 0)
                    {
                        anim.SetFloat("Speed", 0.0f);
                        dashSpeed = 0;
                    }

                    if (times[2] > 2)
                    {
                        anim.SetFloat("Speed", 5.0f);
                        dashSpeed = 6f;
                    }

                    if (boars.transform.localRotation.eulerAngles.y == 0)
                    {
                        boars.transform.Rotate(Vector3.up, 180f);
                    }

                    pos = boars.transform.position;
                    pos.x += move.x * dashSpeed * Time.deltaTime;
                    boars.transform.position = pos;
                }

                if (boars.transform.position.x <= player.transform.position.x)
                {
                    times[2] = 0;
                    times[3] += 1.0f / 60.0f;

                    if (times[3] >= 0)
                    {
                        anim.SetFloat("Speed", 0.0f);
                        dashSpeed = 0;
                    }

                    if (times[3] > 2)
                    {
                        anim.SetFloat("Speed", 5.0f);
                        dashSpeed = 6f;
                    }

                    if (boars.transform.localRotation.eulerAngles.y == 180)
                    {
                        boars.transform.Rotate(Vector3.up, -180f);
                    }

                    pos = boars.transform.position;
                    pos.x += move.x * dashSpeed * Time.deltaTime;
                    boars.transform.position = pos;

                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //これプレイヤーにつけてHP管理する
        if(collision.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //これプレイヤーにつけてHP管理する
        if (collision.gameObject.CompareTag("Grand"))
        {
            pos = boars.transform.position;
            pos.x += move.x * dashSpeed * Time.deltaTime * 0;
            boars.transform.position = pos;
        }
    }

}
