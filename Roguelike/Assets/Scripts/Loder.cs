using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loder : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    void Awake()
    {
        if (GameManager.Instance == null)
            Instantiate(gm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
