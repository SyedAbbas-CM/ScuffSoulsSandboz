using UnityEngine;
using UnityEngine.AI;

public class CharecterStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float stamina = 100f;
    public float attackPower = 20f;
    public float defense = 10f;
    public bool is_player, is_boar, is_cannibal;

    public bool is_Dead;
    private EnemyAnimator enemy_Anim;
    private EnemyController enemy_controller;
    private NavMeshAgent navAgent;


    private void Awake()
    {
        if(is_boar || is_cannibal)
        {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();
        } 
    }



    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (is_Dead) return;
        float damageToTake = damage - defense;
        if (damageToTake < 0) damageToTake = 0;

        currentHealth -= damageToTake;

        if (is_player)
        {

        }
        if (is_boar || is_cannibal)
        {
            if(enemy_controller.Enemy_State == Enemystate.PATROL)
            {
                enemy_controller.chase_distance = 50f;
            }
        }







        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Attack(CharecterStats target)
    {
        if (stamina > 0)
        {
            target.TakeDamage(attackPower);
            stamina -= 10; // Assuming each attack consumes 10 stamina
        }
    }

    private void Die()
    {
        if (is_player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().enabled = false;
            }

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().enabled = false;


            //respawn logic idk man
        }


        if (is_cannibal)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            enemy_controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddTorque(-transform.forward * 50f);
            }



            //courotine crap for sounds and crap yknow

        }
        else
        {
            navAgent.velocity = Vector3.zero;
            navAgent.isStopped = true;
            enemy_controller.enabled = false;
            enemy_Anim.dead();
        }


        // Handle death here (e.g., play animation, disable the character, etc.)
        is_Dead = true;
        Debug.Log(gameObject.name + " has died.");
    }
}
