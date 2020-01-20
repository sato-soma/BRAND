using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturmGame : MonoBehaviour
{
    public GameObject playerobject;

    public static bool[] RestartFlag = new bool[4]; //イベントから帰ってきたか(イベント後のギミックでfalseにする)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButton("Event") || 
            Event0Image.StopTime0 == true ||Event1Image.StopTime1==true || 
            Event2Image.StopTime2 == true || Event3Image.StopTime3 == true)
        {
            // ステージ1の一つ目イベントから移行
            if (Event0.Event_0Flag == true)
            {
                RestartFlag[0] = true;
                SceneManager.LoadScene("playerMove");
            }

            // ステージ1の二つ目イベントから移行
            if (Event1.Event_1Flag == true)
            {
                RestartFlag[1] = true;               
                SceneManager.LoadScene("playerMove");
                LongFallingFloor.LongPassFlag = true;
            }

            // ステージ2の一つ目イベントから移行
            if (Event2.Event_2Flag == true)
            {
               // RestartFlag[2] = true;
                SceneManager.LoadScene("playerMove");
            }

            // ステージ2の二つ目イベントから移行
            if (Event3.Event_3Flag == true)
            {
              //  RestartFlag[3] = true;
                SceneManager.LoadScene("playerMove");             
            }
        }

       

       






    }
}
