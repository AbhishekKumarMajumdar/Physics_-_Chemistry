using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public Slider volumeSlider; // Reference to the UI Slider for volume control
    public Button playPauseButton; // Reference to the play/pause button
    public Sprite playIcon; // Icon for the play state
    public Sprite pauseIcon; // Icon for the pause state
    public Button stopButton; // Reference to the stop button
    public Button volumeButton; // Reference to the volume button
    public GameObject audioPanel;

    // Start is called before the first frame update
    void Start()
    {

        // Set the initial volume based on the slider's value
        audioSource.volume = volumeSlider.value;

        // Add listener to the volume slider to call the OnVolumeChanged method when the slider value changes
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Set the play/pause button to the play icon initially
        UpdatePlayPauseButtonIcon();

        // Hide the volume slider initially
        volumeSlider.gameObject.SetActive(false);
        
    }

    // Method to toggle play/pause state
    public void TogglePlayPause()
    {
       
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }

        // Update the button icon
        UpdatePlayPauseButtonIcon();
    }

    // Method to stop the audio
    public void StopAudio()
    {
       
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Stop();
        }
   
        // Update the button icon
        UpdatePlayPauseButtonIcon();
        
    }

    // Method to update the play/pause button icon
    private void UpdatePlayPauseButtonIcon()
    {

        if (audioSource.isPlaying)
        {
            playPauseButton.image.sprite = pauseIcon;
        }
        else
        {
            playPauseButton.image.sprite = playIcon;
        }
    }

    // Method called when the volume slider value changes
    public void OnVolumeChanged(float value)
    {
        audioSource.volume = value;
    }

    // Method to toggle the visibility of the volume slider
    public void ToggleVolumeSlider()
    {
        bool isActive = volumeSlider.gameObject.activeSelf;

        // Toggle the active state of the volume slider
        volumeSlider.gameObject.SetActive(!isActive);


    }
    public void ToggleAudioPanel()
    {
        bool isActive = audioPanel.gameObject.activeSelf;

        // Toggle the active state of the volume slider
        audioPanel.gameObject.SetActive(!isActive);
        volumeSlider.gameObject.SetActive(false);
        
    }

    
}
