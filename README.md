# Surreal Touch: VR Gaming Controller for Apple Vision Pro

Surreal Touch, developed by [Surreal Interactive](https://surreal-interactive.com), is a VR gaming controller specifically designed for the Apple Vision Pro. This product aims to bridge the gap between the most immersive hardware and the vibrant VR game ecosystem.

We are dedicated to providing seamless support for developers, enabling them to port their exceptional VR games to this new platform effortlessly. With Surreal Touch, you can bring the most engaging and interactive VR experiences to life on the Apple Vision Pro.

# Overview

This is a simple Unity visionOS project powered by Surreal Touch, structure of the [DistanceGrab scene](./Assets/Scenes/DistanceGrab.unity) is pretty similar to the sample scene in [Oculus Unity-StarterSamples](https://github.com/oculus-samples/Unity-StarterSamples/blob/d1df2ece3ed7fcc572ac645cbe240beabd611547/Assets/StarterSamples/Usage/DistanceGrab.unity).

We encourage you to build and run the sample scene first before you dive into Surreal VR SDK, compare the differences between two scenes will help you to port your original Oculus projects to "Surreal Touch visionOS projects" smoothly.

After that, it's recommended to try Surreal VR SDK following [Step-by-Step instruction](https://github.com/surreal-interactive/SDK/blob/master/README.md) based on a brand new scene under this project.

<p align="center">
   <img src="https://github.com/user-attachments/assets/95797844-f26a-41f4-9d15-5884247c194a" alt="description" width="80%">
</p>

__Note__

__Versions of Unity prior to 2022.3 are not supported.__


# Build And Run Sample Scene

Follow instructions below to build and run:

1. Switch target platform to visionOS

   Build DistanceGrab.unity by switching target platform to visionOS, a xcode project will be created.

<p align="center">
   <img src="https://github.com/user-attachments/assets/ee35418d-96d9-4add-b79d-314fd72e46a7" alt="description" width="80%">
</p>

2. Request bluetooth permission

   Open the xcode project, request bluetooth permission by adding "Privacy - Bluetooth Always Usage Description" in plist document.

<p align="center">
   <img src="https://github.com/user-attachments/assets/40d00cf7-4fac-473b-b5ac-e6c89d8002c4" alt="description" width="80%">
</p>

3. Build xcode project

   Now you can build your xcode project and don't forget to connect Surreal Touch controllers to Apple Vision Pro in Settings/Bluetooth!


# Adapt Oculus Project to Surreal visionOS

Assume you have developed an application with Oculus SDK such as [Unity-StarterSamples](https://github.com/oculus-samples/Unity-StarterSamples/blob/d1df2ece3ed7fcc572ac645cbe240beabd611547/Assets/StarterSamples/Usage/DistanceGrab.unity) before, now we demonstrate how to adapt it from Oculus to Surreal visionOS.

1. Delete Oculus relevant objects

   There are three game objects which are relevant to Oculus in this scene:
   
   1,1. `CanvasWithDebug`
   
   1.2. `DistanceGrabberSampleScript`
   
   1.3. `PlayerController`

<p align="center">
    <img src="https://github.com/user-attachments/assets/29337020-fd59-4b01-8a3a-3ce219da87c7" alt="description" width="80%">
</p>

2. (Optional)Replace `DistanceGrabbable.cs` with `SVRDistanceGrabbable.cs`

   `DistanceGrabbable.cs` and `Hand.cs` are Oculus relevant scripts mounted on game objects which are grabbable, let's replace them with `SVRDistanceGrabbable.cs`.

<p align="center">
   <img src="https://github.com/user-attachments/assets/2eb7eade-260c-4c4c-ba33-50d9b29bd242" alt="description" width="80%">
</p>

3. Follow step-by-step instruction in [Surreal VR SDK](https://github.com/surreal-interactive/SDK/tree/master)

   You get a pretty clean environment right now, you can follow the step-by-step instruction as shown in [Surreal VR SDK](https://github.com/surreal-interactive/SDK/tree/master):

   SDK Step1. `Install Vision Pro depended packages`

   SDK Step2. `Install Surreal Touch Unity package`

   SDK Step3. `Check visionOS in Project Settings`

   SDK Step4. `Put SVRCameraRig into your scene`

   SDK Step5. `Build Unity project`

   SDK Step6. `Request bluetooth permission and build xcode project`
   
4. All Done!

   Don't forget to connect Surreal Touch controllers to Apple Vision Pro in Settings/Bluetooth in your device!
   
Video here:

   [Distance grab.webm](https://github.com/surreal-interactive/SDK/assets/73978606/a706a050-3729-40ec-af5e-baa2421e1634)
