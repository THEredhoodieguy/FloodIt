//README.txt

Author: Matthew Pletcher
Website: Flood-it!
Course: A590-Web

Website Goals:
Create a site where users can play a puzzle game and compete with scores on the leaderboard.

Important Setup Information:
By and large, the website shouldn't require any additional work to set up,
though it may require rebuilding and restarting Visual Studio before working properly.
While other browsers will not prevent the website from functioning properly,
I have found that using Microsoft Edge to view the site makes the game playing experience smoothest

Important Structural Information:
The homepage of the website is Default.aspx, it uses the master page template set out in Site.master.
The homepage contains a number of asp controls used to influence the appearance and function of the site,
but the most important is the Table control. This control is built up in Default.aspx.cs using the FloodItBoard.cs class.
It displays the game board and responds to the player pressing the buttons. When a player finishes the game,
they have the option to submit their score alongside their initials to the leaderboard.
This is done in Default.aspx.cs using the LeaderboardFileLoader.cs class.
In addition to the homepage, there is also a tutorial page, which has no controls, and a leaderboard page.
The leaderboard page makes use of the LeaderboardFileLoader.cs class to load in saved scores to its asp table controls.

Important Styling Information:
The website is built on the Bootstrap open-source framework that Microsoft includes in every new ASP.Net project.
While the website is currently very bland, without much work put into making it visually pop, it is functional on
full-sized desktop screens in addition to phone screens due to its use of the Bootstrap framework.

Cut Features:
During development, I ran out of time, and so the custom size board ended up being cut. If I were to continue development
on this project, the next thing I'd add would be a page for creating a custom-size and seed game board. 
I also ran out of time to record the tutorial video

Styling notes:
Styles that were used are housed in the Content/Site.css

Important files to look at:
Default.aspx, Default.aspx.cs, Site.master, ContentPages/Leaderboard.aspx, ContentPages/Leaderboard.aspx.cs,
ContentPages/Tutorial.aspx, App_Code/DailySeedGenerator, App_Code/FloodItBoard.cs, App_Code/LeaderBoardFileLoader.cs