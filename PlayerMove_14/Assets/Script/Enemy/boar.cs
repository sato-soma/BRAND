using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : MonoBehaviour
{
    private Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //イノシシ
    private Vector3 pos;

    private Vector3 posSave;

    //プレイヤーとイノシシの距離
    public Vector3 move;

    //移動速度
    public float speed;
    public float dashSpeed;

    //視覚範囲の数値
    public float searchOn;
    public float searchOff;

    public float posFall;

    //カウント
    public float[] times = new float[5];

    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        posSave = gameObject.transform.position;

        pos = transform.position;

        hit = false;
        for(int i = 0; i < 5; i++)
        {
            times[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとイノシシの距離
        move = player.transform.position - pos;
        move.Normalize();

        //プレイヤーとイノシシの距離が視覚範囲の数値と比較
        float dis = Vector3.Distance(player.transform.position, transform.position);

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

        if (pos.y > posFall)
        {

            //視覚範囲入ってない時、通常移動
            if (dis >= searchOff && hit == false)
            {
                times[2] = 0;
                times[3] = 0;

                //0秒以上の時、前進移動
                if (times[0] >= 0)
                {
                    times[1] = -1;
                    times[0] += 1.0f / 60f;

                    if (transform.localRotation.eulerAngles.y == 180)
                    {
                        transform.Rotate(Vector3.up, -180f);
                    }

                    pos = transform.position;
                    pos.x -= speed;
                    transform.position = pos;
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

                    if (transform.localRotation.eulerAngles.y == 0)
                    {
                        transform.Rotate(Vector3.up, 180f);
                    }

                    pos = transform.position;
                    pos.x += speed;
                    transform.position = pos;
                }

                //4秒以上の時、反対に移動
                if (times[1] >= 4)
                {
                    times[1] = -1;
                    times[0] = 0;
                }

            }

            //視覚範囲入った時、プレイヤーを追いかける
            if (dis <= searchOn && hit == false)
            {
                times[0] = 0;
                times[1] = 0;

                if (transform.position.x >= player.transform.position.x)
                {

                    times[2] += 1.0f / 60f;
                    times[3] = 0;

                    if (times[2] >= 0)
                    {

                        dashSpeed = 0;
                    }

                    if (times[2] > 2)
                    {
                        dashSpeed = 0.15f;
                    }

                    if (transform.localRotation.eulerAngles.y == 180)
                    {
                        transform.Rotate(Vector3.up, -180f);
                    }

                    pos = transform.position;
                    pos.x += move.x * dashSpeed;
                    transform.position = pos;
                }

                if (transform.position.x <= player.transform.position.x)
                {
                    times[2] = 0;
                    times[3] += 1.0f / 60.0f;

                    if (times[3] >= 0)
                    {
                        dashSpeed = 0;
                    }

                    if (times[3] > 2)
                    {
                        dashSpeed = 0.15f;
                    }

                    if (transform.localRotation.eulerAngles.y == 0)
                    {
                        transform.Rotate(Vector3.up, 180f);
                    }

                    pos = transform.position;
                    pos.x += move.x * dashSpeed;
                    transform.position = pos;

                }
            }
        }

        if (pos.y < posFall)
        {
            gameObject.SetActive(false);
            pos.y = posFall;
        }

        if (PlayerHP.FadeIn == true)
        {
            pos.y = posSave.y;
            gameObject.SetActive(true);
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

}
