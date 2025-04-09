using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLeftStickValueScript : MonoBehaviour
{
    public static ShowLeftStickValueScript instance;

    public TMP_Text leftStickXTmpText;
    public TMP_Text leftStickYTmpText;
    public TMP_Text controlModeText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchControlModeText(SVRControlMode.Controller);
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

    public void SwitchControlModeText(SVRControlMode mode)
    {
        if (mode == SVRControlMode.Controller)
        {
            controlModeText.text = "Hand";
        }
        else
        {
            controlModeText.text = "Controller";
        }
    }
}
