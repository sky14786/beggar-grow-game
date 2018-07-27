using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class LoginScripts : MonoBehaviour
{
    public string url;
    public InputField id, pw;
    public GameObject Login_Panel;
    

    private void Awake()
    {
        Debug.Log("로그인 URL 설정 완료!");
        url = "sky14786.cafe24.com/Login.php";
        GetComponent<Button>().onClick.AddListener(() => StartCoroutine(_Login()));
    }

    

    IEnumerator _Login()
    {
        string[] temp_upgrade_level;
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
            {
                Debug.Log(WebRequest.text);
                yield break;
            }
            else
            {
                Debug.Log("로그인 성공");
                Debug.Log(WebRequest.text);
                var n = LitJson.JsonMapper.ToObject(WebRequest.text);

               
                int.TryParse(n[0]["no"].ToString(),out GameManager.Instance.Player_No);
                int.TryParse(n[0]["itemlevel"].ToString(), out GameManager.Instance.Player_itemlevel);
                int.TryParse(n[0]["friendlevel"].ToString(), out GameManager.Instance.Player_friendlevel);
                double.TryParse(n[0]["gold"].ToString(), out GameManager.Instance.Gold);
                temp_upgrade_level = n[0]["upgradelevel"].ToString().Split('#');
                for(int i = 0; i<temp_upgrade_level.Length;i++)
                {
                    int.TryParse(temp_upgrade_level[i], out GameManager.Instance.Upgrade_Level[i]);
                }


                GameManager.Instance.Player_Check();


                Debug.Log("플레이어 정보 로드 완료");
                Login_Panel.active = false;
                
                gameObject.active = false;
                //Debug.Log(GameManager.Instance.Player_friendlevel);
                //Debug.Log(GameManager.Instance.Player_itemlevel);
                //Debug.Log(GameManager.Instance.Player_No);
                //Debug.Log(GameManager.Instance.Gold);
                yield break;
            }
        }
        else
            Debug.Log("error");
            yield break;
      
    }
}
