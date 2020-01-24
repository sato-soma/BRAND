using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public GameObject player;

    public GameObject bats;

    private Rigidbody rigid;

    public Vector3 pos;

    public Vector3 posSave;

    private Vector3 vector;

    public float speed;
    public float posY;

    //視覚範囲距離の数値
    public float search;

    public bool hit;

    public float times;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = bats.transform.position;

        posY = bats.transform.position.y;

        posSave = pos;

        hit = false;

        times = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, bats.transform.position);

        if (hit == true)
        {
            if (times < 3)
            {
                times += 1.0f / 60.0f;
            }
            else
            {
                times = 0;
                hit = false;
            }
        }

        if (dis < search && hit == false)
        {
            pos = bats.transform.position;
            pos.x -= speed * Time.deltaTime;
            pos.y = posY + Mathf.PingPong(Time.time, 1f);
            bats.transform.position = pos;

            /*
            //直進行動
            if (time[0] >= 0)
            {
                time[1] = -1;
                time[0] += 1.0f / 60f;
                pos = transform.position;
                pos.x -= speed * Time.deltaTime;
                pos.y = posY + Mathf.PingPong(Time.time, 1f);
                transform.position = pos;
            }

            if (time[0] >= 4)
            {
                time[0] = -1;
                time[1] = 0;
            }

            if (time[1] >= 0)
            {
                time[0] = -1;
                time[1] += 1.0f / 60f;
                pos = transform.position;
                pos.x -= speed * Time.deltaTime;
                transform.position = pos;
            }

            if (time[1] >= 5)
            {
                time[1] = -1;
                time[0] = 0;
            }
            //rigid.MovePosition(new Vector3(pos.x, pos.y, pos.z));
            */
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //転がる岩に当たるとオブジェクトが消える
        if (collision.gameObject.CompareTag("Blow"))
        {
            pos = posSave;
            bats.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            hit = true;
        }
    }
}
