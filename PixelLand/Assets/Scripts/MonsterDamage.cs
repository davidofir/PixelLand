using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public BasicMovement basicMovement;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            basicMovement.KBCounter = basicMovement.KBTotalTime;

            if(collision.transform.position.x <= transform.position.x)
            {
                basicMovement.KnockFromRight = true;
            }
            if(collision.transform.position.x > transform.position.x)
            {
                basicMovement.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
