using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layers {
    public static GameObject layerCurrent;
    public static GameObject layerOther;

    public static void switchLayers() {

        Vector3 positionHold;
        GameObject layerHold;

        if (layerCurrent != null && layerOther != null) {

            positionHold = layerCurrent.transform.position;
            layerCurrent.transform.position = layerOther.transform.position;
            layerOther.transform.position = positionHold;

            layerHold = layerCurrent;
            layerCurrent = layerOther;
            layerOther = layerHold;
        }
    }
}
