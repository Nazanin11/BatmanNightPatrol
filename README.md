# 🦇 Batman Night Patrol in Gotham

## Project Overview
This project is a simple **Batman Night Patrol Simulator** developed using **Unity**.  
The goal is to control Batman , manage different gameplay states, and work with basic lighting and sound effects in a nighttime environment.

The project focuses on fundamental Unity concepts such as:
- Character movement in 3D space
- State management using `enum` and `if/else`
- Basic lighting and audio systems
- Clean code structure and Git version control

> *Batman – The Dark Knight of Gotham*

---

## 🎯 Learning Objectives
By completing this project, the following objectives are achieved:

- Implement keyboard-based movement and rotation
- Manage multiple character states (Normal, Stealth, Alert)
- Create and control the Bat-Signal light in the sky
- Add alert-mode flashing lights and alarm sound effects
- Maintain clean, readable, and well-documented code
- Track development history using Git and GitHub

---

## 🕹️ Controls

### Movement
| Key | Action |
|----|--------|
| W / ↑ | Move Forward |
| S / ↓ | Move Backward |
| A / ← | Rotate Left |
| D / → | Rotate Right |
| Shift (Hold) | Sprint (Normal state only) |

---

### Batman States
| Key | State | Description |
|----|------|-------------|
| N | Normal | Default movement speed and normal lighting |
| C | Stealth | Reduced movement speed and dimmed environment lighting |
| Space | Alert | Activates alert lights and alarm sound |

---

### Bat-Signal
| Key | Action |
|----|--------|
| B | Toggle Bat-Signal On / Off |

- The Bat-Signal is implemented using a **Spot Light**
- When enabled, it slowly rotates in the sky with a smooth back-and-forth motion

---

## 🚨 Alert Mode Features
When the **Alert** state is active:

- Red and blue lights flash alternately
- Alarm sound plays using an `AudioSource`

When exiting Alert mode:

- Flashing lights stop
- Alarm sound stops immediately

---

