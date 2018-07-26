using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponShopController : MonoBehaviour {

    private void Awake()
    {
        switch (this.name)
        {
            case "Weapon1":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._WeaponBuy(0));
                    break;
                }
            case "Weapon2":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._WeaponBuy(1));
                    break;
                }
            case "Weapon3":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._WeaponBuy(2));
                    break;
                }
            case "Weapon4":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._WeaponBuy(3));
                    break;
                }
            case "Weapon5":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._WeaponBuy(4));
                    break;
                }




        }
    }
}
