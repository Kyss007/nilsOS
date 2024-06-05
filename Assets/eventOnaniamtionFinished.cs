using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAnimationFinished : MonoBehaviour
{
    public UnityEvent onEndOfAnim;
    public void penis()
    {
        onEndOfAnim.Invoke();
    }
}
