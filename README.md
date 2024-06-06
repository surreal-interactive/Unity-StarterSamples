# Surreal Touch: VR Gaming Controller for Apple Vision Pro

Surreal Touch, developed by [Surreal Interactive](https://surreal-interactive.com), is a VR gaming controller specifically designed for the Apple Vision Pro. This product aims to bridge the gap between the most immersive hardware and the vibrant VR game ecosystem.

We are dedicated to providing seamless support for developers, enabling them to port their exceptional VR games to this new platform effortlessly. With Surreal Touch, you can bring the most engaging and interactive VR experiences to life on the Apple Vision Pro.

# Get Started
In this tutorial, we will introduce how to port an Oculus project to a VisionOS application powered by Surreal Touch.

The [Oculus Starter Samples](https://github.com/oculus-samples/Unity-StarterSamples) provide a full-functionality scene where players can interact with and throw various game objects, showcasing the system's capabilities.
![image](https://github.com/surreal-interactive/SDK/assets/170064123/3bd21db6-4d54-4f44-9e47-c6765b3abce2)

# Step-by-Step Adaptation
To ensure a smooth development experience, we provide the Surreal VR SDK (SVR), designed to offer Oculus developers a plug-and-play experience.

To achieve this, we provide an overview of the one-to-one mapping for controller-related operations:


## Adaptation Overview

To ensure a smooth development experience, we provide the Surreal VR SDK (SVR), designed to offer Oculus developers a plug-and-play experience.

To achieve this, we provide an overview of the one-to-one mapping for controller-related operations:

| | Oculus VR SDK | Surreal VR SDK |
|--|--|--|
| Unity Package | [Oculus Unity Documentation](https://developer.oculus.com/documentation/unity/unity-ovrinput/) | [Surreal VR SDK GitHub](https://github.com/surreal-vr-sdk) |
| Camera Rig Prefab | OVRCamRig | SVRCamRig |
| Button Mapping | `OVRInput.Get(OVRInput.Button.One)` | `SVRInput.Get(SVRInput.Button.One)` |
| Button Down | `OVRInput.GetDown(OVRInput.Button.One)` | `SVRInput.GetDown(SVRInput.Button.One)` |
| Button Up | `OVRInput.GetUp(OVRInput.RawButton.X)` | `SVRInput.GetUp(SVRInput.RawButton.X)` |
| Thumbstick State | `OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)` | `SVRInput.Get(SVRInput.Axis2D.PrimaryThumbstick)` |
| Thumbstick Pressed | `OVRInput.Get(OVRInput.Button.PrimaryThumbstick)` | `SVRInput.Get(SVRInput.Button.PrimaryThumbstick)` |
| Thumbstick Up | `OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)` | `SVRInput.Get(SVRInput.Button.PrimaryThumbstickUp)` |
| Index Trigger State | `OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)` | `SVRInput.Get(SVRInput.Axis1D.SecondaryIndexTrigger)` |
| Left Index Trigger State | `OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)` | `SVRInput.Get(SVRInput.RawAxis1D.LIndexTrigger)` |
| Left Index Trigger Pressed | `OVRInput.Get(OVRInput.RawButton.LIndexTrigger)` | `SVRInput.Get(SVRInput.RawButton.LIndexTrigger)` |
| Secondary Gamepad Button Touched | `OVRInput.Get(OVRInput.Touch.Two)` | `SVRInput.Get(SVRInput.Touch.Two)` |

## Simple Adaption

Then, step-by-step operations are as follows:
1. Install VisionPro depended packages including:
   "com.unity.polyspatial"
   "com.unity.polyspatial.visionos"
   "com.unity.polyspatial.xr"
It's recommended to follow [Install a UPM package from a Git URL](https://docs.unity3d.com/Manual/upm-ui.html)
![need a better one](https://github.com/surreal-interactive/SDK/assets/170064123/be04d85c-a751-435e-941b-d92211e51aef)

2. Install Surreal Touch Unity package
Install package "https://github.com/surreal-interactive/SDK.git"

3. Replace OVRCamRig with SVRCamRig, to create a game object that accurately mirrors the real-world poses of the controllers.
![need a better one, full screen](https://github.com/surreal-interactive/SDK/assets/170064123/578c82ab-760e-4bde-ac5e-e00df79a2511)
![same](https://github.com/surreal-interactive/SDK/assets/170064123/21cdfde0-5fd8-4a96-a59c-1ff249a9d1da)

You can find corresponding example scene in following link
[TODO:]

In following examples We will demonstrate how to implement grabbing and UI interactions which are easily converted from OVR to SVR.

## Grab Interaction Adaption

Step-by-step operations are as follows:

1. Add "SVRDistanceGrabbable.cs" to gameobjects which are aimed for grabbing
Let's take a look at original OVR StarterSamples
![img_v3_02bh_0e2db549-823e-4377-a292-d08141cdb65h](https://github.com/surreal-interactive/SDK/assets/73978606/0a9ece24-7da6-4842-8ae8-332766f67521)

In our own case, Add mirror script "SVRDistanceGrabbable.cs" to gameobjects aimed for grabbing
![image](https://github.com/surreal-interactive/SDK/assets/73978606/7aecbbbf-b767-4263-abac-69bc33ecba67)

2. Add Rigid body to grabbing objects

Now we can grab objects by pressing down "Trigger" button, you can find corresponding example scene in followin link
[TODO:]

## UI Interaction Example


1. Replace "GraphicsRaycaster" with "SVRRaycaster.cs"
Deactivate "GraphicRaycaster" component which is added to canvas by default, replace it with "SVRRaycaster.cs"
![image](https://github.com/surreal-interactive/SDK/assets/73978606/28b7ded4-9a28-4669-bd75-19bdb2d854b6)

2. Bind callback functions
Add callback functions
![image](https://github.com/surreal-interactive/SDK/assets/73978606/4b305fcd-c4e9-459d-b6de-2aa94e242f43)

SVR interaction sdk will activate Unity.UI system's callback, you can adapt your own projects to SVR barely nearly unchanged.
You can find corresponding example scene in followin link
[TODO:]

