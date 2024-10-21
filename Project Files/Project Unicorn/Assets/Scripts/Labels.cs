using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labels {
    public enum ID {
        space,
        locked,
    }

    public static LabelInteract labelSpace;
    public static LabelInteract labelLocked;

    public static LabelInteract getLabel(ID id) {
        switch (id) {
            case ID.space:
                return labelSpace;
            case ID.locked:
                return labelLocked;
            default:
                return null;
        }
    }

    public static void setActiveAll(bool isActive) {
        try {
            labelSpace.setActive(isActive);
            labelLocked.setActive(isActive);
        }
        catch(NullReferenceException e) {
            Debug.LogError(e);
        }
    }
}
