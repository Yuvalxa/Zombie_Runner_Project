using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    
    [SerializeField] GameWonHandler gameWonHandler;
    [SerializeField] GameObject gateProbe;
    private bool isGameWon;
    private void Start()
    {
        isGameWon = false;
        gameWonHandler.enabled = false;
        BossHandler.BossDied += GameEndedHanlder;
    }

    private void GameEndedHanlder()
    {
        gateProbe.SetActive(true);
        isGameWon = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isGameWon)
        {
            gameWonHandler.HandleGameWon();

        }
    }
}
