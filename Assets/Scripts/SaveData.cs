using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public string url;
  


    private void Awake()
    {
        Debug.Log("데이터 저장 URL 설정 완료!");
        url = "sky14786.cafe24.com/Save_Data.php";
        GetComponent<Button>().onClick.AddListener(() => _SaveData());
    }

 
    public void _SaveData()
    {

        
        StartCoroutine(__SaveData());
       
    }
    IEnumerator __SaveData()
    {
        Debug.Log("데이터 저장 시작");
        WWWForm form = new WWWForm();

        form.AddField("no", GameManager.Instance.Player_No);
        form.AddField("gold", GameManager.Instance.Gold.ToString());
        form.AddField("itemlevel", GameManager.Instance.Player_itemlevel);
        form.AddField("friendlevel", GameManager.Instance.Player_friendlevel);


        WWW webRequest = new WWW(url, form);

        yield return webRequest;

        Debug.Log(webRequest.error);
        Debug.Log("데이터 저장 성공!");
        yield break;
    }
}
