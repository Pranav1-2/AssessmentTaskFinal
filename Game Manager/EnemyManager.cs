using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject boar_Prefab, cannibal_Prefab;

    public Transform[] cannibal_SpawnPoints, boar_SpawnPoints;

    [SerializeField]
    private int cannibal_Enemy_Count, boar_Enemy_Count;

    private int initial_Cannibal_Count, initial_Boar_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    public Text BossAppear;
    public GameObject BossCannibal, BossBoars;
    private float counter1;
    private float random;

    // Use this for initialization
    //runs the function MakeInstance
    void Awake () 
    {
        MakeInstance();
	}

    void Start() 
    {
        initial_Cannibal_Count = cannibal_Enemy_Count;
        initial_Boar_Count = boar_Enemy_Count;
        //spawns enemies
        SpawnEnemies();
        //runs the coroutine to checkspawn the enemies
        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance() 
    {
        if(instance == null) 
        {
            instance = this;
        }
    }
    // function spawns the boars and cannibals according to the enemy manager
    void SpawnEnemies() 
    {
        SpawnCannibals();
        SpawnBoars();
    }
    //Spawns the boss
    public void SpawnBoss()
    {
        BossAppear.text = "THE BOSS HAS APPEARED";
        BossAppear.color = Color.white;
        Invoke("SpawnBossFalse", 2);
        random = Random.Range(0, 6);
        if (random < 3f)
        {
            int index = 0;

            if (index >= 1)
            {
                index = 0;
            }
            Debug.Log("Boar Boss has been spawned"); //tests if this program runs
            Instantiate(BossCannibal, cannibal_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }
        else
        {
            int index = 0;
            if (index >= 1)
            {
                index = 0;
            }
            Debug.Log("Boar Boss has been spawned");//tests if this program runs
            Instantiate(BossBoars, boar_SpawnPoints[index].position, Quaternion.identity);

            index++;
        }
    }
    //turns off the Spawn Boss Text
    void SpawnBossFalse()
    {
        BossAppear.text = "";
    }

    //spawns the cannibals in rotation between the spawnpoints

    void SpawnCannibals() 
    {

        int index = 0;

        for (int i = 0; i < cannibal_Enemy_Count; i++) 
        {

            if (index >= cannibal_SpawnPoints.Length) 
            {
                index = 0;
            }

            Instantiate(cannibal_Prefab, cannibal_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        cannibal_Enemy_Count = 0;

    }
    //spawns the boar in rotation between the spawnpoints
    void SpawnBoars() 
    {

        int index = 0;

        for (int i = 0; i < boar_Enemy_Count; i++) {

            if (index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(boar_Prefab, boar_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        boar_Enemy_Count = 0;

    }
    //waits for a certain amount of time spawn the enemies and loops back
    IEnumerator CheckToSpawnEnemies() 
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnCannibals();

        SpawnBoars();

        StartCoroutine("CheckToSpawnEnemies");

    }

    //Check if the cannibal died or if the boar died
    public void EnemyDied(bool cannibal) 
    {
        //if it is the cannibal, increase the enemy count to original count
        if(cannibal) 
        {

            cannibal_Enemy_Count++;

            if(cannibal_Enemy_Count > initial_Cannibal_Count) 
            {
                cannibal_Enemy_Count = initial_Cannibal_Count;
            } 

        }
        //else do it for the baor
        else
        {

            boar_Enemy_Count++;

            if(boar_Enemy_Count > initial_Boar_Count) {
                boar_Enemy_Count = initial_Boar_Count;
            }

        }

    }

    //stops the coroutine
    public void StopSpawning() 
    {
        StopCoroutine("CheckToSpawnEnemies");
    }

} // class


































