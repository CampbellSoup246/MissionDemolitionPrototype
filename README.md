# MissionDemolitionPrototype

#Implemented features:
High score tracking the least number of projectiles needed to achieve the goal. Implemented using PlayerPrefs and are stored on a per level basis.
Limited number of shots on each level to 10 and made a game over screen pop up upon the firing of the tenth projectile, signaling that the player lost and must begin again.
Made it so that there are two different materials in the game, and wood is usually about half the mass of stone so it is (technically speaking) easier to knock down.

#Difficult things:
A few things from the book didnt quite work right but with help from slack they usually did, except for the button up at the top that was supposed to create a Rect which would then allow changing between the three camera views. This never appeared for me and in the end I had to create my own button to do just switching to the Slingshot view so that the camera wouldnt linger for an entire minute as the projectile slowly rolled down a block that was at an incredibly slight incline.

Another issue was the towers themselves! I spent hours upon hours just rebuilding and trying a trillion different things to make them stop sliding and falling apart on their own, even the default one the book told us step by step how to make would slowly slide apart the moment the level loaded, and collapse with the player doing nothing at all. It had to do almost exclusively with the horizontal blocks, which the normal walls would slowly push outwards until they fell right through. I had to tie these blocks together using a parent empty gameobject just to get them to finally stay put. Even then, it now made the game harder as the towers were more difficult to knock down (1st one especially), and the others will still even sometimes slide apart all on their own.
