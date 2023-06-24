using Newtonsoft.Json.Linq;
using UnityEngine;

public class PlayerPrefSaver : MonoBehaviour
{
    // Singleton instance
    public static PlayerPrefSaver instance;

    // Key for the player preference
    private const string settingValueKey = "SettingValue";

    // Stored setting value
    private int settingValue;
    private const string ammoSlotsKey = "AmmoSlots";

    private Ammo.AmmoSlot[] ammoSlots;


    // Awake is called before any Start functions
    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // Set the instance to this object
            instance = this;

            // Load the setting value
            LoadSettingValue();
        }
        else
        {
            // Destroy this duplicate instance
            Destroy(gameObject);
        }

        // Make sure the instance persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    // Save the setting value to PlayerPrefs
    private void SaveSettingValue()
    {
        PlayerPrefs.SetInt(settingValueKey, settingValue);
        PlayerPrefs.Save();
    }

    // Load the setting value from PlayerPrefs
    private void LoadSettingValue()
    {
        if (PlayerPrefs.HasKey(settingValueKey))
        {
            settingValue = PlayerPrefs.GetInt(settingValueKey);
        }
        else
        {
            settingValue = 0; // Default value if no saved value exists
        }
    }

    // Set an integer value using the specified key
    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    // Get an integer value using the specified key
    public int GetInt(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        else
        {
            Debug.LogWarning("No value found for key: " + key);
            return 0; // Default value if no saved value exists
        }
    }

    // Set a float value using the specified key
    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    // Get a float value using the specified key
    public float GetFloat(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        else
        {
            Debug.LogWarning("No value found for key: " + key);
            return 0f; // Default value if no saved value exists
        }
    }

    // Set a string value using the specified key
    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    // Get a string value using the specified key
    public string GetString(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        else
        {
            Debug.LogWarning("No value found for key: " + key);
            return string.Empty; // Default value if no saved value exists
        }
    }
    // Save the ammo slots to PlayerPrefs
    public void SaveAmmoSlots(Ammo.AmmoSlot[] ammoSlotsScene)
    {
        ammoSlots = ammoSlotsScene;
        string ammoSlotsJson = JsonUtility.ToJson(ammoSlots);
        PlayerPrefs.SetString(ammoSlotsKey, ammoSlotsJson);
        PlayerPrefs.Save();
    }

    // Load the ammo slots from PlayerPrefs
    public Ammo.AmmoSlot[] LoadAmmoSlots()
    {
        if (PlayerPrefs.HasKey(ammoSlotsKey))
        {
            string ammoSlotsJson = PlayerPrefs.GetString(ammoSlotsKey);
            JObject json = JObject.Parse(ammoSlotsJson);
            if(json.HasValues)
            {
                ammoSlots = JsonUtility.FromJson<Ammo.AmmoSlot[]>(ammoSlotsJson);
            }
        }
        else
        {
            // Initialize with default ammo slots if no saved slots exist
            ammoSlots = null;
        }
        return ammoSlots;
    }

}
