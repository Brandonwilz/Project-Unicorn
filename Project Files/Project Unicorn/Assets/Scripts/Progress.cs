using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public enum State {
        layerMainActive,
        layerOtherActive,
        layerSwitchingActive
    }

    static bool[] flags;

    static Progress() {
        flags = new bool[Enum.GetValues(typeof(State)).Length];
        for (int i = 0; i < flags.Length; i++) {
            flags[i] = false;
        }
    }

    public static bool getFlag(State state) {
        return flags[((int)state)];
    }
    public static void setFlag(State state, bool flag) {
        flags[((int)state)] = flag;
    }
//    public static void setFlagsOpposite(State stateChanged, State stateOpposite, bool flag) {
//            if (Progress.getFlag(Progress.State.layerMainActive)) {
//                Progress.setFlag(Progress.State.layerMainActive, false);
//                Progress.setFlag(Progress.State.layerOtherActive, true);
//        flags[((int)state)] = flag;
//    }
}
