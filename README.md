# Creature Feature

Name: Kevin Li

UNI: kl3285

Date of submission: February 19, 2024

Computer platform: macOS (Sonoma 14.1.1), Macbook Pro 14-in. (2021), Apple M1 Max, 32 GB RAM

Unity version: 2022.3.18f1

Mobile platform: Samsung One UI 6.0, Android 14, Samsung Galaxy S23 Ultra

## Project description: 

The project fully implements ALL mandatory features outlined in the project requirements. 

- All code is in 'Scripts' folder. 

- All animations are in 'Animation' folder.

- All materials are in 'Material' folder.

- All prefabs are in 'Prefab' folder.


The scene is 'MainScene' in 'Scene' folder.

Upon opening the app, the game starts. The goal of the game is to capture at least one of 
each of the 3 creature types: Land, Air, Sea. Upon capturing one of each creature type, 
using the orb, the player can either continue or restart the game. If the player catches 
all creatures in the world (6 in total, 2 of each creature type), they are then able to 
restart the game or continue and explore the world. If the player loses all 5 life points, 
then the game is over and they can either restart or quit the app. 
During gameplay, the user is able to enter the partyroom to check their progress. 
If they tap on the rotating podiums with creatures, the corresponding model will start
dancing. The user can tap on a dancing creature to stop its dance.

In terms of controls, the player is able to move around the world freely using the 
left-movement joystick and shoot orbs with the right button. The player can shoot infinite 
orbs. There is also a slider that moves the reticle and the direction at which the orb is shot. 
A 'Switch Camera' button also exists on the top-right corner, enabling the player to 
access the party room. 

The game state is done by using a GameStateManager script, 
which is attached to an empty gameobject. This GameStateManager instance is referenced 
in each creature object and the player to control game state. There is also a UIManager 
script that controls the UI and is referenced in the GameObjectManager. 
Upon changes in gamestate, the UIManager updates the view.

The following bullet points summarize specific implementation details of game elements:
- All creatures were created using basic 3D objects in Unity and organized with parent hierarchies. 
- Creature capture logic (including capture range rendering) was implemented using colliders and triggers. 
- Colliders were used to prevent the player from entering certain areas (i.e., the pond and world bounding box).
- Camera movement is limited to left and right panning. The player can move using the left-joystick while 
    panning the camera simultaenously. The player will move in the same direction as the camera 
    (i.e., if the player pans the camera while having the joystick pivot forward, 
    the game player object will move forward relative to the forward axis of the camera).
- Scripts were modularized for clarity and simplicity (i.e., some scripts only control movement, 
    while others only specific actions or object traits like the capture range). 
    All of the scripts have also been organized into different folders depending on their 
    targets (i.e., creatures, player, UIManager, GamestateManager etc.). 
    Scripts are attached to their specific gameobject. Some references were assigned 
    directly in the inspector while others were assigned using code in the script.
- Animations were implemented for creature movements, namely the jump and flip for 
    the sea creature and the party room dance movements. The AnimationController was also used. 
- The orb and projectiles have lifetimes. After a certain period of time, they disappear. This was
    done by destroying those objects. 
- The PlayerController was used to implement player joystick movements. 
    Tutorial to the function has been linked below.
- Free assets from the Unity Asset store have been included (please see below for links to assets). 
- UI elements were created in Figma and exported as PNGs into the assets folder. 
    These included the hearts and reticle. These elements are represented as Sprite objects.
- The party room creature models have been predefined in place and are smaller in scale (i.e., catching a creature
    does not actually move it over). They simply have their visibility turned on and off to fulfill 
    the project requirements.


Nielsen Usability Heuristics:
1. Visibility of System Status - the UI was designed to keep users informed of the game state, 
    namely whether they are alive. The user can refer to the hearts on the top left corner of the display. 
    These represent the player's life status. Red hearts represent existing life points 
    while gray ones represent received damage. 
2. Match Between the System and the Real World - certain elements of the UI controls were designed to 
    intuitively communicate their function. The left joystick, for example, has 4 triangle icons to 
    indicate that toggling it would affect player movement.
3. User Control and Freedom - upon GameOver, users are given the choice to either exit the game 
    or restart. Upon fulfilling the win condition (i.e., catching one of each creature type), 
    users can either continue to restart. Similarly, upon catching all the creatures, users 
    can also continue or restart directly. If they choose the former, an additional restart 
    button will be rendered for them. Thus, user freedom is guaranteed. 
4. Consistency and Standards - consistent icons and menu layouts are used. For instance, the Win, 
    GameOver, and Game Completed pop-up windows have the same layouts. The same color scheme 
    (i.e. blue and gray) are used for the buttons to indicate the primary and secondary actions. 
5. Error prevention - the UI elements are simple and intuitive to prevent memory burdens. 
    Pop-up windows appear upon changes in game status (i.e., gamOver, winning condition fulfilled) 
    and present users with a confirmation option before they commit to action. 
6. Recognition Rather than Recall - elements, including the reticle, prioritize recognition over 
    recall. Users will know where the orb aim is rather than have to remember where it is currently 
    facing (especially after moving the orb slider).
7. Flexibility and Efficiency of Use - the incorporation of a slider for the orb shooter allows 
    players to customize the orb shooting direction, granting users more flexibility with game controls.
8. Aesthetic and Minamlist Design - the UI is clean and only includes necessary textual information. 
    No UI elements intend on distracting the user. 
9. Help Users Recognize, Diagnose, and Recover from Errors - pop-up messages appear when gamestate 
    changes occur (i.e., game over, winning condition fulfilled). The primary text is bolded to 
    inform them of game state. Secondary text also provides information about what happens with each button. 
10. Help and Documentation - as the system is simple and intuitive, no extra documentation 
    is included. Concise, textual information on pop-up messages, as mentioned above, 
    help users determine the next step.

Resolved problems:
- Difficulties were faced when trying to initially deploy the game to my mobile device, 
    namely the "Gradle Build Error." This required me to navigate to the Android SDK manager 
    in the command line and manuallyaccept licenses. The error was resolved after this. 
    Other than this, no other complicated problems occured. There were, however, 
    error messages in the Android Logcat after deploying the game to my mobile device. 
    These errors pertain to memory allocation but no problems have been discovered during gameplay.

##Free assets list:
- https://assetstore.unity.com/packages/3d/props/exterior/simple-buoy-4734
- https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153
- https://assetstore.unity.com/packages/3d/props/exterior/street-lamps-165658

##References
Various tutorials were consulted during the implementation:
- https://www.youtube.com/watch?v=UjkSFoLxesw
- https://www.youtube.com/watch?v=_yR9FL4LXGE
- https://www.youtube.com/watch?v=PKNne6PgwhQ&t=392s
- https://youtu.be/Ay159WsGDJQ?si=zEIVEe4Nwr3BrlfC
- https://youtu.be/qQLvcS9FxnY?si=ZWnYeew8y3e1cIYL
- https://www.youtube.com/watch?v=zd75Jq37R60
 
##Video Demonstration: 
https://youtu.be/U7qMJANZk7A
