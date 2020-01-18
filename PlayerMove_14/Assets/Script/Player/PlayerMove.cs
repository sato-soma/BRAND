using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody PlayerRigid;

    public GameObject Player;

    private Vector3 Velocity = Vector3.zero;

    public float Jump; //ジャンプ力
    public float MoveSpeed; //移動スピード
    public float RanSpeed; // 早い移動

    private float Speed;

    public static bool RotFlag = false; //回転フラグ

    private bool jumpFlag = false; //ジャンプ
    private bool R_MoveFlag = false;
    private bool L_MoveFlag = false;
    private bool RanFlag = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = Player.GetComponent<Rigidbody>();

        //アニメーション
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Debug.Log(PlayerDeath.HitCount);

        // 移動
        Velocity = Vector3.zero;

        if (PlayerDeath.ReStartFlag == false)
        {
            if (R_MoveFlag == true || L_MoveFlag == true)
            {
                if (RanFlag == true)
                {
                    Speed = RanSpeed;
                    anim.SetFloat("Speed", 10.0f);
                }
                else
                {
                    Speed = MoveSpeed;
                    anim.SetFloat("Speed", 5.0f);
                }

                if (R_MoveFlag == true)
                {
                    Velocity.x += Speed;
                }

                if (L_MoveFlag == true)
                {
                    Velocity.x -= Speed;
                }
            }

            if (jumpFlag == true)
            {
                //ジャンプ中の左右移動をゆっくりにしている。
                Velocity = Velocity.normalized * (Speed / 1.25f) * Time.deltaTime;
            }
            else
            {
                //速度ベクトルの長さを1秒でMoveSpeedだけ進むようにする
                Velocity = Velocity.normalized * Speed * Time.deltaTime;
            }

            //左右どちらかに移動している時
            if (Velocity.magnitude > 0)
            {
                transform.position += Velocity;
            }
            else
            {
                anim.SetFloat("Speed", 0.0f);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0.0f);
        }

        // 方向転換
        if (RotFlag == true)
        {
            Player.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            Player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    //プレイヤーの操作
    private void Update()
    {
        //方向キー右
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Move") > 0)
        {
            R_MoveFlag = true;
            RotFlag = false;
        }
        else
        {
            R_MoveFlag = false;
        }

        //方向キー左
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Move") < 0)
        {
            L_MoveFlag = true;
            RotFlag = true;
        }
        else
        {
            L_MoveFlag = false;
        }

        // ダッシュ
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Ran"))
        {
            RanFlag = true;
        }
        else
        {
            RanFlag = false;
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            if (jumpFlag == false)
            {
                PlayerRigid.AddForce(transform.up * Jump);
                jumpFlag = true;
                anim.SetBool("Jump", true);
            }
        }

    }

    // 当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        // 地上にいたらジャンプ可
        if (collision.gameObject.CompareTag("Grand"))
        {
            jumpFlag = false;
            anim.SetBool("Jump", false);
        }
    }
}

