# ToyRobot

ToyRobot is .Net Core Console application. This is created as an exercise to demonstartion ToyRobot movement 
on a table top with a grid of 5*5 units. It accepts commands to move on Grid.

## Description
* The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.There are no other obstructions on the table surface.
* The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
* Create an application that can read in commands of the following form:

```
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
```

* PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.

* The origin (0,0) can be considered to be the SOUTH WEST most corner.

* The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.

* MOVE will move the toy robot one unit forward in the direction it is currently facing.

* LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.

* REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

* A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.

* Input can be from a file, or from standard input, as the developer chooses.

## Constraints
The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot.
Any move that would cause the robot to fall must be ignored.

## Prerequisites

* .Net Core 3.1
* Visual Studio 2019 with C# / Visual Studio code (for dev environment)

## Run program on command prompt

Copy [Binary folder](https://github.com/keshaavg/toyRobot/tree/master/ToyRobot/Binary) locally and run ToyRobot.exe file.
	

## Run in Dev environement

Clone [Repository](https://github.com/keshaavg/toyRobot.git) on local machine and build solution in Visual studio

## Test Scenarios

### Scenario 1
```
PLACE 0, 0, North
Move 
Report => Output: 0, 0, North
```

### Scenario 2
```
PLACE 0, 0, North
LEFT 
Report => Output: 0, 0, West
```

### Scenario 3
```
PLACE 1, 2, East
MOVE
MOVE
LEFT
MOVE
Report => Output: 3, 3, North
```

## Additional improvements
* Could use .Net core DI and Logger for output rather than console.writeline
* Make grid dimensions configurable by using config files
* Sperate out user input validation and use some validation library like Fluent Validation for more cleaner and testable approach
