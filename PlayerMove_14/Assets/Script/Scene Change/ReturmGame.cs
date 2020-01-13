using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturmGame : MonoBehaviour
{
    public GameObject playerobject;

    public static Vector3 PlayerRestartPosition0;
    public static Vector3 PlayerRestartPosition1;
    public static Vector3 HpUiRestartPosition;

    public static int HpResutartCount;
    public static int HpUiResutart;
    public static bool RestartFlag1;
    public static bool RestartFlag0;



    // Start is called before the first frame update
    void Start()
    {
        PlayerRestartPosition0 = PlayerMove.PlayerPositioned0; //イベント0前のPlayer位置保存
        PlayerRestartPosition1 = PlayerMove.PlayerPositioned1; //イベント1前のPlayer位置保存

        // HpUiRestartPosition = HPUI.HpUiPositionOld; //UIの位置保存
        // HpResutartCount = HPUI.HitCount; //イベント前のHP保存

    }

    // Update is called once per frame
    void Update()
    {
        // 一つ目イベントから移行
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event")|| Event0Image.StopTime0==true)
        {
            if (Event0.Event_0Flag == true)
            {
                RestartFlag0 = true;
                SceneManager.LoadScene("playerMove");
            }
        }

        // 二つ目のイベントから移行
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event") || Event1Image.StopTime1 == true)
        {
            if (Event1.Event_1Flag == true)
            {
                RestartFlag1 = true;
                LongFallingFloor.LongPassFlag = true;
                SceneManager.LoadScene("playerMove");
            }
        }

       




    }
}
