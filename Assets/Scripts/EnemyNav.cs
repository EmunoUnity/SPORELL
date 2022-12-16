using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private GameObject Player;
    private int b = 0;
    //public Transform[] randomPoints;

    private Animator animator;

    private float playerDist, randomPointDist;
    //public int currentRandomPoint;
    private bool chasing, chaseTime, attacking;
    private float chaseStopwatch, attackingStopwatch;

    public float perceptionDistance = 30, chaseDistance = 20, attackDistance = 1, walkVelocity = 2, chaseVelocity = 5, attackTime = 1.5f, enemyDamage = 0.2f;

    public bool seeingPlayer;
    public float enemyLife;
    public float totalEnemyLife = 100;
    public string GameOverSceneName;

    private Vector3 spawnPosition;
    private Vector3 spawnPosition1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        //currentRandomPoint = Random.Range(0, randomPoints.Length);
        navMesh = transform.GetComponent<NavMeshAgent>();
        enemyLife = totalEnemyLife;

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int spawnPointX = Random.Range(-11, 11);
        int spawnPointY = Random.Range(-11, 11);
        spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
        spawnPosition1 = new Vector3(spawnPointX, spawnPointY, 0);

        playerDist = Vector3.Distance(Player.transform.position, transform.position);
        //randomPointDist = Vector3.Distance(randomPoints[currentRandomPoint].transform.position, transform.position);
        randomPointDist = Vector3.Distance(spawnPosition, transform.position);
        RaycastHit hit;

        Vector3 startRay = transform.position;
        Vector3 endRay = Player.transform.position;
        Vector3 direction = endRay - startRay;

        

        if (Physics.Raycast(transform.position, direction, out hit, 1000) && playerDist < perceptionDistance)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                seeingPlayer = true;
            }
            else
            {
                seeingPlayer = false;
            }
        }

        if (playerDist > perceptionDistance)
            walk();

        if (playerDist <= perceptionDistance && playerDist > chaseDistance)
        {
            if (seeingPlayer == true)
                look();
            else
                walk();
        }

        if (playerDist <= chaseDistance && playerDist > attackDistance)
        {
            if (seeingPlayer == true)
            {
                chase();
                chasing = true;
            }
            else
            {
                walk();
            }
        }

        if (playerDist <= attackDistance && seeingPlayer == true)
            attack();

        if (randomPointDist <= 8)
        {
            
            //currentRandomPoint = Random.Range(0, randomPoints.Length);
            walk();
        }

        if (chaseTime == true)
            chaseStopwatch += Time.deltaTime;

        if (chaseStopwatch >= 5 && seeingPlayer == false)
        {
            chaseTime = false;
            chaseStopwatch = 0;
            chasing = false;
        }

        if (attacking == true)
            attackingStopwatch += Time.deltaTime;

        if (attackingStopwatch >= attackTime && playerDist <= attackDistance)
        {
            attacking = true;
            attackingStopwatch = 0;
            PLAYER.life = PLAYER.life - enemyDamage;

            if (PLAYER.life < 5)
            {
                //Application.LoadLevel(GameOverSceneName);
            }
            else if (attackingStopwatch >= attackTime && playerDist > attackDistance)
            {
                attacking = false;
                attackingStopwatch = 0;
            }

        }

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Finish")
        {
            //enemyLife -= 40;

            if (!PlayerFighting.comboOne && !PlayerFighting.comboTwo)
            {
                enemyLife -= 40;
            }
            else if (PlayerFighting.comboOne && !PlayerFighting.comboTwo)
            {
                enemyLife -= 50;
            }
            else if (PlayerFighting.comboOne && PlayerFighting.comboTwo)
            {
                enemyLife -= 80;
            }

            
        }

        if (enemyLife <= 0)
        {
            animator.SetBool("death", true);
            seeingPlayer = false;
            walkVelocity = 0;
            attackDistance = 0;
            chaseVelocity = 0;
            chaseDistance = 0;
            enemyDamage = 0;
            //currentRandomPoint = 0;


            StartCoroutine(deathing());
        }

        if (col.transform.tag == "Acorn")
        {
            enemyLife -= 25;
        }
    }

    void walk()
    {
        

        if (chasing == false)
        {
            //animator.SetFloat("Speed", 0.5f);
            animator.SetBool("attack" , false);
            navMesh.acceleration = 4;
            navMesh.speed = walkVelocity;

            if (b == 0)
            {
                navMesh.destination = spawnPosition;
                b = 1;
            }
            else
            {
                navMesh.destination = spawnPosition1;
                b = 0;
            }
            

        }
        else if (chasing == true)
        {
            //animator.SetFloat("Speed", 0.5f);
            animator.SetBool("attack" , false);
            chaseTime = true;
        }
    }

    void look()
    {
        navMesh.speed = 0;
        transform.LookAt(Player.transform);
    }

    void chase()
    {
        //animator.SetFloat("Sprint", 0.4f);
        animator.SetBool("attack" , false);
        navMesh.acceleration = 8;
        navMesh.speed = chaseVelocity;
        navMesh.destination = Player.transform.position;
    }

    void attack()
    {
        animator.SetBool("attack" , true);
        navMesh.acceleration = 0;
        navMesh.speed = 0;
        attacking = true;
    }


    public IEnumerator deathing()
    {
        Spawner.outdeed++;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
    
}
