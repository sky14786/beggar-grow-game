using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class GameManager : MonoBehaviour
{

    //싱글톤 패턴 적용
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
    //변수선언
    public double Gold, MulGold, GoldPerSec, Gamble_Money;
    public int i, Player_No, Player_itemlevel, Player_friendlevel;
    public int[] Upgrade_Level;
    public float onesec, Auto_Save_Time;
    public System.Random Gambel = new System.Random();
    

    // -----------------------------
    [Serializable]
    public struct _PassiveItem
    {
        public double ItemPower;
        public double CurrentCost;
        public bool IsHaveItem;
    }
    [Serializable] //<< 
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


    // 친구 구매
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
                GoldPerSec = temp.ItemPower + (temp.ItemPower * temp.UpgradeLevel) * 0.2;
                FriendItem[FriendNum] = temp;
                StartCoroutine(SaveData.Instance.__SaveData());
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
            StartCoroutine(SaveData.Instance.__SaveData());
            //StartCoroutine(SaveData.Instance.__SaveData());
        }
        else
            Debug.Log("골드가 부족합니다");
    }

    // 무기 구매 
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
                StartCoroutine(SaveData.Instance.__SaveData());
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
    // 버튼 클릭시 돈증가 시스템
    public void _Attack()
    {
        Gold = Gold + 1 * MulGold;
    }


    // 로그인 시 불러온 값을 게임매니저에 적용
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


    // 1초마다 골드 증가
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

    // 자동 저장 시스템
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
        _AutoSave();
    }

    // 도박 시스템
    public void _Gamble(int GambleNum)
    {
        switch (GambleNum)
        {
            case 1:
                {
                    Double.TryParse(UIManager.Instance.Gamble_Money.text, out Gamble_Money);
                    Gold -= Gamble_Money;
                    if (Gambel.Next(0, 100) <= 40)
                    {
                        Gold += (Gamble_Money * 2.25);
                    }
                    UIManager.Instance.Gamble_Money.text = "";
                    Gamble_Money = 0;
                    StartCoroutine(SaveData.Instance.__SaveData());
                    break;
                }
            case 2:
                {
                    Double.TryParse(UIManager.Instance.Gamble_Money.text, out Gamble_Money);
                    Gold -= Gamble_Money;
                    if (Gambel.Next(0, 100) <= 30)
                    {
                        Gold += (Gamble_Money * 2.5);
                    }
                    UIManager.Instance.Gamble_Money.text = "";
                    Gamble_Money = 0;
                    StartCoroutine(SaveData.Instance.__SaveData());
                    break;
                }
            case 3:
                {
                    Double.TryParse(UIManager.Instance.Gamble_Money.text, out Gamble_Money);
                    Gold -= Gamble_Money;
                    if (Gambel.Next(0, 100) <= 20)
                    {
                        Gold += (Gamble_Money * 2.85);
                    }
                    UIManager.Instance.Gamble_Money.text = "";
                    Gamble_Money = 0;
                    StartCoroutine(SaveData.Instance.__SaveData());
                    break;
                }

            case 4:
                {
                    Double.TryParse(UIManager.Instance.Gamble_Money.text, out Gamble_Money);
                    Gold -= Gamble_Money;
                    if (Gambel.Next(0, 100) <= 10)
                    {
                        Gold += (Gamble_Money * 3);
                    }
                    UIManager.Instance.Gamble_Money.text = "";
                    Gamble_Money = 0;
                    StartCoroutine(SaveData.Instance.__SaveData());
                    break;
                }
        }

    }
}


