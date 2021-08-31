using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class BlendshapeModels
{
    public List<BlendshapeModel> shapes = new List<BlendshapeModel>();
    public HeadPosRot headPosRot = new HeadPosRot();
}
[Serializable]
public class BlendshapeModel 
{
    public string Location;
    public float coefficient;
}
[Serializable]
public class HeadPosRot
{
    public Vector3 pos;
    public Quaternion rot;
}
