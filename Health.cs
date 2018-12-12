using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the amount of health the player asset will have and is scaled
// to a maximum of 100 health (Without health pick-ups).
public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 0;
    Animator anim;

    void Start () {
        anim=GetComponent<Animator>();
        currentHealth = maximumHealth;
    }

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0) {
            if (gameObject.tag != "Player")
            //Destroy(gameObject);
            {
                if(anim)
                {
                    anim.SetBool("Dead", true);
                }
                UIScript.updateScore(50);
                Destroy(GetComponent<EnemyNavMovement>());
                Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
                Destroy(GetComponent<CharacterController>());
                Destroy(GetComponentInChildren<EnemyAttack>());

                GameManager.amountkilled++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
