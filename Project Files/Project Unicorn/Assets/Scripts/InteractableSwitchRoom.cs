using ProjectUnicorn.InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static RoomController;

public class InteractableSwitchRoom : MonoBehaviour, Interactable {
    [SerializeField] RoomController roomController;
    [SerializeField] GameObject roomDestination;
    [SerializeField] GameObject positionDestinationObject;
    [SerializeField] RoomController.Direction directionTransitionIn = RoomController.Direction.Right;
    [SerializeField] RoomController.Direction directionTransitionOut = RoomController.Direction.Left;
    [SerializeField] Movement.Direction directionPlayer = Movement.Direction.right;

    public void Interact() {
        roomController.switchRoom(roomDestination, positionDestinationObject, directionTransitionIn, directionTransitionOut);
        roomController.setPlayerDirection(directionPlayer);
    }
}
