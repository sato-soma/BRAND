using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BGM : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
            //画面遷移してもオブジェクトが壊れないようにする
            DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "close")
        {
            audioSource.Stop();
        }
    }
}
