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
                instance = (GameManager)FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public double Gold, MulGold,GoldPerSec;
    public int i,Player_No,Player_itemlevel,Player_friendlevel;
    public float onesec;

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
        public double CurrentCost,CostPerLevel;
        public int UpgradeLevel;
        public bool IsHaveItem;
    }
    //---------------------------------
    public List<_PassiveItem> PassiveItem = new List<_PassiveItem>();
    public List<_FriendItem> FriendItem = new List<_FriendItem>();
 
    public void _FriendBuy(int FriendNum)
    {
        
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
            }
        }
        else
        Debug.Log("Weapon Level , Gold , IsHaveItem error");
    }
    private void Awake()
    {
        MulGold = 1;
      
        Player_No = 999;
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
        for(i=0;i<Player_itemlevel;i++)
        {
            temp.CurrentCost = PassiveItem[i].CurrentCost;
            temp.ItemPower = PassiveItem[i].ItemPower;
            MulGold +=temp.ItemPower;
            temp.IsHaveItem = true;

            PassiveItem[i] = temp;
        }
        Debug.Log("아이템 레벨 체크 종료");
        Debug.Log("친구 레벨 체크 시작");
        for(i=0;i<Player_friendlevel;i++)
        {
            temp2.CostPerLevel = FriendItem[i].CostPerLevel;
            temp2.CurrentCost = FriendItem[i].CurrentCost;
            temp2.ItemPower = FriendItem[i].ItemPower;
            temp2.UpgradeLevel = FriendItem[i].UpgradeLevel;
            temp2.IsHaveItem = true;


            temp2.ItemPower *= FriendItem[i].UpgradeLevel * 0.2;
            temp2.CurrentCost += FriendItem[i].UpgradeLevel * FriendItem[i].CostPerLevel;
            GoldPerSec += temp2.ItemPower;
            

            FriendItem[i] = temp2;
        }
        Debug.Log("친구 레벨 체크 종료");
        Debug.Log("플레이어 체크 종료");
    }

    public void _GoldPer()
    {
       if(onesec>=1f)
        {
            onesec -= Time.deltaTime;
        }
       else
        {
            Gold += GoldPerSec;
            onesec = 1f;
        }
    }

    private void Update()
    {
        _GoldPer();
    }
}

