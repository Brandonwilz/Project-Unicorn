using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStepBehaviour : MonoBehaviour {

    public enum MaterialSound {
        none,
        carpet,
        hardwood,
    }

    static string[] FOOTSTEPS_CARPET_FILENAMES = {
        "Billy Carpet Slide 1",
        "Billy Carpet Step Single 2",
        "Billy Carpet Step Single 3",
        "Billy Carpet Step single 4",
    };

    static string[] FOOTSTEPS_HARDWOOD_FILENAMES = {
        "Billy Hardwood Step 1 single",
        "Billy Hardwood Step 2 single",
        "Billy Hardwood Step 3 single",
        "Billy Hardwood Step 4 single",
    };

    static List<AudioClip> soundsFootstepsCarpet = new List<AudioClip>();

    AudioSource audioSource;

    [SerializeField] private MaterialSound materialSoundDefault = MaterialSound.hardwood;

    private MaterialSound materialSound;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        materialSound = materialSoundDefault;
    }

    void Update() {
    }

    void setMaterialSound(MaterialSound material) {
        materialSound = material;
        if (materialSound == MaterialSound.none) {
            materialSound = materialSoundDefault;
        }
    }

    void playSoundStep() {
        switch (materialSound) {
            case MaterialSound.carpet:
                audioSource.PlayOneShot(randomAudioClip(FOOTSTEPS_CARPET_FILENAMES));
                break;
            case MaterialSound.hardwood:
                audioSource.PlayOneShot(randomAudioClip(FOOTSTEPS_HARDWOOD_FILENAMES));
                break;
        }
    }

    AudioClip randomAudioClip(string[] names) {
        return Resources.Load<AudioClip>(names[randomIndex(names)]);
    }
    int randomIndex(string[] names) {
        return (int)(names.Length * Random.value);
    }
}
