using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // Required for Button

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public AudioSource navigationSoundSource;
    public AudioSource selectionSoundSource;

    public AudioClip navigationClip;  // Assign in Inspector
    public AudioClip selectionClip;   // Assign in Inspector

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySelectionSound);
        }
        else
        {
            Debug.LogError("Button component is missing.");
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(PlaySelectionSound);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play navigation sound when hovering over a button with the mouse
        PlayNavigationSound();
    }

    public void OnSelect(BaseEventData eventData)
    {
        // Play navigation sound when selecting a button via keyboard or gamepad
        PlayNavigationSound();
    }

    private void PlayNavigationSound()
    {
        if (navigationSoundSource != null && navigationClip != null)
        {
            navigationSoundSource.PlayOneShot(navigationClip);
        }
        else
        {
            Debug.LogWarning("Navigation sound source or clip is missing.");
        }
    }

    private void PlaySelectionSound()
    {
        if (selectionSoundSource != null && selectionClip != null)
        {
            selectionSoundSource.PlayOneShot(selectionClip);
        }
        else
        {
            Debug.LogWarning("Selection sound source or clip is missing.");
        }
    }
}
