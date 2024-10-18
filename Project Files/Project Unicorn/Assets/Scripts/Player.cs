using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player {
    public static GameObject playerCurrent;

    public static void setPosition(GameObject obj) {
        if (playerCurrent != null) {
            playerCurrent.transform.position = obj.transform.position;
        }
    }
    public static void setPosition(Transform transform) {
        if (playerCurrent != null) {
            playerCurrent.transform.position = transform.position;
        }
    }
    public static void setPosition(Vector3 position) {
        if (playerCurrent != null) {
            playerCurrent.transform.position = position;
        }
    }
}
