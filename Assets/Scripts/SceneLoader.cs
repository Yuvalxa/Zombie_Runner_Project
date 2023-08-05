using Game.Core.Sounds;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Scene { Tranning, Asylum }

    // Singleton instance
    private static SceneLoader instance;
    [SerializeField] AudioClip gameMusic;

    // Public property to access the singleton instance
    public static SceneLoader Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.LogError(Application.persistentDataPath);
    }
    private void Start()
    {
        SoundManager.Instance.PlayMusic(gameMusic);
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
        Time.timeScale = 1;
        SoundManager.Instance.PlayMusic(gameMusic);
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
