using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                //instance =
                instance = (GameManager)FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public double Gold, MulGold;
    //public bool[] item = { false, false, false };
    public int i,itemnum;
    public List<bool> item = new List<bool>();

    [Serializable]
    public struct _PassiveItem
    {
        public double ItemPower;
        public double CurrentCost;
        public bool IsHaveItem;
    }

    public List<_PassiveItem> PassiveItem = new List<_PassiveItem>();

    public void _Change()
    {
        _PassiveItem temp = new _PassiveItem();
        temp.ItemPower = PassiveItem[itemnum].ItemPower;
        temp.CurrentCost = PassiveItem[itemnum].CurrentCost;
        temp.IsHaveItem = true;

        PassiveItem[0] = temp;
        Debug.Log("패시브아이템 변환 완료");
        Gold -= temp.CurrentCost;
        Debug.Log("아이템 구매! 골드 차감 : -" + temp.CurrentCost.ToString());

        Debug.Log("이전 아이템 파워 : " + MulGold);
        MulGold += temp.ItemPower;
        Debug.Log("아이템 효과 적용 완료 현제 아이템 파워: " + MulGold);

        itemnum += 1;
        Debug.Log("아이템 레벨 증가! 현 레벨: " + itemnum);
        

    }
    


    private void Awake()
    {
        MulGold = 1;
        itemnum = 0;
    }
    

    //public void _MulGold(long plus,int itemnum)
    //{
     
    //        if (item[itemnum])
    //            MulGold += plus;
    //}

    public void _Attack()
    {
        Gold = Gold + 1 * MulGold;
         
    }
}

