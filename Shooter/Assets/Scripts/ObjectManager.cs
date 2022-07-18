using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    GameObject objBoss;
    [SerializeField]
    GameObject bossPrefab;

    GameObject[] objEnemyA;
    [SerializeField]
    GameObject enemyAPrefab;

    GameObject[] objEnemyB;
    [SerializeField]
    GameObject enemyBPrefab;

    GameObject[] objPlayerBullet;
    [SerializeField]
    GameObject playerBulletPrefab;

    GameObject[] objEnemyBullet;
    [SerializeField]
    GameObject enemyBulletPrefab;

    GameObject[] pool;

    void Start()
    {
        objEnemyB = new GameObject[10];
        objEnemyA = new GameObject[10];
        objPlayerBullet = new GameObject[100];
        objEnemyBullet = new GameObject[1000];

        Generate();
    }

    void Generate()
    {
        objBoss = Instantiate(bossPrefab);
        objBoss.SetActive(false);

        for (int i = 0; i < objEnemyB.Length; i++)
        {
            objEnemyB[i] = Instantiate(enemyBPrefab);
            objEnemyB[i].SetActive(false);
        }

        for (int i = 0; i < objEnemyA.Length; i++)
        {
            objEnemyA[i] = Instantiate(enemyAPrefab);
            objEnemyA[i].SetActive(false);
        }

        for (int i = 0; i < objEnemyBullet.Length; i++)
        {
            objEnemyBullet[i] = Instantiate(enemyBulletPrefab);
            objEnemyBullet[i].SetActive(false);
        }

        for (int i = 0; i < objPlayerBullet.Length; i++)
        {
            objPlayerBullet[i] = Instantiate(playerBulletPrefab);
            objPlayerBullet[i].SetActive(false);
        }
     } 
    public GameObject MakeObject(string objType)
    {

        switch (objType)
        {
            case "A":
                pool = objEnemyA;
                break;
            case "C":
                pool = objEnemyB;
                break;
            case "B":
                objBoss.SetActive(true);
                return objBoss;
            case "EnemyBullet":
                pool = objEnemyBullet;
                break;
            case "PlayerBullet":
                pool = objPlayerBullet;
                break;
        }
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeSelf) 
            {
                pool[i].SetActive(true);
                    return pool[i];
            }
        }

        return null;
    }
}
