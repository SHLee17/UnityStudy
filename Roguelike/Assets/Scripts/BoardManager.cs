using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int minimum, int maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }
    }
    public int colums = 8;
    public int rows = 8;

    public Count wallCount = new Count(5,9);
    public Count foodCount = new Count(1, 5);

    [SerializeField]
    GameObject exit;

    [SerializeField]
    GameObject[] floorTiles;

    [SerializeField]
    GameObject[] wallTiles;

    [SerializeField]
    GameObject[] foodTiles;

    [SerializeField]
    GameObject[] enemyTiles;

    [SerializeField]
    GameObject[] otherWallTiles;

    Transform boardHolder;
    List<Vector3> gridPosition = new List<Vector3>();

    void InitGrid()
    {
        gridPosition.Clear();

        for (int x = 0; x < colums; x++)
        {
            for (int y = 0; y < rows; y++)
                gridPosition.Add(new Vector3(x, y, 0));
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("BoardHolder").transform; ;
        for (int x = -1; x < colums + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject temp;
                GameObject tempBoard;
                if (x == -1 || x == colums || y == -1 || y == rows)
                    temp = otherWallTiles[Random.Range(0, otherWallTiles.Length)];
                else
                    temp = floorTiles[Random.Range(0, floorTiles.Length)];

                if (temp != null)
                    tempBoard = Instantiate(temp, new Vector3(x, y, 0), Quaternion.identity, boardHolder);
            }
        }
    }

    public void SetupScene(int level) 
    {
        BoardSetup();

        InitGrid();

        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randPos = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            Instantiate(tileChoice, randPos, Quaternion.identity);
        }
    }
    Vector3 RandomPosition()
    {
        int randIndex = Random.Range(0, gridPosition.Count);

        Vector3 randPos = gridPosition[randIndex];

        gridPosition.RemoveAt(randIndex);

        return randPos;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
