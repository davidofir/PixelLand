using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 6;
    public int health;
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHearts();
        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health / 2)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
            }
            else if (i == health / 2 && health % 2 != 0)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = halfHeart;
            }
            else
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            }
        }
    }
}
