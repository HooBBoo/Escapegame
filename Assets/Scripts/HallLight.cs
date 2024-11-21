using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallLight : MonoBehaviour
{
    public Light light;
    public MeshRenderer lamp;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        lamp = GetComponentInChildren<MeshRenderer>();
    }

    public void TurnOn() //다시 켜져야 하니까
    {
        light.enabled = true;
        // meshrenderer~어쩌고
    }
    
    public void TurnOff()
    {
        light.enabled = false;
        // meshrenderer~어쩌고
    }
}
