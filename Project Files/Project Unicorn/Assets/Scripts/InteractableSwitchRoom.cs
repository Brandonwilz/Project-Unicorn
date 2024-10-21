using ProjectUnicorn.InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static RoomController;

public class InteractableSwitchRoom : MonoBehaviour, IInteractable {
    [SerializeField] RoomController roomController;
    [SerializeField] GameObject roomDestination;
    [SerializeField] GameObject positionDestinationObject;
    [SerializeField] RoomController.Direction directionTransitionIn = RoomController.Direction.Right;
    [SerializeField] RoomController.Direction directionTransitionOut = RoomController.Direction.Left;
    [SerializeField] Movement.Direction directionPlayer = Movement.Direction.right;

    public void Interact() {
        if (roomController != null) {
            roomController.switchRoom(roomDestination, positionDestinationObject, directionTransitionIn, directionTransitionOut);
            roomController.setPlayerDirection(directionPlayer);
        }
    }

    public void Interact(Item.ID item) {
    }
}
