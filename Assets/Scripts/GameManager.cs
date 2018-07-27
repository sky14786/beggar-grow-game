﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameManager)FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public double Gold, MulGold, GoldPerSec;
    public int i, Player_No, Player_itemlevel, Player_friendlevel;
    public int[] Upgrade_Level;
    public float onesec,Auto_Save_Time;

    // -----------------------------
    [Serializable]
    public struct _PassiveItem
    {
        public double ItemPower;    
        public double CurrentCost;
        public bool IsHaveItem;
    }
    [Serializable]
    public struct _FriendItem
    {
        public double ItemPower;
        public double CurrentCost, CostPerLevel;
        public int UpgradeLevel;
        public bool IsHaveItem;
    }
    //---------------------------------
    public List<_PassiveItem> PassiveItem = new List<_PassiveItem>();
    public List<_FriendItem> FriendItem = new List<_FriendItem>();

    public void _FriendBuy(int FriendNum)
    {
        _FriendItem temp = new _FriendItem();
        temp.CostPerLevel = FriendItem[FriendNum].CostPerLevel;
        temp.IsHaveItem = FriendItem[FriendNum].IsHaveItem;
        temp.UpgradeLevel = FriendItem[FriendNum].UpgradeLevel;
        temp.CurrentCost = FriendItem[FriendNum].CurrentCost;
        temp.ItemPower = FriendItem[FriendNum].ItemPower;

        if (FriendItem[FriendNum].IsHaveItem && Gold >= FriendItem[FriendNum].CurrentCost)
        {
            if (FriendItem[FriendNum].UpgradeLevel < 20)// <<<< 여기부터
            {
                Gold -= temp.CurrentCost;
                temp.UpgradeLevel += 1;
                temp.CurrentCost = (temp.UpgradeLevel * temp.CostPerLevel);
                GoldPerSec = temp.ItemPower+(temp.ItemPower * temp.UpgradeLevel) * 0.2;
                FriendItem[FriendNum] = temp;
                //StartCoroutine(SaveData.Instance.__SaveData());
            }
            else
                Debug.Log("최대 업그레이드 수치입니다");
        }
        else if (!FriendItem[FriendNum].IsHaveItem && Gold >= FriendItem[FriendNum].CurrentCost)
        {
            Player_friendlevel += 1;
            temp.IsHaveItem = true;
            Gold -= temp.CurrentCost;
            temp.CurrentCost = temp.CostPerLevel;
            GoldPerSec += temp.ItemPower;
            FriendItem[FriendNum] = temp;
            //StartCoroutine(SaveData.Instance.__SaveData());
        }
        else
            Debug.Log("골드가 부족합니다");
    }


    public void _WeaponBuy(int WeaponNum)
    {
        if (WeaponNum == Player_itemlevel && Gold >= PassiveItem[WeaponNum].CurrentCost)
        {
            if (!PassiveItem[WeaponNum].IsHaveItem)
            {
                _PassiveItem temp = new _PassiveItem();
                temp.ItemPower = PassiveItem[WeaponNum].ItemPower;
                temp.CurrentCost = PassiveItem[WeaponNum].CurrentCost;
                temp.IsHaveItem = true;

                PassiveItem[WeaponNum] = temp;

                Gold -= temp.CurrentCost;
                MulGold += temp.ItemPower;

                Player_itemlevel += 1;
                Debug.Log(WeaponNum + "Level 무기 구매 성공");
                //StartCoroutine(SaveData.Instance.__SaveData());
            }
        }
        else
            Debug.Log("Weapon Level , Gold , IsHaveItem error");
    }
    public void Awake()
    {
        MulGold = 1;
        Upgrade_Level = new int[4];
        Player_No = 999;
        Auto_Save_Time = 15f;
    }
    public void _Attack()
    {
        Gold = Gold + 1 * MulGold;
    }

    public void Player_Check()
    {
       
        Debug.Log("플레이어 체크 시작");
        _PassiveItem temp = new _PassiveItem();
        _FriendItem temp2 = new _FriendItem();
        Debug.Log("아이템 레벨 체크시작");
        for (i = 0; i < Player_itemlevel; i++)
        {
            temp.CurrentCost = PassiveItem[i].CurrentCost;
            temp.ItemPower = PassiveItem[i].ItemPower;
            MulGold += temp.ItemPower;
            temp.IsHaveItem = true;

            PassiveItem[i] = temp;
        }
        Debug.Log("아이템 레벨 체크 종료");
        Debug.Log("친구 레벨 체크 시작");
        for (i = 0; i < Player_friendlevel; i++)
        {
            temp2.CostPerLevel = FriendItem[i].CostPerLevel;
            temp2.CurrentCost = FriendItem[i].CurrentCost;
            temp2.ItemPower = FriendItem[i].ItemPower;
            temp2.UpgradeLevel = Upgrade_Level[i];
            temp2.IsHaveItem = true;


         
            temp2.CurrentCost = (temp2.UpgradeLevel * temp2.CostPerLevel);
            GoldPerSec += temp2.ItemPower + ((temp2.ItemPower * temp2.UpgradeLevel) * 0.2);


            FriendItem[i] = temp2;
        }
        Debug.Log("친구 레벨 체크 종료");
        Debug.Log("플레이어 체크 종료");
    }

    public void _GoldPer()
    {
        if (onesec <= 0f)
        {
            Gold += GoldPerSec;
            onesec = 1f;
            //Debug.Log("돈증가");
        }
        else
        {
            onesec -= Time.deltaTime;
        }

    }
    public void _AutoSave()
    {
        if (Auto_Save_Time <= 0)
        {
            StartCoroutine(SaveData.Instance.__SaveData());
            Auto_Save_Time = 15f;
        }
        else
            Auto_Save_Time -= Time.deltaTime;
      
    }
        
        
    

    private void Update()
    {
        _GoldPer();
     
    }
}

