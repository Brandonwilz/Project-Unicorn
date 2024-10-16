using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

using static Player;

public class RoomController : MonoBehaviour {

    public enum Direction {
        Right,
        Left,
        Up,
        Down,
    }

    [SerializeField] Movement player;
    [SerializeField] GameObject roomCurrent;
    [SerializeField] GameObject mask;
    [SerializeField] GameObject positionMaskOnObject;
    [SerializeField] float timeTransitionIn = 0.5f;
    [SerializeField] float timeTransitionActive = 0.0f;
    [SerializeField] float timeTransitionOut = 0.5f;
    [SerializeField] float distance = 50f;

    private Vector3 positionMaskOff;

    private bool isSwitchingActive = false;
    private bool isTransitionActive = false;

    void Start() {
        if (roomCurrent != null) {
            roomCurrent.SetActive(true);
        }
        if (mask != null) {
            mask.SetActive(false);
        }
    }

    public void switchRoom(GameObject roomDestination, GameObject positionDestinationObject, Direction directionIn, Direction directionOut) {
        if (!isSwitchingActive) {
            isSwitchingActive = true;
            Progress.setFlag(Progress.State.playerInputPaused, true);
            StartCoroutine(transition(roomDestination, positionDestinationObject.transform.position, directionIn, directionOut));
        }
    }

    public void setPlayerDirection(Movement.Direction direction) {
        if(player != null) {
            player.setSpriteDirection(direction);
        }
    }

    private IEnumerator transition(GameObject roomDestination, Vector3 positionDestination, Direction directionIn, Direction directionOut) {

        // transition in mask
        if (positionMaskOnObject != null) {
            isTransitionActive = true;
            mask.SetActive(true);
            setPositionMaskOff(positionMaskOnObject.transform.position, directionIn);
            StartCoroutine(moveMask(positionMaskOff, positionMaskOnObject.transform.position, timeTransitionIn));

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

        yield return new WaitForSeconds(timeTransitionActive);

        // transition out mask
        if (positionMaskOnObject != null) {
            isTransitionActive = true;
            setPositionMaskOff(positionMaskOnObject.transform.position, directionOut);
            StartCoroutine(moveMask(positionMaskOnObject.transform.position, positionMaskOff, timeTransitionOut));

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

    private void setPositionMaskOff(Vector3 positionMaskOn, Direction direction) {
        positionMaskOff = positionMaskOn;
        switch (direction) {
            case Direction.Left:
                positionMaskOff.x -= distance;
                break;
            case Direction.Right:
                positionMaskOff.x += distance;
                break;
            case Direction.Up:
                positionMaskOff.y += distance;
                break;
            case Direction.Down:
                positionMaskOff.y -= distance;
                break;
        }
    }
}
