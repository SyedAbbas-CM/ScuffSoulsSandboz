using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//for nav mesh agent and AI movement aint that sweet
public enum Enemystate
{
    PATROL,
    CHASE,
    ATTACK
}
public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemy_anim;
    private NavMeshAgent navAgent;
    private Enemystate enemy_state;

    public float walk_speed = 0.5f;
    public float run_speed = 2.0f;
    public float chase_distance = 15f;
    public float attack_Distance = 1.8f;
    public float chase_after_attack_distance = 2f;
    public float patrol_radius_min = 20f, patrol_radius_max = 60f;
    public float wait_before_attack = 2f;
    public float patrol_for_this_time = 15f;
    public GameObject attack_point;


    private float current_chase_Distance;
    private float attack_timer;
    private Transform target;
    private float patrol_timer;


    private void Awake()
    {
        enemy_anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        enemy_state = Enemystate.PATROL;

        patrol_timer = patrol_for_this_time;

        attack_timer = wait_before_attack;

        current_chase_Distance = chase_distance;
    }
    void Update()
    {
        if(enemy_state == Enemystate.PATROL)
        {
            patrol();
        }
        if (enemy_state == Enemystate.CHASE)
        {
            chase();
        }
        if (enemy_state == Enemystate.ATTACK)
        {
            attack();
        }
    }
    void patrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = walk_speed;

        patrol_timer += Time.deltaTime;

        if(patrol_timer > patrol_for_this_time)
        {
            setRandomDestination();
            patrol_timer = 0f;
        }
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemy_anim.Walk(true);
        }
        else
        {
            enemy_anim.Walk(false);
        }

        if(Vector3.Distance(transform.position,target.position) <= chase_distance)
        {
            enemy_anim.Walk(false);
            enemy_state = Enemystate.CHASE;
        }

    }

    void chase()
    {
        navAgent.isStopped = false;
        navAgent.speed = run_speed;

        navAgent.SetDestination(target.position);

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemy_anim.Run(true);
        }
        else
        {
            enemy_anim.Run(false);
        }
        if (Vector3.Distance(transform.position, target.position) <= attack_Distance)
        {
            enemy_anim.Run(false);
            enemy_anim.Walk(false);
            enemy_state = Enemystate.ATTACK;

            if(chase_distance != current_chase_Distance)
            {
                chase_distance = current_chase_Distance;
            }

        }
        else if(Vector3.Distance(transform.position, target.position) >= chase_distance)
        {
            enemy_anim.Run(false);
            enemy_state = Enemystate.PATROL;

            patrol_timer = patrol_for_this_time;
            if (chase_distance != current_chase_Distance)
            {
                chase_distance = current_chase_Distance;
            }
        }
    }

    void attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        //float rotangle=Mathf.Atan2(Vector3.Dot(transform.right, Vector3.up), Vector3.Dot(transform.forward, target.forward)) * Mathf.Rad2Deg;
        //transform.Rotate(Vector3.up, rotangle * Time.deltaTime);
        attack_timer += Time.deltaTime;

        if(attack_timer > wait_before_attack)
        {
            enemy_anim.Attack();
            attack_timer = 0f;
            

        }
        if (Vector3.Distance(transform.position, target.position) >= attack_Distance+chase_after_attack_distance)
        {
            enemy_state = Enemystate.CHASE;
        }
    }

    void setRandomDestination()
    {
        float rand_radius = Random.Range(patrol_radius_min, patrol_radius_max);
        Vector3 randDir = Random.insideUnitCircle * rand_radius;
        randDir += transform.position;

        NavMeshHit navHit;
        //-1 means include all layers
        NavMesh.SamplePosition(randDir, out navHit, rand_radius, -1);
        navAgent.SetDestination(navHit.position);
    }

    void Turn_on_attackPoint()
    {
        attack_point.SetActive(true);
    }
    void Turn_off_attackPoint()
    {
        if (attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);

        }
        attack_point.SetActive(true);
    }

}
