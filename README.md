# Launchpad Project (Blackthornprod Course)

This project is a modified version of the **Launchpad** game built as part of the [Blackthornprod Launchpad course](https://gamedevrocket.podia.com/view/courses/launchpad/2649892). The course is aimed at absolute beginners, but I saw it as an opportunity to improve the code by addressing several code smells and enhancing functionality.

----

## Improvements and Enhancements

While following the course, I noticed some coding issues and opportunities for refactoring. Below are some key improvements I made:

- **Event System Integration**: The original project didn't leverage an event system. I refactored the code to use events, improving scalability and decoupling between game systems.
- **Scriptable Objects**: I adapted the project to use Scriptable Objects for managing data, making it easier to add new resources, buildings, and enemies. This also improved the maintainability of the project.
- **Singletons for Managers**: Added singletons for various managers to streamline game management.
  
----

## Planned Features
- **Main Menu and Game Over Scene**: Implement basic navigation between the game and menu scenes.
- **In-Game Tutorial**: Create a simple tutorial to guide new players through the gameplay mechanics and objectives.
- **More Enemies and Player-Controlled Humans**: Increase the variety of enemies and add player-controlled units for a richer gameplay experience.
- **Dynamic Shop & Resources UI**: Easily extend the game by adding new buildings or resources simply by creating a new Scriptable Object. The UI dynamically adapts to the newly added content.
- **Enhanced Enemy Spawning**: Added more robust enemy spawning logic that is event-driven and scalable.

----

## How to Play

1. **Objective**: Sacrifice 25 workers to the altar. Manage your resources to build structures and defend your base against waves of enemies.
2. **Controls**:
   - **Left-click** to select and move workers to harvest various resources.

----

## Assets Used

### Paid Assets
- None required, the only paid assets I used are editor scripts to enhance my productivity.

### Free Assets
- [Stylized Fire VFX](https://assetstore.unity.com/packages/vfx/particles/stylized-fire-vfx-199626) by HungNguyenVFX

----
