using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartGameHandler : MonoBehaviour
{
    [SerializeField] Canvas startGameCanvas;
    [SerializeField] UnityEngine.UI.Button startButton;
    [SerializeField] UnityEngine.UI.Button skipTutorial;
    public static Action stopShooting;
    public static Action enableShooting;

    private void Awake()
    {
        startButton.onClick.AddListener(HandleStart);
        skipTutorial.onClick.AddListener(HandleSkip);

    }

    private void HandleSkip()
    {
        SceneLoader.Instance.LoadScene(SceneLoader.Scene.Asylum);
        Time.timeScale = 0;
    }

    private void Start()
    {
        startGameCanvas.enabled = true;
        Time.timeScale = 0;
        stopShooting?.Invoke();
        //FindObjectOfType<WeaponSwitcher>().enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }

    private void HandleStart()
    {
        startGameCanvas.enabled = false;
        Time.timeScale = 1;
        enableShooting?.Invoke();
        //FindObjectOfType<WeaponSwitcher>().enabled = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = true;
        startButton.onClick.RemoveListener(HandleStart);
    }

}
