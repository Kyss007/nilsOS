using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
