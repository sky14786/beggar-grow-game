using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMnager : MonoBehaviour {
    private static UIMnager instance;
    public static UIMnager Insatance
    {
        get
        {
            if(instance==null)
            {
                instance = new UIMnager();
            }
            return instance;
        }
    }

    public Text GoldDisplay;

    public void _Attack()
    {
        
    }
}
