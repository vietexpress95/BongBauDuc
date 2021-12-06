using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BongBauDuc_GameManager : MonoBehaviour
{
    public static BongBauDuc_GameManager ins;
    public GameObject fishPrefab;
    public GameObject playerPrefab;

    [Header("------ UI ------")]
    public GameObject startGamePanel;
    public Text countdownRunGameText;
    public GameObject endGamePanel;
    public Text resultText;
    public Button reviveButton;
    public Button restartGameButton;

    [Header("------ points ------")]
    public Transform[] up_Points;
    public Transform[] right_Points;
    public Transform[] left_Points;

    // logic game
    [HideInInspector] public bool isStartGame = false;
    [HideInInspector] public bool isEndGame = false;
    [HideInInspector] public bool playerAlive = true;

    [HideInInspector] public float fishSpeed;
    [HideInInspector] public float numberOfFish;

    [Header("------- locations --------")]
    public GameObject[] locations;
     public bool[] locationAlive;
    public BongBauDuc_Bot[] bots;

    public int botLenght;

    private void Awake()
    {
        ins = this;
    }    

    void Start()
    {
        Time.timeScale = 1;
        fishSpeed = 2;
        restartGameButton.onClick.AddListener(Onclick_restartGame);
        reviveButton.onClick.AddListener(RevivePlayer);

        locationAlive = new bool[locations.Length];
        botLenght = bots.Length;
    }

    public void StartGame()
    {
        if(isStartGame == false)
        {
            startGamePanel.SetActive(false);
            isStartGame = true;
            StartSpawnFishFollowFile();
            StartCoroutine(RunTimePlayGame());
        }
    }

    private void Update() {
        if(botLenght == 0 && isEndGame == false)
        {
            isEndGame = true;
            StartCoroutine(CheckEndGame());
        }
    }

    private IEnumerator RunTimePlayGame()
    {
        for(int i = 0; i < 45; i++)
        {
            if(isEndGame == true)
            {
                if(i != 0)
                {
                    yield return new WaitForSeconds(1);
                }

                if(i == 44)
                {
                    StartCoroutine(CheckEndGame());
                }
                else
                {
                    countdownRunGameText.text = (43 - i).ToString(); 
                }
            }
        }
    }

    private void StartSpawnFishFollowFile()
    {
        for(int i = 0 ;i < locationAlive.Length; i++)
        {
            locationAlive[i] = true;
        }

        StartCoroutine(SpawnA1());
        StartCoroutine(SpawnA2());
        StartCoroutine(SpawnA3());
        StartCoroutine(SpawnA4());
        StartCoroutine(SpawnA5());

        StartCoroutine(SpawnB1());
        StartCoroutine(SpawnB2());
        StartCoroutine(SpawnB3());
        StartCoroutine(SpawnB4());
        StartCoroutine(SpawnB5());

        StartCoroutine(SpawnC1());
        StartCoroutine(SpawnC2());
        StartCoroutine(SpawnC3());
        StartCoroutine(SpawnC4());
        StartCoroutine(SpawnC5());
    }

    private IEnumerator SpawnA1()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].a1 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].a1);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = up_Points[0];
                    f.direction = FishDirection.up;

                    StartCoroutine(FindLiveLocation2(0, 0));
                }
            }
        }
    }
    private IEnumerator SpawnA2()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].a2 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].a2);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = up_Points[1];
                    f.direction = FishDirection.up;

                    StartCoroutine(FindLiveLocation2(0, 1));
                }
            }
        }
    }
    private IEnumerator SpawnA3()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].a3 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].a3);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = up_Points[2];
                    f.direction = FishDirection.up;

                    StartCoroutine(FindLiveLocation2(0, 2));
                }
            }
        }
    }
    private IEnumerator SpawnA4()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].a4 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].a4);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = up_Points[3];
                    f.direction = FishDirection.up;

                    StartCoroutine(FindLiveLocation2(0, 3));
                }
            }
        }
    }
    private IEnumerator SpawnA5()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].a5 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].a5);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = up_Points[4];
                    f.direction = FishDirection.up;

                    StartCoroutine(FindLiveLocation2(0, 4));
                }
            }
        }
    }
    private IEnumerator SpawnB1()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].b1 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].b1);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = left_Points[0];
                    f.direction = FishDirection.left;

                    StartCoroutine(FindLiveLocation2(1, 0));
                }
            }
        }
    }
    private IEnumerator SpawnB2()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].b2 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].b2);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = left_Points[1];
                    f.direction = FishDirection.left;

                    StartCoroutine(FindLiveLocation2(1, 1));
                }
            }
        }
    }
    private IEnumerator SpawnB3()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].b3 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].b3);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = left_Points[2];
                    f.direction = FishDirection.left;

                    StartCoroutine(FindLiveLocation2(1, 2));
                }
            }
        }
    }
    private IEnumerator SpawnB4()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].b4 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].b4);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = left_Points[3];
                    f.direction = FishDirection.left;

                    StartCoroutine(FindLiveLocation2(1, 3));
                }
            }
        }
    }
    private IEnumerator SpawnB5()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].b5 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].b5);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = left_Points[4];
                    f.direction = FishDirection.left;

                    StartCoroutine(FindLiveLocation2(1, 4));
                }
            }
        }
    }
    private IEnumerator SpawnC1()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].c1 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].c1);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = right_Points[0];
                    f.direction = FishDirection.right;

                    StartCoroutine(FindLiveLocation2(1, 0));
                }
            }
        }
    }
    private IEnumerator SpawnC2()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].c2 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].c2);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = right_Points[1];
                    f.direction = FishDirection.right;

                    StartCoroutine(FindLiveLocation2(1, 1));
                }
            }
        }
    }
    private IEnumerator SpawnC3()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].c3 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].c3);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = right_Points[2];
                    f.direction = FishDirection.right;

                    StartCoroutine(FindLiveLocation2(1, 2));
                }
            }
        }
    }
    private IEnumerator SpawnC4()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].c4 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].c4);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = right_Points[3];
                    f.direction = FishDirection.right;

                    StartCoroutine(FindLiveLocation2(1, 3));
                }
            }
        }
    }
    private IEnumerator SpawnC5()
    {
        for(int i = 0; i < BongBauDuc_ReadFile.ins.tableSize; i++)
        {
            if(isEndGame == false)
            {
                if(BongBauDuc_ReadFile.ins.levelList.levels[i].c5 >= 0)
                {
                    yield return new WaitForSeconds(BongBauDuc_ReadFile.ins.levelList.levels[i].c5);

                    var fish = Instantiate(fishPrefab);
                    BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                    f.startPoint = right_Points[4];
                    f.direction = FishDirection.right;

                    StartCoroutine(FindLiveLocation2(1, 4));
                }
            }
        }
    }

    private IEnumerator SpawnTurn1()
    {
        fishSpeed = 2;
        numberOfFish = 2;
        for(int i = 0; i < 7; i++)
        {
            if(i != 0)
            {
                yield return new WaitForSeconds(2);
            }

            int ranDir = Random.Range(0, 3);

            SpawnFish(ranDir);
        }

        StartCoroutine(SpawnTurn2());
    }

    private IEnumerator SpawnTurn2()
    {
        fishSpeed = 2f;
        numberOfFish = 3;
        yield return new WaitForSeconds(3);
        for(int i = 0; i < 7; i++)
        {
            if(i != 0)
            {
                yield return new WaitForSeconds(2f);
            }

            int ranDir = Random.Range(0, 3);

            SpawnFish(ranDir);
        }

        StartCoroutine(SpawnTurn3());
    }

    private IEnumerator SpawnTurn3()
    {
        fishSpeed = 2f;
        numberOfFish = 2;
        yield return new WaitForSeconds(3);
        for(int i = 0; i < 7; i++)
        {
            if(i != 0)
            {
                yield return new WaitForSeconds(2f);
            }

            int ranDir = Random.Range(0, 3);

            for(int j = 0 ;j < locationAlive.Length; j++)
            {
                locationAlive[j] = true;
            }
            SpawnFish2(true);
            SpawnFish2(false);
        }
    }

    private void SpawnFish(int dir)
    {
        // reset lại các điểm sống sót
        for(int i = 0 ;i < locationAlive.Length; i++)
        {
            locationAlive[i] = true;
        }

        if(dir == 0) // sinh ra ở up
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = up_Points[ranLocation];
                f.direction = FishDirection.up;

                FindLiveLocation(dir, ranLocation);
            }
        }
        else if(dir == 1) // sinh ra ở right
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = right_Points[ranLocation];
                f.direction = FishDirection.right;

                FindLiveLocation(dir, ranLocation);
            }
        }
        else // sinh ra ở left
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = left_Points[ranLocation];
                f.direction = FishDirection.left;

                FindLiveLocation(dir, ranLocation);
            }
        }

        FindLocationForBots();
    }

    private void SpawnFish2(bool doc = true)
    {
        // reset lại các điểm sống sót
        int dir = doc == true ?  0 : 1;

        if(doc == true) // sinh ra ở up
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = up_Points[ranLocation];
                f.direction = FishDirection.up;

                FindLiveLocation(dir, ranLocation);
            }
        }
        else if(doc == false && Random.Range(0, 1) == 0) // sinh ra ở right
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = right_Points[ranLocation];
                f.direction = FishDirection.right;

                FindLiveLocation(dir, ranLocation);
            }
        }
        else // sinh ra ở left
        {
            int[] choose = {-1, -1, -1, -1, -1};
            for(int j = 0; j < numberOfFish; j++)
            {
                int ranLocation;
                do
                {
                    ranLocation = Random.Range(0, 5);
                }
                while(CheckChoose(choose, ranLocation));
                
                choose[j] = ranLocation;

                var fish = Instantiate(fishPrefab);
                BongBauDuc_Fish f = fish.GetComponent<BongBauDuc_Fish>();
                f.startPoint = left_Points[ranLocation];
                f.direction = FishDirection.left;

                FindLiveLocation(dir, ranLocation);
            }
        }

        FindLocationForBots();
    }

    private void FindLocationForBots()
    {
        for(int i = 0; i < bots.Length; i++)
        {
            if(bots[i] == null) continue;
            if(bots[i].isDie == true) continue;
            StartCoroutine(bots[i].FindLocationToRun());
        }
    }

    private void FindLiveLocation(int direction, int index)
    {
        if(direction == 0) // dọc
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index + i * 5] = false;
            }
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index * 5 + i] = false;
            }
        }
    }
    private IEnumerator FindLiveLocation2(int direction, int index)
    {
        if(direction == 0) // dọc
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index + i * 5] = false;
            }
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index * 5 + i] = false;
            }
        }
        FindLocationForBots();
        yield return new WaitForSeconds(1.5f);
        if(direction == 0) // dọc
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index + i * 5] = true;
            }
        }
        else
        {
            for(int i = 0; i < 5; i++)
            {
                locationAlive[index * 5 + i] = true;
            }
        }
    }

    private bool CheckChoose(int[] choose, int choosed)
    {
        for(int i = 0; i < choose.Length; i++)
        {
            if(choosed == choose[i])
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator CheckEndGame()
    {
        for(int i = 0; i < bots.Length; i++)
        {
            if(bots[i] != null || bots[i].isDie == false)
            {
                StartCoroutine(bots[i].BotWin());
            }
        }

        if(playerAlive == true)
        {
            BongBauDuc_Player.ins.PlayerWin();
        }

        isEndGame = true;
        yield return new WaitForSeconds(1);

        if(playerAlive)
        {
            resultText.text = "ALIVE";
        }
        else
        {
            resultText.text = "DIE";
        }

        endGamePanel.SetActive(true);
        reviveButton.gameObject.SetActive(false);
        BongBauDuc_DynamicJoystick.ins.gameObject.SetActive(false);
    }

    private void Onclick_restartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void RevivePlayer()
    {
        Destroy(BongBauDuc_Player.ins.gameObject);
        playerAlive = true;
        GameObject[] options = new GameObject[locations.Length];
        for(int i = 0; i < locations.Length; i++)
        {
            if(BongBauDuc_GameManager.ins.locationAlive[i] == true)
            {
                options[i] = BongBauDuc_GameManager.ins.locations[i];
            }
        }

        int ran;
        do
        {
            ran = Random.Range(0, 25);
        } while(options[ran] == null);

        var newPlayer = Instantiate(playerPrefab, new Vector3(options[ran].transform.position.x, 0, options[ran].transform.position.z), Quaternion.identity);
        newPlayer.GetComponent<BongBauDuc_Player>().joystick = BongBauDuc_DynamicJoystick.ins;
        BongBauDuc_DynamicJoystick.ins.gameObject.SetActive(true);

        Time.timeScale = 1;
        endGamePanel.SetActive(false);
    }

    public void EndGamePlayerDie()
    {
        Time.timeScale = 0;
        resultText.text = "DIE";
        endGamePanel.SetActive(true);
        BongBauDuc_DynamicJoystick.ins.gameObject.SetActive(false);
    }
}
