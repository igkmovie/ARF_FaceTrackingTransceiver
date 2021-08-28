using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscServer : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMessage(float value)
    {
        Debug.Log(value);
    }
}
