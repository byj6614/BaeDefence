using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static bool IsContaion(this LayerMask layerMask, int layer)
    {
        return ((1<<layer)&layerMask) != 0;
    }
}
