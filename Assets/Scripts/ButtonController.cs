using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject LoginPanel, Create_Player_Panel;
    public GameObject G;
    private void Awake()
    {
        for (int i = 0; i < transform.GetChildCount(); i++)
        {
            if (transform.GetChild(i).name == "Move_Login")
            {
                G = transform.GetChild(i).gameObject;
                G.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Create_Player_Panel.active = false;
                    LoginPanel.active = true;
                });
            }
            if (transform.GetChild(i).name == "Move_PlayerCreate")
            {
                G = transform.GetChild(i).gameObject;
                G.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Create_Player_Panel.active = true;
                    LoginPanel.active = false;
                });
            }
        }
    }
}
