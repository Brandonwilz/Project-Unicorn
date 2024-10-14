using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Progress : MonoBehaviour {
    public enum State {
        layerMainActive,
        layerOtherActive,
        layerSwitchingActive,
        playerMovingActive,
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
}
