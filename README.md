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

# Part 3 - Debugging

## Observations

1. The script snippet does not include `using UnityEngine;` at the top. If this line is missing from the actual script, the code will not compile because classes like `MonoBehaviour`, `GameObject`, `Input`, and `KeyCode` are part of the UnityEngine namespace.

2. The coin is spawned without a specific position or rotation. The code will still work, but it is not clear where the coin will be created because it uses the prefab's default transform. It is better to specify the spawn position and rotation so the coin always appears at the intended location.

Example:
Instantiate(coinPrefab, transform.position, Quaternion.identity);

3. The script creates a new coin every time the Space key is pressed. This works, but if the key is pressed many times, the scene can fill up with coins and performance may decrease. I think adding a limit to the number of coins, or using object pooling methods would make the script better.

 Example (limiting the number of coins):

public int maxCoins = 10;
private int currentCoins = 0;

if (Input.GetKeyDown(KeyCode.Space) && currentCoins < maxCoins)
{
    Instantiate(coinPrefab, transform.position, Quaternion.identity);
    currentCoins++;
}  

## Optimization Suggestions

5. The input key is hardcoded to `KeyCode.Space`. It would be better to make the input configurable (for example, through the Inspector or Unity's Input System) so it can be changed without modifying the code.

6. The script does not check whether `coinPrefab` has been assigned. If it is left empty in the Inspector, pressing the Space key will result in a `NullReferenceException`. Adding a null check would make the script more stable.

---

# Part 4 - Explain Your Decisions

## 1. How have you structured your project? What was your thought process behind your choices?

I structured the project by separating different responsibilities into individual scripts so that each script has a clear and specific purpose.

- **GameManager** initializes the game by assigning random colors to the interactable objects and selecting one object as the correct choice.
- **PlayerInteractor** handles raycast detection and determines which object the player is looking at.
- **InteractableObject** manages the behaviour of each interactable object, including changing color, flashing red, and disabling interaction after a correct selection.
- **UIManager** is responsible for displaying feedback messages such as "Correct" and "Try Again".
- **AudioManager** manages the success sound effect.


**Thought Process:**

The main idea was to keep the system simple and easy to manage. At first, the interaction logic was directly written for cube objects. Later, I improved it by making a generic interactable component so it can work with any GameObject, not just cubes.

I also split the logic into separate scripts so each one has a single responsibility. This makes the code easier to read, understand, and modify in the future. It also reduces dependencies between systems, which helps keep the project more flexible.

## 2. If another developer joined tomorrow, how would they understand your code?

I used meaningful class names, method names, and comments where necessary to make the code easy to follow.

The project is organized so that each script has a single responsibility:

- **GameManager** manages the overall game logic.
- **PlayerInteractor** handles player interaction through raycasting.
- **InteractableObject** controls the behaviour of interactable objects.
- **UIManager** manages all UI feedback.
- **AudioManager** handles sound effects.

Because responsibilities are separated, another developer can quickly identify where each feature is implemented without needing to understand the entire project first. The project structure also makes it easier to modify or extend individual features without affecting the rest of the system.

---

## 3. If I had another day, what would I improve?

If I had another day, I would try to improve the gameplay and make the project more complete and scalable.

Some things I would work on:

- Add a restart or replay button after the correct object is found.
- Add a simple scoring system and a timer.
- Improve visuals with basic animations and smoother UI transitions.
- Add different sound effects for correct and incorrect interactions.
- Make interactable objects spawn in random positions instead of fixed locations.

These changes would make the game more fun to play and also make the project feel more complete and easier to expand later.
