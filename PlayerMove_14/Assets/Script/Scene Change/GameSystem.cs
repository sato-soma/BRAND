using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameSystem : MonoBehaviour
{
    //　スタートボタンを押したら実行する
    private void Update ()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("playerMove");
        }

        
    }
}
