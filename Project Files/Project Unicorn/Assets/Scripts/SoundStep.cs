using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStep : MonoBehaviour {

    public enum MaterialSound {
        none,
        carpet,
        hardwood,
    }

    static List<AudioClip> soundsFootstepsCarpet;

    AudioSource audioSource;

    [SerializeField] private MaterialSound materialSoundDefault = MaterialSound.hardwood;
    [SerializeField] private GameObject SFX_Carpet;
    [SerializeField] private GameObject SFX_Hardwood;

    private MaterialSound materialSound;

    private AudioClip[] soundsCarpet;
    private AudioClip[] soundsHardwood;

    private int soundCount;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        materialSound = materialSoundDefault;

        soundsCarpet = getSoundsFromObject(SFX_Carpet);
        soundsHardwood = getSoundsFromObject(SFX_Hardwood);
    }

    void Update() {
    }

    void addMaterialSound(MaterialSound material) {
        soundCount++;
        materialSound = material;
    }

    void removeMaterialSound() {
        soundCount--;
        if(soundCount <= 0) {
            soundCount = 0;
            materialSound = materialSoundDefault;
        }
    }

    void playSoundStep() {
        switch (materialSound) {
            case MaterialSound.carpet:
                audioSource.PlayOneShot(randomAudioClip(soundsCarpet));
                break;
            case MaterialSound.hardwood:
                audioSource.PlayOneShot(randomAudioClip(soundsHardwood));
                break;
        }
    }

    AudioClip randomAudioClip(AudioClip[] sounds) {
        return sounds[randomIndex(sounds)];
    }
    int randomIndex(AudioClip[] sounds) {
        return (int)(sounds.Length * Random.value);
    }

    AudioClip[] getSoundsFromObject(GameObject obj) {
        AudioSource[] audioSources = obj.GetComponentsInChildren<AudioSource>(true);
        AudioClip[] sounds = new AudioClip[audioSources.Length];

        for(int i=0; i<audioSources.Length; i++) {
            sounds[i] = audioSources[i].clip;
        }

        return sounds;
    }
}
