using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SampleButtonMatState
{
    Default,
    Highlight,
    Pressed
}

public class UI_SampleButton : MonoBehaviour
{
    public Material mat;

    public string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMatState(SampleButtonMatState state)
    {
        if (state == SampleButtonMatState.Default)
        {
            GetComponent<MeshRenderer>().material.SetFloat("_State", 0.0f);
        }
        else if (state == SampleButtonMatState.Highlight)
        {
            GetComponent<MeshRenderer>().material.SetFloat("_State", 0.2f);
        }
        else if (state == SampleButtonMatState.Pressed)
        {
            GetComponent<MeshRenderer>().material.SetFloat("_State", 0.5f);
        }
    }
}
