using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    int count;
    void Start()
    {
        count = 0;
    }

    void Update()
    {
        
    }
    public void IncScore(int a)
    {
        count += a;
        score.text = count.ToString();
    }
}
