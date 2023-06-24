using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField]RigidbodyFirstPersonController rigidbodyFirstPersonController;
    public bool isStealth;


    private void Start()
    {
        hitPoints = PlayerPrefSaver.instance.GetFloat("hitPoints");
    }
    public void Update()
    {
        isStealth = rigidbodyFirstPersonController.Stealth;
    }
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        PlayerPrefSaver.instance.SetFloat("hitPoints", hitPoints);
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
