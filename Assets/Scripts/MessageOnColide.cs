using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnColide : MonoBehaviour
{
    [SerializeField] string headline;
    [SerializeField] string message;
    private void OnCollisionEnter(Collision collision)
    {
        WarningUI.Instance.ShowMessage(headline, message);
        Destroy(this.gameObject);
    }

}
