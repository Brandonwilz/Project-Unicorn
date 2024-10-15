using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static Player;

public static class RoomController {
    static GameObject roomCurrent;

    public static void switchRoom(GameObject roomDestination, GameObject positionDestination) {
        if (roomCurrent != null) {
            roomCurrent.SetActive(false);
        }
        if(roomDestination != null) {
            roomDestination.SetActive(true);
        }
        roomCurrent = roomDestination;

        Player.setPosition(positionDestination);
    }
}
