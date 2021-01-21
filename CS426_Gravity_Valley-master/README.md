# CS426_Assignment_6
README

Physics:
The physic's objects in our game consists of:
	A large rolling ball trap to hit the player in the canyon.
	The player character, who has gravity that adjusts based on a 60 second timer.
	"Safezones" that reset the player's gravity timer when collided/triggered with.
	Food the player can pickup and collide with.

Lights:
	Every safezone has blue point light.
	The starting bunker area has a red glowing point light.
	We have a orange/yellow directional light acting as the sun.

Sounds:
	When the player walks, there are footstep sounds.
	When the door to the startup area opens, it makes a sci-fi door noise.
	A sound effect for when the player picks up food.
	When the player are getting close to the zombie, they will be able to hear that the zombie is sreaming.
	Background music is playing in the whole game.

Textures:
	Orange skybox to give the skies an alien look.
	Multiple ground textures
		Grass texture for the upper areas of the canyon
		Sand texture for the valley floor
		Rock texture, on the edges of the canyon
	Sci-Fi metallic textures on the starting area.

AI & MECANIM:
	Frederick Dempsey:
		AI: - AI boulder that rolls around part of the canyon
		  and uses a navigation mesh to determine how to roll to it's next location.
		Mecanim: - An animated door that triggers when the player first walks in front of it,
		  letting them into the outside world.
		  
	Jiajie Lin:
		AI: The zombie enemy will looking for any players that nearby in the specific range.
		And then running to the players and attack them. Since this AI is using FSM algoritm, it will
		change the enemy animation depend on the distance between the palyer and enemy.
		Mecanim - Enemy could stay in the idle if no player nearby, running to the player, and 
		attacking the player.
	Griselda Guzman:
		AI: Animal will move to markers. When player get near animal will follow player.

# Assignment 8


Jiajie Lin:
	Sounds:When the player are getting close to the zombie, they will be able to hear that the zombie is sreaming.
	Background music is playing in the whole game.
	UI:Fixed zombie enemy skin, since there are some issue in the pervious vision.
	
Griselda Guzman:
	UI: Added a light for door at start since it might be confusing for some people to notice that it is interactable at first.
	Added a healthbar and damage system. The game has a number of enemies and the enemies attacks have to have a consquence for the 	player. So every enemy can hurt the player.
	Also made sure the player takes damage when they float to high up.
	Sound: Added damage sound because a player needs feedback in more than just visuals for damage and added a jump sound.


Frederick Dempsey:
	UI: Switched the Gravity timer to a bar graph representation instead of just plain white text to better visually illustrate
	to the player the current gravity. 
	Altered the skys exposure so the color was less saturated.
	Replaced the ground level jump-pads with circular ones at different elevations.
	Sound: Added inventory open and close sound effects. Altered the walking sound effect to sound  bit more natural.
	
# Assignment 9
Jiajie Lin:

	Shader:Fire on the safety zone,inoder to make the safety zone more real and player will be aware there are dangerous.
	Issue fixed from alpha release: 
	heath bar icon fixed
	change the sky color
	main menu added ( for play, option, exit game)
	option(control) menu added for control game volume


Frederick Dempsey:

	Shader: Transparent orb around safety zones. Helps make them more noticeable to the player.
	
	Scenes: Intro story screen in the form of a star wars style into
	
	Alpha feedback changes:
	Context story screen to give players a better idea of what is happening at the start of the game
	Fixed bug allowing players to move/look around when the inventory screen is open
	Fixed bug where players were able to pick up more than one of an item due to it not disappearing right away
	Made crosshair smaller
	Fixed UI elements bug where they were not scaling for user’s different screen sizes.
	Moved UI elements further from center of the screen so as to be less distracting
	Fixed movement bug where players would jump too high or too low
	Added blue transparent orbs around safety zones to make them more noticeable to the player

	
Griselda Guzman:
	
	Added credit scene and added it as an option in the menu
	Added new scenery a crashed ship and tried adding shaders that would blend it with the terrain.
	Added Rabbit to starting area that wanders around there
	Adjusted height were player gets hurt for floating to high to be more forgiving.
	Bolder now hurts player.
	Shader: rabbit uses a custom shader that gives it a brownish tint.
