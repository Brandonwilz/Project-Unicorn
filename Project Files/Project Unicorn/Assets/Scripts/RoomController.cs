using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

using static Player;

public class RoomController : MonoBehaviour {

    [SerializeField] GameObject roomCurrent;
    [SerializeField] GameObject mask;
    [SerializeField] GameObject positionMaskOn;
    [SerializeField] GameObject positionMaskOff;
    [SerializeField] float timeTransitionIn = 0.5f;
    [SerializeField] float timeTransitionOut = 0.5f;

    private bool isSwitchingActive = false;
    private bool isTransitionActive = false;

    void Start() {
        if (roomCurrent != null) {
            roomCurrent.SetActive(true);
        }
    }

    public void switchRoom(GameObject roomDestination, GameObject positionDestination) {
        if (!isSwitchingActive) {
            isSwitchingActive = true;
            Progress.setFlag(Progress.State.playerInputPaused, true);
            StartCoroutine(transition(roomDestination, positionDestination));
        }
    }

    private IEnumerator transition(GameObject roomDestination, GameObject positionDestination) {
        // transition in mask
        if (positionMaskOn != null && positionMaskOff != null) {
            isTransitionActive = true;
            mask.SetActive(true);
            StartCoroutine(moveMask(positionMaskOff.transform.position, positionMaskOn.transform.position, timeTransitionIn));

            // wait
            yield return new WaitWhile(() => isTransitionActive);
        }

        // unload
        if (roomCurrent != null) {
            roomCurrent.SetActive(false);
        }

        // load
        if (roomDestination != null) {
            roomDestination.SetActive(true);
        }

        roomCurrent = roomDestination;
        Player.setPosition(positionDestination);

        // transition out mask
        if (positionMaskOn != null && positionMaskOff != null) {
            isTransitionActive = true;
            StartCoroutine(moveMask(positionMaskOn.transform.position, positionMaskOff.transform.position, timeTransitionOut));

            // wait
            yield return new WaitWhile(() => isTransitionActive);
            mask.SetActive(false);
        }

        Progress.setFlag(Progress.State.playerInputPaused, false);
        isSwitchingActive = false;
    }

    private IEnumerator moveMask(Vector3 positionStart, Vector3 positionEnd, float seconds) {
        if (mask != null) {
            float elapsedTime = 0;
            while (elapsedTime < seconds) {
                mask.transform.position = Vector3.Lerp(positionStart, positionEnd, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            mask.transform.position = positionEnd;
        }
        isTransitionActive = false;
    }
}
