using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// 游戏场景中的UI管理
/// </summary>
public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public Text energyText;
    public Slider energySlider;
    public Text leftTimeText;
    private List<int> cardIDList = new List<int>();
    public GameObject cardGo;
    public Transform nextCardT;
    public Sprite[] cardSprites;
    private int maxContentNum=4;//卡牌面板最大容纳量
    private int currentDoardNum=0;//当前面板上的卡牌数
    public Transform[] boardCardsT;//卡牌面板上的四个空位置
    public Transform boardTrans;//卡牌面板的Transform引用



    private void Awake()
    {
        Instance = this;
        CreatNewCard();
        //for (int i = 0; i < 10; i++)
        //{
        //    CreatNewCard();
        //}
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetEnergySliderValue()
    {
        energyText.text = ((int)GameController.Instance.energyValue).ToString();
        energySlider.value = GameController.Instance.energyValue / 10;

    }
    public void SetTimeValue(int min,int sec)
    {
        leftTimeText.text=min.ToString()+":"+sec.ToString();

    }


    private void CreatNewCard()
    {
        if (currentDoardNum>maxContentNum)
        {
            return;
            
        }

        GameObject go = Instantiate(cardGo, nextCardT);
        
        go.transform.localPosition = Vector3.zero;
        int randomNum = Random.Range(1, 11);
        //Debug.Log(randomNum);
        while (cardIDList.Contains(randomNum))//当前列表是否包含随机出来的卡牌ID
        {
            //已包含，则重新生成
            randomNum = Random.Range(1, 11);
        }
        cardIDList.Add(randomNum);
        Debug.Log(randomNum);
        Image image = go.transform.GetChild(0).GetComponent<Image>();
        image.sprite = cardSprites[randomNum - 1];
        if (currentDoardNum < maxContentNum)
        {
            MoveCardToBoard(currentDoardNum);
            currentDoardNum++;

        }


    }
    /// <summary>
    /// 移动卡牌到卡牌面板
    /// </summary>
    /// <param name="posID"></param>
    private void MoveCardToBoard(int posID)
    {
        Transform t = nextCardT.GetChild(0);
        //t.SetParent(boardCardsT[posID]);
        //t.localPosition = Vector3.zero;
        t.SetParent(boardTrans);
        t.DOLocalMove(boardCardsT[posID].localPosition, 0.2f).OnComplete(CompleteMoveTween);



    }
    /// <summary>
    /// 某张卡牌移动动画完成后调用的方法
    /// </summary>
    private void CompleteMoveTween()
    {
        CreatNewCard();

    }
}
