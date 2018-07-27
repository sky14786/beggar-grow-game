using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendShopController : MonoBehaviour {

    private void Awake()
    {
        switch (this.name)
        {
            case "Friend1":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._FriendBuy(0));
                    break;
                }
            case "Friend2":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._FriendBuy(1));
                    break;
                }
            case "Friend3":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._FriendBuy(2));
                    break;
                }
            case "Friend4":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._FriendBuy(3));
                    break;
                }
            case "Friend5":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._FriendBuy(4));
                    break;
                }




        }
    }
}
