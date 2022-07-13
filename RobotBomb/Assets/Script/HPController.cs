using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    GameObject objHp;
    void Start()
    {
        objHp = GameObject.Find("Hp");
    }

    void Update()
    {
        
    }

    void HpControl()
    {
        objHp.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
