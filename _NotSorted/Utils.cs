﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    //====================Materials=====================\\

    //Return massive of all materials in this GameObject and its childs
    static public Material[] GetAllMaterials (GameObject go)
    {
        Renderer[] rends = go.GetComponentsInChildren<Renderer>();
        List<Material> mats = new List<Material>();
        foreach (Renderer rend in rends)
        {
            mats.Add(rend.material);
        }
        return (mats.ToArray());
    }
}
