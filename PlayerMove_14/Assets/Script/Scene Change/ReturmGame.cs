using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturmGame : MonoBehaviour
{
    public GameObject playerobject;

    public static bool[] RestartFlag = new bool[4]; //イベントから帰ってきたか用(イベント後のギミック内でfalseにする)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButton("Event") || 
            Event0Image.StopTime0 == true ||Event1Image.StopTime1==true || 
            Event2Image.StopTime2 == true || Event3Image.StopTime3 == true)
        {
            // ステージ1の一つ目イベントからステージ１に戻る
            if (Event0.Event_0Flag == true)
            {
                RestartFlag[0] = true;
                SceneManager.LoadScene("playerMove");
            }

            // ステージ1の二つ目イベントからステージ１に戻る
            if (Event1.Event_1Flag == true)
            {
                RestartFlag[1] = true;               
                SceneManager.LoadScene("playerMove");
                LongFallingFloor.LongPassFlag = true;
            }

            // ステージ2の一つ目イベントからステージ2に戻る
            if (Event2.Event_2Flag == true)
            {
               // RestartFlag[2] = true;
                SceneManager.LoadScene("stage2");
            }

            // ステージ2の二つ目イベントからステージ2に戻る
            if (Event3.Event_3Flag == true)
            {
              //  RestartFlag[3] = true;
                SceneManager.LoadScene("stage2");             
            }
        }

       

       






    }
}
