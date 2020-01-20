using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rigid;

    private Vector3 pos;
    private Vector3 posSave;

    private Vector3 vector;

    public float speed;
    public float posY;

    //視覚範囲距離の数値
    public float search;

    public float[] time = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        pos = transform.position;
        pos = posSave;

        time[0] = 0;
        time[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);

        if (dis < search)
        {
            pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            pos.y = posY + Mathf.PingPong(Time.time, 1f);
            transform.position = pos;

            /*
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

        if (PlayerHP.FadeIn == true)
        {
            transform.gameObject.SetActive(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        //これプレイヤーにつけてHP管理する
        if (collision.gameObject.CompareTag("Blow"))
        {
            transform.gameObject.SetActive(false);
            pos = posSave;
        }
    }
}
