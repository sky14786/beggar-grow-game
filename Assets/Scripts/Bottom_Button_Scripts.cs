using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottom_Button_Scripts : MonoBehaviour
{


    private void Awake()
    {
        switch (this.name)
        {
            case "Move_Weapon":
                {
                    GetComponent<Button>().onClick.AddListener(() => UIManager.Instance._WeaponON());
                    break;
                }
            case "Move_Friend":
                {
                    GetComponent<Button>().onClick.AddListener(() => UIManager.Instance._FriendON());
                    break;
                }
            case "Move_Gamble":
                {
                    GetComponent<Button>().onClick.AddListener(() => UIManager.Instance._GambleON());
                    break;
                }
            case "Move_Attack":
                {
                    GetComponent<Button>().onClick.AddListener(() => UIManager.Instance._AttackOn());
                    break;
                }
        }
    }

}
