using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyHealth health;
    [SerializeField] GameWonHandler gameWonHandler;
    void Start()
    {
        health = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
            gameWonHandler.HandleGameWon();
    }
}
