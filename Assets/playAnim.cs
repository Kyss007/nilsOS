using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnim : MonoBehaviour
{
    private Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    public void play()
    {
        animation.Play();
    }
}
