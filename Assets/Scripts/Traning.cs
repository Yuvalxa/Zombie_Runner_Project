using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traning : MonoBehaviour
{
    
    [SerializeField] GameObject secondStageGO;
    [SerializeField] GameObject thirdStageGO;
    // Start is called before the first frame update
    bool firstStage = true;
    bool secondStage = false;
    int numOfTargets = 1;
    private void Start()
    {
        // Subscribe to the static event
        EnemyHealth.targetDestory += HandleEvent;
    }


    private void OnDestroy()
    {
        // Unsubscribe from the static event
        EnemyHealth.targetDestory -= HandleEvent;
    }
    // Update is called once per frame
    void Update()
    {
        if(firstStage && numOfTargets==0)
        {
            SetSecondStage();
        }
        else if(secondStage && numOfTargets == 0)
        {
            SetThirdStage();
        }
        else if(numOfTargets == 0)
        {
            StartEndTranningSequance();
        }
    }

    private void SetThirdStage()
    {
        thirdStageGO.SetActive(true);
        numOfTargets = 2;
        secondStage = false;
    }

    private void StartEndTranningSequance()
    {
        //TODO add message of you Complete Traninng Congraz!! Now Prepare to DIIIIEEEE MUHAHAHAHHHA
        SceneLoader.Instance.LoadScene(SceneLoader.Scene.Asylum);
        Time.timeScale = 0;
    }

    private void SetSecondStage()
    {
        secondStageGO.SetActive(true);
        numOfTargets = 5;
        firstStage = false;
        secondStage = true;
        WarningUI.Instance.ShowMessage("Use ShootGun", "shotgun range is up to 15 meter, but his damge is high");
    }

    private void HandleEvent()
    {
        numOfTargets--;
    }
}
