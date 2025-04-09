using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.XR.Hands;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Unity.PolySpatial.InputDevices;


public class ControlModeManager : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> curRaycastObjs = new List<GameObject>();
    private GameObject leftCurRaycastObj;
    private GameObject rightCurRaycastObj;
    private Dictionary<string, GameObject> raycastCandidates = new Dictionary<string, GameObject>();

    public GameObject controllerRootObj;
    public GameObject handRootObj;
    public GameObject leftControllerTrackStartObj;
    public GameObject rightControllerTrackStartObj;
    public GameObject leftHandTrackStartObj;
    public GameObject rightHandTrackStartObj;
    public GameObject leftHandRoot;
    public GameObject rightHandRoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackRaycastingObjects();

        if (SVRInput.GetControlMode() == SVRControlMode.Hand)
        {
            leftHandRoot.transform.position = SVRInput.GetLeftControllerPosition();
            leftHandRoot.transform.rotation = SVRInput.GetLeftControllerRotation();

            rightHandRoot.transform.position = SVRInput.GetRightControllerPosition();
            rightHandRoot.transform.rotation = SVRInput.GetRightControllerRotation();
        }

        if (SVRInput.GetDown(SVRInput.Button.LIndexTrigger))
        {
            TriggerLeftClick(leftCurRaycastObj);
        }


        if (SVRInput.GetDown(SVRInput.Button.RIndexTrigger))
        {
            TriggerRightClick(rightCurRaycastObj);
        }

    }

    public void SwitchControlMode(SVRControlMode mode)
    {
        if (mode == SVRControlMode.Controller)
        {
            SVRInput.SwitchMode(mode);
            controllerRootObj.SetActive(true);
            handRootObj.SetActive(false);
        }
        else
        {
            SVRInput.SwitchMode(mode);
            handRootObj.SetActive(true);
            controllerRootObj.SetActive(false);
        }
    }

    public static bool FindTarget(
        Vector3 raycastStartPt,
        Vector3 raycastDir,
        ref Dictionary<string, GameObject> raycastCandidates,
        out GameObject hitObject,
        out Vector3 hitPt)
    {
        hitObject = null;
        hitPt = Vector3.zero;

        Ray ray = new Ray();
        ray.direction = raycastDir;
        ray.origin = raycastStartPt;
        RaycastHit obstructionHitInfo;


        if (Physics.Raycast(raycastStartPt, raycastDir, out obstructionHitInfo, 100.0f, 1 << 5))
        {
            hitObject = obstructionHitInfo.transform.gameObject;
            hitPt = obstructionHitInfo.point;
        }

        return hitObject != null;
    }

    public bool FindRaycastTarget(
    int chirality,
    out GameObject raycastObj,
    out Vector3 raycastPosition)
    {
        GameObject hitObj = null;
        Vector3 hitPosition = Vector3.zero;

        bool hitFlag = false;
        if (chirality == 0)
        {
            if (SVRInput.GetControlMode() == SVRControlMode.Controller)
            {
                FindTarget(
                leftControllerTrackStartObj.transform.position,
                leftControllerTrackStartObj.transform.forward,
                ref raycastCandidates,
                out hitObj,
                out hitPosition);
            }
            else
            {
                FindTarget(
                leftHandTrackStartObj.transform.position,
                leftHandTrackStartObj.transform.forward,
                ref raycastCandidates,
                out hitObj,
                out hitPosition);
            }
        }
        else
        {
            if (SVRInput.GetControlMode() == SVRControlMode.Controller)
            {
                FindTarget(
                rightControllerTrackStartObj.transform.position,
                rightControllerTrackStartObj.transform.forward,
                ref raycastCandidates,
                out hitObj,
                out hitPosition);
            }
            else
            {
                FindTarget(
                rightHandTrackStartObj.transform.position,
                rightHandTrackStartObj.transform.forward,
                ref raycastCandidates,
                out hitObj,
                out hitPosition);
            }
        }
        

        if (chirality == 0)
        {
            if (hitObj != leftCurRaycastObj)
            {
                leftCurRaycastObj = hitObj;
            }
        }
        else
        {
            if (hitObj != rightCurRaycastObj)
            {
                rightCurRaycastObj = hitObj;
            }
        }


        raycastObj = hitObj;
        raycastPosition = hitPosition;
        return hitFlag;
    }

    public void TrackRaycastingObjects()
    {
        GameObject leftRaycastObj = null;
        GameObject rightRaycastObj = null;
        Vector3 leftRaycastPosition = Vector3.zero;
        Vector3 rightRaycastPosition = Vector3.zero;
        FindRaycastTarget(0, out leftRaycastObj, out leftRaycastPosition);
        FindRaycastTarget(1, out rightRaycastObj, out rightRaycastPosition);

        int raycastObjCount = 0;
        while (raycastObjCount < curRaycastObjs.Count)
        {
            if (curRaycastObjs[raycastObjCount] != leftRaycastObj && curRaycastObjs[raycastObjCount] != rightRaycastObj)
            {
                if (curRaycastObjs[raycastObjCount].GetComponent<UI_SampleButton>())
                {
                    curRaycastObjs[raycastObjCount].GetComponent<UI_SampleButton>().ChangeMatState(SampleButtonMatState.Default);
                }
                curRaycastObjs.RemoveAt(raycastObjCount);
            }
            else
            {
                raycastObjCount += 1;
            }
        }

        if (leftRaycastObj != null && !curRaycastObjs.Contains(leftRaycastObj))
        {
            if (leftRaycastObj.GetComponent<UI_SampleButton>())
            {
                leftRaycastObj.GetComponent<UI_SampleButton>().ChangeMatState(SampleButtonMatState.Highlight);
                curRaycastObjs.Add(leftRaycastObj);
            }
        }

        if (rightRaycastObj != null && !curRaycastObjs.Contains(rightRaycastObj))
        {
            if (rightRaycastObj.GetComponent<UI_SampleButton>())
            {
                rightRaycastObj.GetComponent<UI_SampleButton>().ChangeMatState(SampleButtonMatState.Highlight);
                curRaycastObjs.Add(rightRaycastObj);
            }
        }
    }

    public void TriggerRightClick(GameObject curClickObj)
    {
        if (curClickObj != null)
        {
            if (curClickObj.GetComponent<UI_SampleButton>())
            {
                if (curClickObj.GetComponent<UI_SampleButton>().buttonName == "SwitchMode")
                {
                    if (SVRInput.GetControlMode() == SVRControlMode.Controller)
                    {
                        SwitchControlMode(SVRControlMode.Hand);
                    }
                    else
                    {
                        SwitchControlMode(SVRControlMode.Controller);
                    }
                }
            }
        }
    }


    public void TriggerLeftClick(GameObject curClickObj)
    {
        if (curClickObj != null)
        {
            if (curClickObj.GetComponent<UI_SampleButton>())
            {
                if (curClickObj.GetComponent<UI_SampleButton>().buttonName == "SwitchMode")
                {
                    if (SVRInput.GetControlMode() == SVRControlMode.Controller)
                    {
                        SwitchControlMode(SVRControlMode.Hand);
                    }
                    else
                    {
                        SwitchControlMode(SVRControlMode.Controller);
                    }
                }
            }
        }
    }
}
