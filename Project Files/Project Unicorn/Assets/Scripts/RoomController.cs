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
            StartCoroutine(transition(roomDestination, positionDestinationObject.transform.position, directionIn, directionOut));
        }
    }

    public void setPlayerDirection(Movement.Direction direction) {
        if(player != null) {
            player.setSpriteDirection(direction);
        }
    }

    private IEnumerator transition(GameObject roomDestination, Vector3 positionDestination, Direction directionIn, Direction directionOut) {
        Progress.setFlag(Progress.State.playerInputPaused, true);

        Functions.Bool isTransitionComplete = new Functions.Bool();

        // transition in mask
        if (positionMaskOnObject != null) {
            setPositionMaskOff(positionMaskOnObject.transform.position, directionIn);
            mask.transform.position = positionMaskOff;
            mask.SetActive(true);
            StartCoroutine(Functions.MoveOverSeconds(mask, positionMaskOnObject.transform.position, timeTransitionIn, isTransitionComplete));

            // wait
            yield return new WaitUntil(() => isTransitionComplete.value);
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
            setPositionMaskOff(positionMaskOnObject.transform.position, directionOut);
            StartCoroutine(Functions.MoveOverSeconds(mask, positionMaskOff, timeTransitionOut, isTransitionComplete));
            yield return new WaitUntil(() => isTransitionComplete.value);
        }

        Progress.setFlag(Progress.State.playerInputPaused, false);
        isSwitchingActive = false;
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
