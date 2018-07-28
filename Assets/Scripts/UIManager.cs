using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = (UIManager)FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    public Text GoldDisplay;
    public InputField Gamble_Money;
    public string Goldtext;
    public GameObject Weapon_Panel, Friend_Panel, Gamble_Panel,Attack_Panel;



    private void Update()
    {
        GoldDisplay.text = "Gold : " + string.Format("{0:#,###}", GameManager.Instance.Gold);
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
        Attack_Panel.SetActive(false);
    }



}
