using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuyScripts : MonoBehaviour {
   
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (GameManager.Instance.Gold < GameManager.Instance.PassiveItem[0].CurrentCost)
                return;

            Debug.Log("구매");
            GameManager.Instance._Change();
        });
    }
}
