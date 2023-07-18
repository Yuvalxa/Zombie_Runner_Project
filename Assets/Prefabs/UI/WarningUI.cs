using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningUI : MonoBehaviour
{
    public static WarningUI Instance;
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_Text description;
    [SerializeField] Button okBtn;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        panel.SetActive(false);
        okBtn.onClick.AddListener(ClosePanel);
    }
    public void ShowMessage(string head, string desc)
    {
        header.text = head;
        description.text = desc;
        panel.SetActive(true);
        Time.timeScale = 0;
        //FindObjectOfType<WeaponSwitcher>().enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }
    private void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        //FindObjectOfType<WeaponSwitcher>().enabled = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }

    private void OnDestroy()
    {
        okBtn.onClick.RemoveAllListeners();
    }
}
