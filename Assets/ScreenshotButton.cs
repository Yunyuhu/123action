using UnityEngine;
using UnityEngine.UI;

public class ButtonReplay : MonoBehaviour
{
    public AudioSource AudioSource;
    public Button Button;

    void Start()
    {
        Button.onClick.AddListener(ReplayAudio);
    }

    public void ReplayAudio()
    {
        AudioSource.Play();
    }
}