using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturmGame : MonoBehaviour
{
    public GameObject playerobject;

    public static bool[] RestartFlag = new bool[4]; //イベントから帰ってきたか

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ステージ1の一つ目イベントから移行
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event") || Event0Image.StopTime0 == true)
        {
            if (Event0.Event_0Flag == true)
            {
                RestartFlag[0] = true;
                SceneManager.LoadScene("playerMove");
            }
        }

        // ステージ1の二つ目のイベントから移行
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event") || Event1Image.StopTime1 == true)
        {
            if (Event1.Event_1Flag == true)
            {
                RestartFlag[1] = true;
                LongFallingFloor.LongPassFlag = true;
                SceneManager.LoadScene("playerMove");
            }
        }






    }
}
