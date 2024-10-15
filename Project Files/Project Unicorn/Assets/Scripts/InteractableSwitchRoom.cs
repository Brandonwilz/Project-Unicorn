using ProjectUnicorn.InteractionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static RoomController;

public class InteractableSwitchRoom : Interactable {
    [SerializeField] GameObject roomDestination;
    [SerializeField] GameObject positionDestination;

    public void Interact() {
        RoomController.switchRoom(roomDestination, positionDestination);
    }
}
