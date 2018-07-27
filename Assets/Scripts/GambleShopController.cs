using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GambleShopController : MonoBehaviour {

    private void Awake()
    {
        switch (this.name)
        {
            case "Gamble1":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Gamble(1));
                    break;
                }
            case "Gamble2":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Gamble(2));
                    break;
                }
            case "Gamble3":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Gamble(3));
                    break;
                }
            case "Gamble4":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Gamble(4));
                    break;
                }
            case "Gamble5":
                {
                    GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Gamble(5));
                    break;
                }




        }
    }
}
