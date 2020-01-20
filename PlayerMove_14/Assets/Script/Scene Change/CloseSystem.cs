using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CloseSystem : MonoBehaviour
{
    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        SceneManager.LoadScene("playerMove");
    }

    public static void SecondGame()
    {
        SceneManager.LoadScene("stage2");
    }

    public static void CloseGame()
    {
        SceneManager.LoadScene("close");
    }

    public void RstartGame()
    {
        SceneManager.LoadScene("open");
    }

    public void EndGame()
    {

        Application.Quit();
    }


    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        SceneManager.LoadScene("open");

        if (Input.GetKey(KeyCode.B))
            Application.Quit();
    }
}


