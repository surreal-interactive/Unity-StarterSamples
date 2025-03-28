using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLeftStickValueScript : MonoBehaviour
{
    public TMP_Text leftStickXTmpText;
    public TMP_Text leftStickYTmpText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 leftStickAxis = SVRInput.Get(SVRInput.Axis2D.LThumbstick);
        if (leftStickXTmpText)
        {
            leftStickXTmpText.text = leftStickAxis.x.ToString();
        }

        if (leftStickYTmpText)
        {
            leftStickYTmpText.text = leftStickAxis.y.ToString();
        }
    }
}
