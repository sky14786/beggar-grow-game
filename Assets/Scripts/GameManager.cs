﻿using System.Collections;
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
    public int i,itemnum,Player_No,Player_itemlevel,Player_friendlevel;
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
    public void _Attack()
    {
        Gold = Gold + 1 * MulGold;
         
    }

    public void Player_Check()
    {
        Debug.Log("플레이어 체크 시작");
        _PassiveItem temp = new _PassiveItem();
        for(i=0;i<Player_itemlevel;i++)
        {
            
            temp.CurrentCost = PassiveItem[i].CurrentCost;
            temp.ItemPower = PassiveItem[i].ItemPower;
            MulGold +=temp.ItemPower;
            temp.IsHaveItem = true;

            PassiveItem[i] = temp;
        }
        Debug.Log("플레이어 체크 종료");
    }
}
