using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏逻辑控制
/// </summary>
public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float energyValue;
    public float leftTime;//存储以秒为单位
    private void Awake()
    {

        Instance = this;
        energyValue = 1;
        leftTime = 180;
    }

    // Update is called once per frame
    void Update()
    {
        if(energyValue<10) 
        {

            energyValue += Time.deltaTime;
            UIManger.Instance.SetEnergySliderValue();
            DecreaseTimw();

        }
        
    }

    private void DecreaseTimw()
    {
        leftTime -= Time.deltaTime;

        int min = (int)leftTime / 60;
        int sec  =(int)leftTime % 60;
        UIManger.Instance.SetTimeValue(min, sec);


    }
}
