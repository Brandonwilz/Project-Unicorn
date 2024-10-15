using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player {
    static GameObject objectPlayer;

    public static void setPosition(GameObject obj) {
        if (objectPlayer != null) {
            objectPlayer.transform.position = obj.transform.position;
        }
    }
    public static void setPosition(Transform transform) {
        if (objectPlayer != null) {
            objectPlayer.transform.position = transform.position;
        }
    }
    public static void setPosition(Vector3 position) {
        if (objectPlayer != null) {
            objectPlayer.transform.position = position;
        }
    }
}
