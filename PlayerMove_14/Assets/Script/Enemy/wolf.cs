using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour
{
    private Rigidbody rigid;

    //プレイヤー
    public GameObject player;

    //オオカミ
    private Vector3 pos;

    private Vector3 posSave;

    //プレイヤーとオオカミの距離
    public Vector3 move;
    
    //移動速度
    public float speed;
    public float dashSpeed;

    //視覚範囲の数値
    public float searchOn;
    public float searchOff;

    public Ray ray ;
   
    public RaycastHit hit;

    public float jump;
    public float infinite;
    public float dis;

    public float posFall;

    //カウント
    public float[] times = new float[5];

    public bool hits;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = gameObject.transform.position;

        posSave = pos;

        hits = false;

        for (int i = 0; i < 5; i++)
        {
            times[i] = 0;
        }

        //アニメーション
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとオオカミの距離
        move = player.transform.position - pos;
        move.Normalize();

        //プレイヤーとオオカミの距離が視覚範囲の数値と比較
        dis = Vector3.Distance(player.transform.position, transform.position);

        EnemyTargetOff();

        EnemyTargetOn();

        if (pos.y < posFall)
        {
            pos = posSave;
        }

        if (PlayerHP.FadeIn == true)
        {
            pos = posSave;
        }

    }

    //視覚範囲入ってない時、通常移動
    private void EnemyTargetOff()
    {
        if (pos.y > posFall)
        {
            
            if (dis >= searchOff && hits == false)
            {
                anim.SetFloat("Speed", 0.06f);

                times[2] = 0;
                times[3] = 0;

                //0秒以上の時、前進移動
                if (times[0] >= 0)
                {
                    times[1] = -1;
                    times[0] += 1.0f / 60f;

                    if (transform.localRotation.eulerAngles.y == 0)
                    {
                        transform.Rotate(Vector3.up, -180f);
                    }

                    //障害物飛び越えるためのソース
                    //ray = new Ray(new Vector3(transform.position.x - 2.3f, transform.position.y, transform.position.z), new Vector3(-1, 0.8f, 0));

                    //Debug.DrawRay(ray.origin, ray.direction * infinite, Color.yellow);

                    //if (Physics.Raycast(ray, out hit, infinite))
                    //{
                    //    if (hit.collider.tag == "bloak")
                    //    {
                    //        rigid.AddForce(transform.up * jump);
                    //    }
                    //}

                    pos = transform.position;
                    pos.x -= speed * Time.deltaTime;
                    transform.position = pos;
                }

                //3秒以上の時、反対に移動
                if (times[0] >= 3)
                {
                    times[0] = -1;
                    times[1] = 0;
                }

                //0秒以上の時、後退移動
                if (times[1] >= 0)
                {
                    times[1] += 1.0f / 60f;

                    //障害物飛び越えるためのソース
                    //ray = new Ray(new Vector3(transform.position.x + 2.3f, transform.position.y, transform.position.z), new Vector3(1, 0.8f, 0));

                    //Debug.DrawRay(ray.origin, ray.direction * infinite, Color.yellow);

                    //if (Physics.Raycast(ray, out hit, infinite))
                    //{
                    //    if (hit.collider.tag == "bloak")
                    //    {
                    //        rigid.AddForce(transform.up * jump);
                    //    }
                    //}

                    if (transform.localRotation.eulerAngles.y == 180)
                    {
                        transform.Rotate(Vector3.up, -180f);
                    }

                    pos = transform.position;
                    pos.x += speed * Time.deltaTime;
                    transform.position = pos;
                }

                //3秒以上の時、反対に移動
                if (times[1] >= 3)
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
        //当たった時3秒止まる
        if (hits == true)
        {
            if (times[4] < 3)
            {
                times[4] += 1.0f / 60.0f;
            }
            else
            {
                times[4] = 0;
                hits = false;
            }
        }

        if (pos.y > posFall)
        {
            if (dis <= searchOn && hits == false)
            {
                times[0] = 0;
                times[1] = 0;

                if (transform.position.x >= player.transform.position.x)
                {
                    times[2] += 1.0f / 60f;
                    times[3] = 0;

                    if (times[2] >= 0)
                    {
                        anim.SetFloat("Speed", 0.06f);
                        dashSpeed = 0;
                    }

                    if (times[2] > 1.5f)
                    {
                        anim.SetFloat("Speed", 0.6f);
                        dashSpeed = 7f;
                    }

                    //障害物飛び越えるためのソース
                    //ray = new Ray(new Vector3(transform.position.x - 2.3f, transform.position.y, transform.position.z), new Vector3(-1, 0.8f, 0));

                    //Debug.DrawRay(ray.origin, ray.direction * infinite, Color.yellow);

                    //if (Physics.Raycast(ray, out hit, infinite))
                    //{
                    //    if (hit.collider.tag == "bloak")
                    //    {
                    //        rigid.AddForce(transform.up * jump);
                    //    }
                    //}

                    if (transform.localRotation.eulerAngles.y == 0)
                    {
                        transform.Rotate(Vector3.up, 180f);
                    }

                    pos = transform.position;
                    pos.x += move.x * dashSpeed * Time.deltaTime;
                    transform.position = pos;
                }

                if (transform.position.x <= player.transform.position.x)
                {
                    times[2] = 0;
                    times[3] += 1.0f / 60.0f;

                    if (times[3] >= 0)
                    {
                        anim.SetFloat("Speed", 0.06f);
                        dashSpeed = 0;
                    }

                    if (times[3] > 1.5f)
                    {
                        anim.SetFloat("Speed", 0.6f);
                        dashSpeed = 7f;
                    }

                    //障害物飛び越えるためのソース
                    //ray = new Ray(new Vector3(transform.position.x + 2.3f, transform.position.y, transform.position.z), new Vector3(1, 0.8f, 0));

                    //Debug.DrawRay(ray.origin, ray.direction * infinite, Color.yellow);

                    //if (Physics.Raycast(ray, out hit, infinite))
                    //{
                    //    if (hit.collider.tag == "bloak")
                    //    {
                    //        rigid.AddForce(transform.up * jump);
                    //    }
                    //}

                    if (transform.localRotation.eulerAngles.y == 180)
                    {
                        transform.Rotate(Vector3.up, -180f);
                    }
                    pos = transform.position;
                    pos.x += move.x * dashSpeed * Time.deltaTime;
                    transform.position = pos;

                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //これプレイヤーに当たった時止まる
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetFloat("Speed", 0.06f);
            hits = true;
        }
    }
}
