using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDistanceGrabbable : SVRDistanceGrabbable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GrabBegin(SVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        if (hand.gameObject.name.Contains("Left"))
        {
            SVRInput.TriggerHaptic(0, 1.0f, 50.0f, 0.2f);
        }
        else
        {
            SVRInput.TriggerHaptic(1, 1.0f, 50.0f, 0.2f);
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }
}
