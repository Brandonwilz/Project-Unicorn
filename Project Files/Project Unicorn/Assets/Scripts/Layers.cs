using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Progress;
using MaskLayer;
using UnityEngine.Timeline;
using JetBrains.Annotations;

public class Layers
{
    public static GameObject layerCurrent;
    public static GameObject layerAlternate;
    public static LayerMaskBehaviour maskLayerBehaviour;

    public static readonly Vector3 POSITION_LAYER_CURRENT = new Vector3(0, 0, 0);
    public static readonly Vector3 POSITION_LAYER_ALTERNATE = new Vector3(0, 0, 100);

    public static readonly Vector3 POSITION_MASK_ON = new Vector3(0, 0, -100);
    public static readonly Vector3 POSITION_MASK_OFF = new Vector3(0, 15, -100);

    public static IEnumerator switchLayers() {

        GameObject layerHold;

        if (layerCurrent != null && layerAlternate != null && !Progress.getFlag(State.layerSwitchingActive)) {
            layerAlternate.SetActive(true);

            maskLayerBehaviour.toggleMaskOverTime(1f);

            // update flags
            if (Progress.getFlag(Progress.State.layerMainActive)) {
                Progress.setFlag(Progress.State.layerMainActive, false);
                Progress.setFlag(Progress.State.layerOtherActive, true);
            }
            else if (Progress.getFlag(Progress.State.layerOtherActive)) {
                Progress.setFlag(Progress.State.layerOtherActive, false);
                Progress.setFlag(Progress.State.layerMainActive, true);
            }

            yield return new WaitUntil(isSwitchComplete);

            // toggle which layer is active
            layerCurrent.SetActive(false);

            // swap references to main and alternate layers
            layerHold = layerCurrent;
            layerCurrent = layerAlternate;
            layerAlternate = layerHold;
        }


    }

    public static bool isSwitchComplete() {
        return !Progress.getFlag(State.layerSwitchingActive);
    }
}
