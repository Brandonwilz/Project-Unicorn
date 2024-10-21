using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Functions {
    public class Bool {
        public bool value;
        public Bool(bool arg = false) {
            value = arg;
        }
    }

    // adapted from Lakeffect at the URL "https://discussions.unity.com/t/way-to-move-object-over-time/86379/3"
    // --
    public static IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 positionEnd, float speed, Bool isComplete) {
        isComplete.value = false;
        // speed should be 1 unit per second
        if (objectToMove != null) {
            while (objectToMove.transform.position != positionEnd) {
                objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, positionEnd, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        isComplete.value = true;
    }

    public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, Bool isComplete) {
        isComplete.value = false;
        if (objectToMove != null) {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds) {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
        }
        isComplete.value = true;
    }
    // --

    public static Vector3 multiplyVector3(Vector3 vec0, Vector3 vec1) {
        return new Vector3(vec0.x * vec1.x, vec1.y * vec1.y, vec0.z * vec1.z);
    }
}
