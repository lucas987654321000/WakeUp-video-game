using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SkeletonAI : Enemy
{
    //Some note about Skeleton: When adding new skeleton, make sure to also add waypoints/awareness zone
    // When the player is inside the awarenesszone, it will broadcast that to all references skeleton
    // Particle system need to assign reference to platform where the blood will land on

    public float idleTime = 6, attackCooldown = 0, attackTime = 1.3f;
    public GameObject[] waypoints;
    int currWayPoint = -1;
    ParticleSystem bloodParticle;

    bool isChasing = false, isAttacking = false;
    private float timer = 0f;
    public int health;

    Animator anim;
    NavMeshAgent agent;

    GameObject player;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        state = State.Idle;
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        bloodParticle = transform.GetChild(1).GetComponent<ParticleSystem>();
        //setNextWaypoint();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                if (idleTime > 0)
                {
                    idleTime -= Time.deltaTime;
                }
                else
                {
                    setNextWaypoint();
                }
                break;
            case State.Patrol:
                if (isChasing)
                {
                    isChasing = false;
                    agent.speed = 2;
                    setNextWaypoint();
                } else if (agent.remainingDistance < 0.5f && agent.pathPending == false)
                {
                    state = State.Idle;
                    anim.SetBool("beginIdle", true);
                }
                break;
            case State.Chase:
                if (!isChasing)
                {
                    isChasing = true;
                    agent.speed = 3;
                    anim.Play("Run");
                }
                agent.SetDestination(player.transform.position);

                if (Vector3.Distance(transform.position, player.transform.position) <= 2)
                {
                    state = State.Attack;
                }
                break;
            case State.Attack:
                if (isChasing)
                {
                    isChasing = false;
                    isAttacking = false;
                    attackCooldown = 0;
                    attackTime = 1.3f;
                }
                if (Vector3.Distance(transform.position, player.transform.position) > 2)
                {
                    state = State.Chase;
                }
                if (isAttacking)
                {
                    attackTime -= Time.deltaTime;
                    if (attackTime <= 0)
                    {
                        isAttacking = false;
                        attackTime = 1.3f;
                        HitPlayer();
                    }
                }
                if (attackCooldown > 0)
                {
                    attackCooldown -= Time.deltaTime;
                } else
                {
                    attackCooldown = 2;
                    isAttacking = true;
                    anim.Play("Attack", -1, 0f);
                }
                break;
            case State.Dead:
                timer += Time.deltaTime;
                if (timer > 2.0f){
                    Destroy(gameObject);
                }
                break;
        }

        //check health
        

        //print("Remaining Distance: " + agent.remainingDistance);
        //print("Path pending: " + agent.pathPending);
    }
    public void enemyStruck(){
        this.health -= 50;
        if (this.health < 50)
        {
            //skeleton death anim
            //TODO
         
        if (anim.GetBool("isDead") == false){
            anim.SetBool("isDead", true);
        }
        state = State.Dead;
        }
    }
    void setNextWaypoint()
    {
        if (waypoints.Length > 0)
        {
            idleTime = 6;
            anim.SetBool("beginIdle", false);
            currWayPoint += 1;
            if (currWayPoint >= waypoints.Length)
            {
                currWayPoint = 0;
            }
            state = State.Patrol;
            anim.Play("Patrol");

            agent.SetDestination(waypoints[currWayPoint].transform.position);
        }
        else
        {
            Debug.Log("There are no waypoints set for Skeleton.");
        }
    }

    // Call this method whenever player is hit
    void HitPlayer()
    {
        Debug.Log("Hit Player");
        bloodParticle.Play();
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc == null)
        {
            Debug.Log("Null playercontroller");
        } else
        {
            Debug.Log("Found playercontroller");
        }
        pc.DamagePlayer();
    }
}
