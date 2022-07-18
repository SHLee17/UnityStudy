using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Enemy[] enemy;
    [SerializeField]
    Player player;

    [SerializeField]
    Transform[] objSpawnPos;

    [SerializeField]
    Image[] lifImages;

    [SerializeField]
    GameObject objGameOver;

    [SerializeField]
    Text txtScore;

    int score;

    public ObjectManager objManager;
    public List<Spawn> spawnList;

    int spawnIndex = 0;
    bool spawnEnd;

    float nextEnemySpawnDelay;
    float currentTime;

    [System.Serializable]
    public class Spawn
    {
        public float delay;
        public string type;
        public int point;
    }

    public int Score
    {
        set
        {
            score += value;
            txtScore.text = score.ToString();
        }
    }

    void ReadSpawnFile()
    {
        spawnList = new List<Spawn>();
        spawnIndex = 0;
        spawnEnd = false;

        TextAsset textFile = Resources.Load("Stage") as TextAsset;
        StringReader stringReader = new StringReader(textFile.text);

        while (stringReader != null)
        {
            string txtLineData = stringReader.ReadLine();
            if (txtLineData == null)
                break;

            Spawn data = new Spawn();
            data.delay = float.Parse(txtLineData.Split(',')[0]);
            data.type = txtLineData.Split(',')[1];
            data.point = int.Parse(txtLineData.Split(',')[2]);
            spawnList.Add(data);
        }
        stringReader.Close();

        nextEnemySpawnDelay = spawnList[0].delay;
    }

    void Start()
    {
        ReadSpawnFile();
    }

    private void Update()
    {
        ReSpawnEnemy();
    }

    public void ReSpawnEnemy()
    {
        currentTime += Time.deltaTime;

        if (currentTime > nextEnemySpawnDelay && !spawnEnd)
        {
            int pos = spawnList[spawnIndex].point;


            Enemy tempEnemy = null;
            tempEnemy = objManager.MakeObject(spawnList[spawnIndex].type).GetComponent<Enemy>();

            if (tempEnemy != null)
            {
                tempEnemy.gm = this;
                tempEnemy.rb.velocity = new Vector2(0, enemy[0].speed * -1);
                tempEnemy.transform.position = objSpawnPos[pos].position;

                if (!(tempEnemy is Boss))
                {
                    StartCoroutine(tempEnemy.FireBullet());
                    tempEnemy.player = player.gameObject;
                }
                else
                {
                    Boss temp = tempEnemy as Boss;
                    StartCoroutine(temp.Stop(2));

                }
            }
            //else if(tempBoss != null)
            //{
            //    tempBoss.gm = this;
            //    tempBoss.transform.position = objSpawnPos[pos].position;

            //}

            spawnIndex++;


            if (spawnIndex == spawnList.Count)
            {
                spawnEnd = true;
                return;
            }

            nextEnemySpawnDelay = spawnList[spawnIndex].delay;
            currentTime = 0;
        }
    }

    public void ReSpawnPlayer()
    {
        StartCoroutine(AlivePlayer());
    }

    IEnumerator AlivePlayer()
    {
        player.isHit = true;
        player.transform.position = Vector3.down * 3.5f;
        for (int i = 2; i >= 0; i--)
        {
            if (lifImages[i].enabled)
            {
                lifImages[i].enabled = false;
                break;
            }
        }
        WaitForSeconds delay = new WaitForSeconds(.1f);
        for (int i = 0; i < 10; i++)
        {
            player.gameObject.SetActive(false);
            yield return delay;
            player.gameObject.SetActive(true);
            yield return delay;
        }

        player.isHit = false;

    }
    public void GameOver()
    {
        objGameOver.SetActive(true);
        player.gameObject.SetActive(false);
    }
}
