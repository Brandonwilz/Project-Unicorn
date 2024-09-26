using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Progress;

public static class Layers {
    public static GameObject layerCurrent;
    public static GameObject layerOther;

    public static readonly Vector3 POSITION_LAYER_CURRENT = new Vector3(0, 0, 0);
    public static readonly Vector3 POSITION_LAYER_OTHER = new Vector3(0, 0, 100);

    public static void switchLayers() {

        GameObject layerHold;

        if (layerCurrent != null && layerOther != null) {

            if (Progress.getFlag(Progress.State.layerMainActive)) {
                Progress.setFlag(Progress.State.layerMainActive, false);
                Progress.setFlag(Progress.State.layerOtherActive, true);
            }
            else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                Progress.setFlag(Progress.State.layerOtherActive, false);
                Progress.setFlag(Progress.State.layerMainActive, true);
            }

            layerCurrent.transform.position = POSITION_LAYER_OTHER;
            layerOther.transform.position = POSITION_LAYER_CURRENT;

            layerHold = layerCurrent;
            layerCurrent = layerOther;
            layerOther = layerHold;
        }
    }
}
