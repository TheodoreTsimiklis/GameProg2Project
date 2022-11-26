using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {SPAWING, WAITING, COUNTING};
    public int xPos;
    public int yPos;
    public GameObject complete;
    public static int show;
    public static int mult;
    public int store;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        //public int count;
        public float rate;

    }

    public Wave[] waves;
    public int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDowndown;

    private float searchCountDown = 1;

    public SpawnState state = SpawnState.COUNTING;

    void Start() 
    {
        waveCountDowndown = timeBetweenWaves;
        complete.SetActive(false);
        show = 0;
        mult = 1;
    }

    void Update() 
    {
        if (state == SpawnState.WAITING) 
        {
            if(!CheckIfEnemyIsAlive())
            {
                Debug.Log("Wave completed");
                BeginningNewRound();
            } else 
            {
                return;
            }
        }

        if (waveCountDowndown <= 0) 
        {
            if (state != SpawnState.SPAWING)
            {
                StartCoroutine( SpawnWave (waves[nextWave]));
            }

            } else 
        {
            waveCountDowndown -= Time.deltaTime;
        }
    }

    void BeginningNewRound()
    {
        Debug.Log("Beggining new round");
        state = SpawnState.COUNTING;
        waveCountDowndown = timeBetweenWaves;
        GlobaleVariable.num += 1;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves are completed");
            return;
        } else 
        {
            nextWave++;
        }
    }

    bool CheckIfEnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            
                if (GameObject.Find("Dragon") == null && GameObject.Find("Slime") == null && GameObject.Find("Skeleton") == null)
                {
                    return false;
                } 
            }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave) 
    {
        Debug.Log("The ennemy is spawning");
        state = SpawnState.SPAWING;
        mult += 2; // Add 2 extra enemies in the game for each wave
        store = mult; // This will store the multiplier values inside another variable
        Debug.Log(mult+ "first");
        
        if (show > 0) {
            complete.SetActive(true);
            yield return new WaitForSeconds(3f);
            complete.SetActive(false);
        }

            Debug.Log("The Global variable = " + GlobaleVariable.num);
        if (GlobaleVariable.num % 3 == 0) { // This if statement is to set the number of boss at the final level
            GlabaleVariableIncreaser.num += 1;
            mult = 8;
        }

        for (int i = 0; i < mult; i++) 
        {  
            SpawnEnemy(_wave.enemy);
            //yield return new WaitForSeconds( 1f/_wave.rate);
            show += 1;
        }

        mult = store; //Set the multipier back to his initial value
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy) 
    {
        xPos = Random.Range(-54,-51);
        yPos = Random.Range(-54,-61);
        Debug.Log("Enemines are alive");
        Instantiate(_enemy, new Vector3(xPos, 17, yPos), Quaternion.identity);
    }
}
