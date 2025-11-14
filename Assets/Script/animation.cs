using UnityEngine;

public class animation : MonoBehaviour
{
    public void LogAnimationEvent(string eventName)
    {
        Debug.Log("Animation Event Triggered: " + eventName);
    }
}
