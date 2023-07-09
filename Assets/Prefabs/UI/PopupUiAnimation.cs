using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class PopupUiAnimation : MonoBehaviour
{
    [SerializeField] private AudioClip animationSound;
    private const string PopTrigger = "PopIn";
    private Animator animator;
    private AudioSource audioSource;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        animator.SetTrigger(PopTrigger);
    }


    /// <summary>
    /// Animation event function
    /// </summary>
    public void PlayPopupSound()
    {
        audioSource.PlayOneShot(animationSound);
    }
}
