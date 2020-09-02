# ToyRobot

ToyRobot is .Net Core Console application. This is created as an exercise to demonstartion ToyRobot movement 
on a table top with a grid of 5*5 units. It accepts commands to move on Grid.

## Prerequisites

* .Net Core 3.1
* Visual Studio 2019 with C# / Visual Studio code (for dev environment)

## Run program on command prompt

Copy [Binary folder](https://github.com/keshaavg/toyRobot/tree/master/ToyRobot/Binary) locally and run ToyRobot.exe file.
	

## Run in Dev environement

Clone [Repository](https://github.com/keshaavg/toyRobot.git) on local machine and build solution in Visual studio

## Usage

```
PLACE 0, 0, North 
LEFT
RIGHT
MOVE
REPORT
EXIT
```

## Test Scenarios (Copied from exercise) 

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
