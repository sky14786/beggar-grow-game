using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScripts : MonoBehaviour {

	void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Instance._Attack());
    }
}
