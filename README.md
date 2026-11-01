# VR Room F.Oke

A Meta Quest 2 VR project made in Unity for my ALU VR assignment. It has three scenes: a Hub start scene, the finished Unity Learn Create with VR course room, and a VR Room built from the intranet assets with a physics door, two sockets, an analog and digital wall clock, and animated hands.

## Requirements

- Unity 6000.3.27f1 (Unity 6.3) with Android Build Support (OpenJDK, Android SDK and NDK)
- XR Interaction Toolkit 3.3.2, OpenXR with the Meta Quest feature group, Input System, URP
- A Meta Quest 2 in developer mode for building to the headset

## Open and run

1. Clone the repo and open the folder in Unity Hub with Unity 6000.3.27f1.
2. Open `Assets/_Project/Scenes/Hub.unity`.
3. To test in the Editor, press Play. The XR Interaction Simulator is in each scene for Editor testing only.
4. To build, connect the Quest, open File > Build Profiles, choose Android and press Build And Run. The scenes are already in the build list: Hub, Fawziyyah Room, VRRoom.

## Controls

| Input | Action |
| --- | --- |
| Grip | Grab objects and the door handle |
| Trigger | Click UI, use activated objects (TV remote) |
| Hold A or X, aim, release | Teleport |
| Left stick | Move |
| Right stick | Snap turn (or smooth turn, set in Settings) |
| Left Menu button | Open the navigation menu |
| B (course room) | Reset position panel |

## Scenes

- **Hub**: start screen and room selection with previews.
- **Fawziyyah Room**: the Create with VR course project (Units 1 to 3: locomotion, grabbing, sockets, audio and haptics, activation events, UI, comfort, optimization and lighting).
- **VRRoom**: the intranet room. The power cell goes in the charger by the door, the white knight goes on the chessboard, the glass door opens by gripping its handle, and the wall clocks follow the device time. A reset button puts every object back.

The navigation menu in both rooms can return to the Hub, switch to the other room, or open Settings.

## Features

- Physics door using a Hinge Joint, a Fixed Joint handle and Velocity Tracking grab
- Sockets limited to their own objects with interaction layers and hover previews
- Analog clock driven by the system time, plus a digital clock
- Rigged hands animated from grip and trigger values
- Teleportation areas and anchors, continuous move, snap and smooth turning
- Settings for turning, comfort vignette, music and sound effect volume (saved between scenes)
- Interaction sounds with spatial audio, background music and scene fades
- Pastel sci-fi UI theme, instructions panel and reset button

## Project structure

```
Assets/_Project
  Animations   hand animator and clips
  Materials
  Models       VR Room assets and hands
  Prefabs      XR Origin Rig, NavigationMenu, hands
  Scenes       Hub, Fawziyyah Room, VRRoom
  Scripts      gameplay and UI scripts
  UI           fonts, sprites and panels
```

## Credits

- Unity Learn Create with VR course assets
- ALU intranet VR Room assets
- VR Hands models, CC BY 4.0
- Exo 2 font, SIL Open Font License

## Author

Fawziyyah Oke
