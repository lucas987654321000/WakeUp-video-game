Team Galaxian Presents: WakeUp

Start Scene: Demo

How To Play: Move with WASD or arrow keys, jump with space, press p to pause, press q to attack

Objective: You are trapped in a scary dream world and want to escape. Avoid enemies and collect the coffee collectables to unlock new mechanics and boost your 
	   stats, which will help you reach the end of the level and escape.

Technologies: 
- AI State Machine implemented with the Enemy so that it follows you around via NavMesh and attacks when close enough (Based on waypoints and moving waypoint which is the player)
- Combat allows you to fight AI enemies, a necessary task to progress through the last two levels.
- Coffee is implemented as a collectable for the player (part of the objective), coffee placed around map (first one located in a maze)
- Animations are implemented using the animator controller (notice enemy and player movement)
- Hover platforms allow the player to move to different stages of the levels after collecting two coffees (Can first be seen after collecting second coffee in first level)
- The door is animated through mecanim and triggered using ontrigger functions (First door located to left when you start game)
- Lighting uses an FSM (can see gradual lighting change after collecting first coffee)
- UI for start and win screens, as well as UI prompts notifying the player about features they unlock after collecting coffee
- Sounds triggered by colliders (Listen to door open and creepy lullaby upon entering maze)
- Through the use of other triggers we made it so certain tasks needed to be completed to progress in a level (in second level, you must kill three skeletons to 'unlock' the door)

Problem Areas:
- Slight delayed jump animation
- Walk through door when the open door animation hasn't completed


Individual Team Tasks: 

Lucas(CoffeeGrabber.cs, CoffeeCollector.cs, GameController.cs, PlayerController.cs, LullabyAudio.cs, MusicController.cs, DoorUnlock.cs, EnemyDeathTrigger.cs, LullabyTrigger.cs): 
- Worked on creating materials related to the skybox and door 
- Worked on implementing the lighting effects (gradual exposure and intensity and spotlight) illustrated within the game
- Worked on the player controller
- Worked on the coffee collectable
- Worked on implementing the health on the UI
- Worked on implementing theme sounds within the game
- Helped with various bugs that the team was having
- Implemented audio triggers and other triggers (such as needing to kill enemies to unlock a door to progress through the levels)

John G (PlayerController.cs, VoidBoundary.cs, SimpleCameraController.cs, Jump.cs):
- Worked on fixing player model bugs in which capsule collider separated  from the player model 
- Worked on the Jump script which was moved over to PlayerController for implementation with the animator 
- Fixed the bug of allowing sticking and jumping on the sides of walls by utilizing a separate collider that checks for collision and uses a frictionless physics material
- Implemented the initial camera, playerobject, movement and scene alongside creating a barrier that teleports the user back to the spawn point 
- Helped Lucas make the coffee grabber script to make the coffee disappear and allow for jumping
- Assisted in finding materials and models from the Unity store

John O (PlayerController.cs, SimpleCameraController, UpDownScript.cs):
- Worked on trying to animate the platforms
- Worked on the world and all the platforms
- Worked on implementing the walls
- Aided in combat scripts

Hai (Enemy.cs, EnemyAwarenessZone.cs, EnemyState.cs, SkeletonAI.cs):
- Worked on getting the enemy model and animations into the game
- Worked on implementing the AI state machine for the enemy so that it chases the player and patrols
- Worked on bleeding animation if the enemy attacks the player
- Assisted in finding materials and models from the Unity store
- Assisted in debugging and creating key interactions with the Skeleton AI enemies

Sarju (PlayerController.cs, UIHandler.cs, Pause.cs, OpenDoor.cs, DoorOpener.cs, NextLevelTrigger.cs):
- Worked on finding and implementing the player model and syncing it within the game
- Worked on getting the animations for the player model such as jump, running, walking forwards, etc.
- Worked on implementing and blending the walking forwards, walking backwards, and jumping animations via a new animatorController and editing the player controller script to play animations depending on input (refactored input as well)
- Fixed bugs regarding model going into the ground or in the sky (also rotating) after multiple transitions
- Worked on the all the UI screens and buttons and the UIHandler and Pause scripts coordinating the Start and Pause Menus
- Created UI pop-up notifications about unlocking new features as one collects coffee.
- Worked on creating the entry and exit doors and implementing functionality with the OpenDoor and DoorOpener scripts
- Worked on debugging combat issues


Coffee Assets Used:
	- Coffee Mesh/Textures: https://assetstore.unity.com/packages/3d/props/food/coffee-cup-pbr-224789

Door Assets Used: 
	- Sounds: https://pixabay.com/sound-effects/door-open-and-close-with-a-creak-102380/
	- Texture/Materials: Made by Lucas

World Assets Used:
	-Platform Textures/Materials: https://assetstore.unity.com/packages/2d/textures-materials/world-materials-free-150182

Character Assests Used:
	-Player Avatar/Character: mixamo.com
	-Player Animations: mixamo.com

Enemy Assests Used: 
	-Enemy Avatar/Character: https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy-monster-skeleton-35635
	-Enemy Animations: https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy-monster-skeleton-35635

Environment Sound Assets Used:
	-Lullaby: https://freesound.org/people/InspectorJ/sounds/412224/
	-General Music: https://freesound.org/people/FoolBoyMedia/sounds/323443/