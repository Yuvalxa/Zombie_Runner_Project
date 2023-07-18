using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] bool isTarget = false;
    public static event Action targetDestory;
    bool isDead = false;
    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if(!isTarget)
            BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            if (isTarget)
            {
                targetDestory?.Invoke();
                Destroy(this.gameObject);
            }
            else
                Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
