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
    public GameObject Gamble_Panel;
  

    private void Update()
    {
        GoldDisplay.text = "Gold : " + GameManager.Instance.Gold.ToString();
    }

}
