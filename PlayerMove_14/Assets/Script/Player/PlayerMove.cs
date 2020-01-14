using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody PlayerRigid;

    public GameObject Player;

    public static Vector3 PlayerPositioned0; //シーン0以降前のPlayerの位置保存用
    public static Vector3 PlayerPositioned1; //シーン1以降前のPlayerの位置保存用

    private Vector3 Velocity = Vector3.zero;

    public float Jump; //ジャンプ力ぅぅぅ
    public float MoveSpeed; //移動スピード
    public float RanSpeed; // 早い移動

    private float Speed;

    public static bool RotFlag = false; //回転フラグ

    private bool jumpFlag = false; //ジャンプ
    private bool R_MoveFlag = false;
    private bool R_RanFlag = false;
    private bool L_MoveFlag = false;
    private bool L_RanFlag = false;

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
        // 移動
        Velocity = Vector3.zero;

        if (PlayerDeath.ReStartFlag == false)
        {

            if (R_MoveFlag == true || L_MoveFlag == true)
            {
                Speed = MoveSpeed;
                
                anim.SetFloat("Speed", 5.0f);
                
                if (R_MoveFlag == true)
                {                  
                    Velocity.x += Speed;                
                }

                if(L_MoveFlag==true)
                {
                    Velocity.x -= Speed;
                }
            }

            if (R_RanFlag == true || L_RanFlag == true)
            {
                Speed = RanSpeed;

                anim.SetFloat("Speed", 10.0f);
                
                if (L_RanFlag == true)
                {              
                    Velocity.x -= Speed;
                }
                else if(R_RanFlag==true)
                {
                    Velocity.x += Speed;  
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
                PlayerPositioned0 = transform.position;
                PlayerPositioned1 = transform.position;
            }
            else
            {
                anim.SetFloat("Speed", 0.0f);
            }
        }

        // 方向転換
        if (RotFlag == true)
        {
            //var target = Quaternion.Euler(new Vector3(0, 180, 0));
            //var nowRot = transform.rotation;

            //if (Quaternion.Angle(nowRot, target) <= 1)
            //{
            //    transform.rotation = target;
            //}
            //else
            //{
            //    transform.Rotate(new Vector3(0, RotSpeed, 0));
            //}

            Player.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            //var target = Quaternion.Euler(new Vector3(0, 0, 0));
            //var nowRot = transform.rotation;

            //if (Quaternion.Angle(nowRot, target) <= 1)
            //{
            //    transform.rotation = target;
            //}
            //else
            //{
            //    transform.Rotate(new Vector3(0, RotSpeed, 0));
            //}

            Player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    //プレイヤーの操作
    private void Update() 
    {
        //方向キー右
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)|| Input.GetAxis("Move") > 0)
        {

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Ran"))
            {
                R_RanFlag = true;
                R_MoveFlag = false;
            }
            else
            {
                R_MoveFlag = true;
                R_RanFlag = false;
            }
            RotFlag = false;
        }
        else
        {
            R_RanFlag = false;
            R_MoveFlag = false;
        }

        //方向キー左
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Move") < 0) 
        {

            if (Input.GetKey(KeyCode.LeftShift)|| Input.GetButton("Ran"))
            {
                L_RanFlag = true;
                L_MoveFlag = false;
            }
            else
            {
                L_MoveFlag = true;
                L_RanFlag = false;
            }
            RotFlag = true;
        }
        else
        {
            L_MoveFlag = false;
            L_RanFlag = false;
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

    //private void OnCollisionExit(Collision collision) //離れたら
    //{
    //    if (collision.gameObject.CompareTag("MoveGrand"))//動く床用
    //    {
    //        transform.SetParent(null);
    //    }
    //}

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Event"))
    //    {
    //        StopFlag = true;
    //    }
    //}

    //private void OnTriggerExit(Collider collision)
    //{
    //    if (collision.gameObject.CompareTag("Event"))
    //    {
    //        StopFlag = false;
    //    }
    //}


}

