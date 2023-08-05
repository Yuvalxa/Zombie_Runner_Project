using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyHealth health;
    public static Action BossDied;
    void Start()
    {
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame

    public void Update()
    {
        if (health.IsDead())
            BossDied?.Invoke();
    }
}
