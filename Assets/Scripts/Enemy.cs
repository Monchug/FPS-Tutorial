using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public bool isDead = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        anim.SetBool("isDead", true);
        isDead = true;
        gameObject.tag = "Untagged";
        StartCoroutine(DeadBody());
    }
    IEnumerator DeadBody()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
