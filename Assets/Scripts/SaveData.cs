﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    private static SaveData instance;
    public static SaveData Instance
    {
        get
        {
            if(instance==null)
            {
                instance = (SaveData)FindObjectOfType<SaveData>();
            }
            return instance;
        }
    }
    public string url,temp;
  


    private void Awake()
    {
        Debug.Log("데이터 저장 URL 설정 완료!");
        url = "sky14786.cafe24.com/Save_Data.php";
        //GetComponent<Button>().onClick.AddListener(() => StartCoroutine(__SaveData()));
    }

 
   
   public IEnumerator __SaveData()
    {
        Debug.Log("데이터 저장 시작");
        WWWForm form = new WWWForm();

        form.AddField("no", GameManager.Instance.Player_No);
        form.AddField("gold", GameManager.Instance.Gold.ToString());
        form.AddField("itemlevel", GameManager.Instance.Player_itemlevel);
        form.AddField("friendlevel", GameManager.Instance.Player_friendlevel);

        if (GameManager.Instance.Player_friendlevel == 99)
        {
        }
        else
        {
            for (int i = 0; i < GameManager.Instance.Player_friendlevel; i++)
            {
                temp += GameManager.Instance.FriendItem[i].UpgradeLevel.ToString() + "/";
            }
        }

        Debug.Log("Upgrade Level :" + temp);
        form.AddField("upgradelevel", temp);


   
        WWW WebRequest = new WWW(url, form);

      
        yield return WebRequest;

        Debug.Log(WebRequest.error);
        Debug.Log("데이터 저장 성공!");
        yield break;
    }
}
