AUTHOR: Cole Spencer
This collection of scripts was written mainly by Cole Spencer as well as Jake Lovelace. 

Most of these scripts are relatively small and have basic functions to achieve. 
As a software engineer, I felt that simple small scripts were an easy and relatively efficient route to completing in game tasks.
A couple of the scrips like the GameManager, the Whistle, and the MenuManager are pretty complicated with dictionaries, lists, and UI panels to handle functions.
I decided to split some of the other game tasks into these simple scripts to make going through the code easier, rather than have even longer and more convoluted scripts.
This could be the wrong way to do it and I wouldn't know, but that's my approach; put things together in the same script that make sense, if not, make a new script.

Some things to note for whoever is lucky enough to read this:
	It could be way more efficient to handle these simple game tasks in one script rather than making several and having to reference them all.
	I use a LOT of if statements, I know they aren't always the most useful, sue me.
	Try to make use of generalized concepts, like instead of making one method for 10 tasks, try making one method with an intake variable that changes the method based on the intake
		(Definitely all up to preference, I just like to build functions around methods, rather than vice versa.)
		This also makes adding future features extremely simple, at least in my experience.
	Utilizing scripts for animation sequences (i.e. trying to make Unity's animator and your own scripts work together (StateMachineBehavior)) is a NIGHTMARE, just don't, you'll thank me later.
		You can use OnTriggerEnter or other types of methods in that regard for something having to occur once an object/player reaches a certain place