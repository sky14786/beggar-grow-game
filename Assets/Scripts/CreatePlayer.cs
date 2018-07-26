using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour {
    public string url;
    public InputField id, pw, nick_name;
    public GameObject Create_Player_Panel;

    private void Awake()
    {
        Debug.Log("계정생성 URL 설정 완료!");
        url = "sky14786.cafe24.com/Create_Player.php";
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(_Create_Player()));
        
    }

    IEnumerator _Create_Player()
    {
        Debug.Log("계정 생성 시도");
        WWWForm form = new WWWForm();

        form.AddField("id", id.text);
        form.AddField("pw", pw.text);
        form.AddField("nick_name", nick_name.text);

        WWW WebRequest = new WWW(url, form);
        while (!WebRequest.isDone)
        {
            yield return null;
        }

        if (WebRequest.error == null)
        {
            Debug.Log("계정 생성 완료");
            Create_Player_Panel.active = false;
            yield break;
        }
        else
        {
            Debug.Log(WebRequest.error);
            yield break;
        }
    }

    
}
