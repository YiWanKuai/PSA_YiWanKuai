# Folders

Materials folder is for .mat files.
Models folder is for 3D objects (.blend etc).
2D images go into Sprites.

# Setting up

Clone this repo (forking to your own is optional) into your local drive.
Open Unity, choose Open (at the top right) and select the folder that you have cloned.

# Committing

If you make changes that you aren't sure whether to overwrite the previous commit, branch your changes and make a pull request.
Since git does not support viewing parts of a .unity (scene) file, it is hard to resolve conflicts. Make commits incrementally as much as possible. If you want to make experimental changes while others are working on the main file, you can make a duplicate scene and make your changes there.

# How to do things

To make something respond to a touch, you can add an Event Trigger or a Button component. Using Event Trigger, add a New Event Type, select the current object you want to call a function on, then choose a function to call from the scripts in the object. Note that the function to be called must be public.