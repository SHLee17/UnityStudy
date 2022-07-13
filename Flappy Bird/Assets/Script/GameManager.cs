using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public GameObject obj;
    public TextMeshPro text;

    public int Score { 
        get => score;

        set 
        { 
            score = value;
            text.text = Score.ToString();
        }
    }

    void Start()
    {
        Score = 0;
        InvokeRepeating("CreateObjects", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateObjects()
    {
        Instantiate(obj, new Vector3(7.5f, Random.Range(-2, 2.1f), 0), Quaternion.identity);
    }
}
