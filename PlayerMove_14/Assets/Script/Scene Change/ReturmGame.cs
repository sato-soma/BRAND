using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturmGame : MonoBehaviour
{
    public GameObject playerobject;

    public static Vector3 PlayerRestartPosition;
    public static Vector3 HpUiRestartPosition;

    public static int HpResutartCount;
    public static int HpUiResutart;
    public static bool RestartFlag1;



    // Start is called before the first frame update
    void Start()
    {
        PlayerRestartPosition = PlayerMove.PlayerPositioned; //イベント前のPlayer位置保存
        HpUiRestartPosition = HPUI.HpUiPositionOld; //UIの位置保存
        HpResutartCount = HPUI.HitCount; //イベント前のHP保存
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event"))
        {
            if (Event1.Event_1Flag == true)
            {
                RestartFlag1 = true;
                SceneManager.LoadScene("playerMove");
            }
        }


       
    }
}
