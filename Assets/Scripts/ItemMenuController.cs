using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemMenuController : MonoBehaviour
{
    public GameObject ItemPanel;
    public bool isOpen;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => _Open());
    }

    public void _Open()
    {


        if (isOpen)
        {
            while (true)
            {
                if (ItemPanel.transform.position.x >754)
                {
                    ItemPanel.transform.Translate(-1, 0, 0);
                }
                else
                {
                    isOpen = false;
                    break;
                }
            }
        }
        else
        {
            while (true)
            {
                if (ItemPanel.transform.position.x < 1409)
                {
                    ItemPanel.transform.Translate(1, 0, 0);
                }
                else
                {
                    isOpen = true;
                    break;
                }
            }
        }
    }
}
