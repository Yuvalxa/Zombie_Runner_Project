using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    
    [SerializeField] GameWonHandler gameWonHandler;
    private void OnTriggerEnter(Collider other)
    {
        gameWonHandler.HandleGameWon();
    }
}
