using System;

/////////////////////////// Creativity implemented: ////////////////////////////////////

// I added several extra classes into the program that helps colorcode all of the goals.

/* 
The colors and their meanings are: 
Green = Complete 
Eternal Goal = Yellow 
Incomplete Goal = Red
*/

/*
 I also added a backtrack system, 
 so in case info needs to be changed, 
 the goal doesn't have to be deleted 
 but rather just changed from the menu.
*/

// I also went back through my code to make sure the syntax makes sense and is navigatable
// and easier to read.
 
///////////////////////////////////////////////////////////////////////////////////////////
class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.EnableAnsi();
        var manager = new GoalManager();
        manager.Run();
    }
}
