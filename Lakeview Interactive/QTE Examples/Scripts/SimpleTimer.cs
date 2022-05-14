using UnityEngine;
using UnityEngine.Events;

public class SimpleTimer : MonoBehaviour
{
    // How much time to wait
    public float timeDelay;

    // What to call after the time has finished
    public UnityEvent onFinished;

    void OnEnable()
    {
        Invoke("CallEvent", timeDelay);
    }

    void CallEvent()
    {
        Debug.Log("Call Event");
        onFinished.Invoke();
    }
}
