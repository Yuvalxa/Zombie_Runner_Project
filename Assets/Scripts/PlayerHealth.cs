using System.Collections;
using System.Collections.Generic;
using Game.Core.Sounds;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    float currentHealth;
    [SerializeField]RigidbodyFirstPersonController rigidbodyFirstPersonController;
    [SerializeField] Image healthBar;
    [SerializeField] AudioClip gotHitMusic;

    public bool isStealth;


    private void Start()
    {
        currentHealth = hitPoints;
        healthBar.fillAmount = currentHealth/hitPoints;
        //hitPoints = PlayerPrefSaver.instance.GetFloat("hitPoints");
    }
    public void Update()
    {
        isStealth = rigidbodyFirstPersonController.Stealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / hitPoints;
        SoundManager.Instance.PlayEffect(gotHitMusic);
        //PlayerPrefSaver.instance.SetFloat("hitPoints", hitPoints);
        if (currentHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
