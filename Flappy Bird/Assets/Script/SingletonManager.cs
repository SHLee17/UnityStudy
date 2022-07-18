using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private static SingletonManager instance = null;

    public static SingletonManager Instance 
    { 
        get
        {
            if (!instance)
                return null;
            return instance;
        }
        set => instance = value;
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    int score = 0;
    public void SetScore(int n)
    {
        FindObjectOfType<GameManager>().Score = n;
        score = n;
    }
    public int GetScore()
    {
        return score;
    }
  
}
