using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 游戏启动器
/// </summary>
public class GameStarter : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.PlayMusic(audioClip);
        Invoke("LoadChoiceCardScene", 1.5f);
    }

    private void LoadChoiceCardScene( )
    {

        SceneManager.LoadScene(1);

    }
}
