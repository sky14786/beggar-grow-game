using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class LoginScripts : MonoBehaviour
{
    public string url;
    public InputField id, pw;

    private void Awake()
    {
        url = "sky14786.cafe24.com/Login.php";
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(_Login()));
    }

    

    IEnumerator _Login()
    {
        Debug.Log("로그인 시도");

        WWWForm form = new WWWForm();

        form.AddField("id", id.text.ToString());
        form.AddField("pw", pw.text.ToString());

        WWW WebRequest = new WWW(url, form);

        while (!WebRequest.isDone)
        {
            yield return null;
        }

        if (WebRequest.error == null)
        {
            Debug.Log("error null");

            if (WebRequest.text == "로그인 실패")
                Debug.Log(WebRequest.text);
            else
            {
                var n = LitJson.JsonMapper.ToObject(WebRequest.text);
            }

            

            //GameManager.Instance.Player_No = n[0]["no"];

            //GameManager.Instance.Player_friendlevel = n[0]["friendlevel"];
        }
        else
            Debug.Log("error");
        yield break;
    }
}
