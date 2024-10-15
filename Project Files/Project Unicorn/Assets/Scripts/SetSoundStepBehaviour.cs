using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundStepBehaviour;

public class SetSoundStepBehaviour : MonoBehaviour {

    [SerializeField] MaterialSound materialSound;

    public void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.SendMessage("addMaterialSound", materialSound);
        }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.SendMessage("removeMaterialSound");
        }
    }
}
