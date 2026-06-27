# Cube Selection Task - Unity Assessment

## Overview

This project is a Unity first-person interaction game developed as part of a Unity Developer assessment.

The player is placed inside a room containing three randomly colored interactable objects. One object is randomly selected as the correct object at the start of the game. The player uses the first-person camera to look at the objects and receive visual and audio feedback.

The project was designed with a modular architecture so that it can easily support additional interactable objects in the future.

---

# Unity Version

- Unity 6
- Language: C#
- Platform: Windows

---

# Part 1 - First Person Interaction

## Features

- First-person camera.
- Three randomly colored interactable objects.
- One object is randomly selected as the correct object.
- Looking at the correct object:
  - Changes its color to white.
  - Plays a success sound.
  - Displays **"Correct"** in the center of the screen.
  - Disables further interaction with that object.
- Looking at an incorrect object:
  - Briefly flashes the object red.
  - Displays **"Try Again"**.
  - Keeps interaction enabled.

---

# Part 2 - Architecture Improvement

The project architecture was refactored to support future expansion with minimal code changes.

Instead of creating object-specific scripts, a reusable interaction system was implemented.

Changes include:

- `CubeBehaviour` renamed to `InteractableObject`
- `CubeSelector` renamed to `PlayerInteractor`
- `GameManager` now manages an array of `InteractableObject`
- Any GameObject can become interactable by attaching the `InteractableObject` component

This allows the project to support many different interactable objects (chairs, bottles, lamps, keys, etc.) without modifying the interaction logic.

---
