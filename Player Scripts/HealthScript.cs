using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;

    public bool is_Player, is_Boar, is_Cannibal, is_Boss;

    private bool is_Dead;

    private EnemyAudio enemyAudio;

    private PlayerStats player_Stats;

    public AttackScript AttackScript;

    public float bossLevel = 1f;

    void Awake()
    {
        //if it is a boss then increase the health of boss accoring to its level
        if (is_Boss)
        {
            health = 100 + bossLevel * 100;
        }

        //if it is a boss or a cannibal, get the components
        if (is_Boar || is_Cannibal)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            // get enemy audio
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }

        //if it is a player the get the player stats component
        if (is_Player)
        {
            player_Stats = GetComponent<PlayerStats>();
        }

    }
    //apply damage depending on the float damage but if they are already dead don't apply damage and leave the function
    public void ApplyDamage(float damage)
    {

        // if we died don't execute the rest of the code
        if (is_Dead)
            return;

        health -= damage;

        if (is_Player)
        {
            // show the stats(display the health UI value)
            player_Stats.Display_HealthStats(health);
        }

        //if they are hit, increase chase range to 50
        if (is_Boar || is_Cannibal)
        {
            if (enemy_Controller.Enemy_State == EnemyState.PATROL)
            {
                enemy_Controller.chase_Distance = 50f;
            }
        }

        //if health is below 0 run player died
        if (health <= 0f)
        {

            PlayerDied();

            is_Dead = true;
        }

    } // apply damage

    public void PlayerDied()
    {
        //if it is the cannibal that died, it just disappears, adds 1 to score Cannibals and total cannibals killed.
        if (is_Cannibal)
        {

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 5f);

            enemy_Controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;

            ScoreScript.scoreValueCannibals += 1;
            ScoreScript.total_killed_cannibals += 1;

            StartCoroutine(DeadSound());
            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied(true);
            if (is_Boss)
            {
                bossLevel += 1;
            }
        }

        //if it is the boar that died, it plays death animation and disappears, adds 1 to score boars and total boars killed.
        if (is_Boar)
        {

            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_Controller.enabled = false;

            enemy_Anim.Dead();
            ScoreScript.scoreValueBoars += 1;
            ScoreScript.total_killed_boars += 1;

            StartCoroutine(DeadSound());

            // EnemyManager spawn more enemies
            EnemyManager.instance.EnemyDied(false);
        }

        if (is_Player)
        {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            // call enemy manager to stop spawning enemis
            EnemyManager.instance.StopSpawning();

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if (tag == Tags.PLAYER_TAG)
        {

            Invoke("RestartGame", 3f);

        }
        else
        {

            Invoke("TurnOffGameObject", 3f);

        }

    } // player died

    void RestartGame()
    {
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen");
    }

    //turns off gameObject
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    //coroutine that plays the dead sound upon death
    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
    }

} // class









































