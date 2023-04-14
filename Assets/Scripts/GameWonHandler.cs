using System;
using UnityEngine;

public class GameWonHandler:MonoBehaviour
{

    [SerializeField] Canvas gameWonCanvas;
    private void Start()
    {
        gameWonCanvas.enabled = false;
    }

    public void HandleGameWon()
    {
        gameWonCanvas.gameObject.SetActive(true);
        gameWonCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}