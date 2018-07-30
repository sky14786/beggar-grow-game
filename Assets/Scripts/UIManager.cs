using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UIManager)FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    public Text GoldDisplay;
    public InputField Gamble_Money;
    public string Goldtext;
    public GameObject Weapon_Panel, Friend_Panel, Gamble_Panel, Attack_Panel;
    public Button AutoTouch_Btn, DoubleGold_Btn;



    private void Update()
    {
        GoldDisplay.text = "Gold : " + string.Format("{0:#,###}", GameManager.Instance.Gold);
        _AutoTouchButtonCheck();
        _DoubleGoldButtonCheck();
    }

    public void _AttackOn()
    {
        _PanelOff();
        Attack_Panel.SetActive(true);
    }

    public void _WeaponON()
    {
        Debug.Log("웨폰온");
        _PanelOff();
        Weapon_Panel.SetActive(true);

    }

    public void _GambleON()
    {
        Debug.Log("겜블온");
        _PanelOff();
        Gamble_Panel.SetActive(true);
    }

    public void _FriendON()
    {
        Debug.Log("프랜즈온");
        _PanelOff();
        Friend_Panel.SetActive(true);
    }

    public void _PanelOff()
    {
        Weapon_Panel.SetActive(false);
        Friend_Panel.SetActive(false);
        Gamble_Panel.SetActive(false);
        //Attack_Panel.SetActive(false);
    }

    public void _AutoTouchOn()
    {
        StartCoroutine(GameManager.Instance._AutoTouch());
    }

    public void _AutoTouchButtonCheck()
    {
        if (GameManager.Instance.Skills[0].IsEnabled)
            AutoTouch_Btn.gameObject.SetActive(true);
        else
            AutoTouch_Btn.gameObject.SetActive(false);
    }
    public void _DoubleGoldOn()
    {
        StartCoroutine(GameManager.Instance._DoubleGold());
    }
    public void _DoubleGoldButtonCheck()
    {
        if (GameManager.Instance.Skills[1].IsEnabled)
            DoubleGold_Btn.gameObject.SetActive(true);
        else
            DoubleGold_Btn.gameObject.SetActive(false);
    }

}
