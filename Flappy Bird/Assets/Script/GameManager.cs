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
        
        //InvokeRepeating("CreateObjects", 1, 2);

        StartCoroutine(MyCoroutine());
        SingletonManager.Instance.SetScore(10);
    }

    void Update()
    {
        
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            Instantiate(obj, new Vector3(7.5f, Random.Range(-2, 2.1f), 0), Quaternion.identity);
        }
    }
    //void CreateObjects()
    //{
    //    Instantiate(obj, new Vector3(7.5f, Random.Range(-2, 2.1f), 0), Quaternion.identity);
    //}
}
