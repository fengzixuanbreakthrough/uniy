using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    /// <summary>
    /// 播放音乐的方法
    /// </summary>
    /// <param name="audioClip">音乐资源</param>
    public void PlayMusic(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();




    }
    /// <summary>
    /// 播放音效的方法
    /// </summary>
    /// <param name="audioClip">音效资源</param>

    public void PlaySound(AudioClip audioClip)
    {


        audioSource.PlayOneShot(audioClip);



    }
}
