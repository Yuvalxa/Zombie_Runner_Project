using System;
using System.Collections;
using System.Collections.Generic;
using Game.Core.Sounds;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    float currentHealth;
    [SerializeField] bool isTarget = false;
    [SerializeField] bool isTraningZombie = false;
    [SerializeField] Image image;
    [SerializeField] AudioClip enemyDeathSound;
    public static event Action targetDestory;
    bool isDead = false;
    private void Start()
    {
        currentHealth = hitPoints;
        image.fillAmount = currentHealth / hitPoints;
    }
    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if(!isTarget)
            BroadcastMessage("OnDamageTaken");
        currentHealth -= damage;
        image.fillAmount = currentHealth / hitPoints;
        if (currentHealth <= 0)
        {
            if (isTarget || isTraningZombie)
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
        SoundManager.Instance.PlayEffect(enemyDeathSound);
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
