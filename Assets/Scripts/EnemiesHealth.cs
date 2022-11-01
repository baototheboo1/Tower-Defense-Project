using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    public Animator anim;
    public float currentHealth;
    public float maxHealth;
    public bool isDead;
    public int goldToGive;
    public GameObject splash;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            isDead = true;
            currentHealth = 0;
            GameManager.instance.AddGold(goldToGive);
            anim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
            if( gameObject.layer == 8)
            {
                AudioManager.instance.PlaySFX(14);
            }
            
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
        GameManager.instance.enemiesOnScreen--;
        GameObject obj = Instantiate(splash, transform.position, transform.rotation);
        Destroy(obj, 0.7f);   
    }
}
