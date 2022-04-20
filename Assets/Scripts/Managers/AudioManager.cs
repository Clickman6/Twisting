using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }

    private AudioSource _audioSource;

    [SerializeField] private CustomAudio _coin;
    [SerializeField] private CustomAudio _explosion;

    private void Awake() {
        Instance = this;

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()      => PlaySound(_coin);
    public void PlayExplosionSound() => PlaySound(_explosion);

    private void PlaySound(CustomAudio sound) {
        _audioSource.PlayOneShot(sound.Source, sound.Volume);
    }
}
