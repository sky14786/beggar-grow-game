using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public string url;
  


    private void Awake()
    {
        url = "sky14786.cafe24.com/Save_Data.php";

        GetComponent<Button>().onClick.AddListener(() => _SaveData());
    }

 
    public void _SaveData()
    {

        Debug.Log("데이터 저장");
        StartCoroutine(__SaveData());
       
    }
    IEnumerator __SaveData()
    {
        
        WWWForm form = new WWWForm();
        

        form.AddField("gold", GameManager.Instance.Gold.ToString());
        form.AddField("itemlevel", GameManager.Instance.itemnum);


        WWW webRequest = new WWW(url, form);

        yield return webRequest;

        Debug.Log(webRequest.error);
        Debug.Log("데이터 저장 성공!");
        yield break;
    }
}
