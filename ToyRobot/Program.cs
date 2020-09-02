using System;
using System.Collections.Generic;

namespace ToyRobot
{
    class Program
    {
        /// <summary>
        /// Program main entry points
        /// </summary>
        /// <param name="args">Command line arguments, not expecting any for running this program</param>
        static void Main(string[] args)
        {
            ToyRobot toyRobot = null;

            // Loop indefinetly till "exit" is entered or unhandles exception occurs
            while (true)
            {
                try
                {
                    // Waiting for user Input
                    Console.WriteLine("Enter Command: ");
                    var userInput = Console.ReadLine();

                    // Exit loop and program if exit is entered
                    if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    // Parse user input in string array
                    var commandWithParameter = userInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //Convert first element to command
                    Enum.TryParse(commandWithParameter[0], true, out Command command);

                    // Check if Place is executed before as no other command is allowed before it. 
                    if (toyRobot == null && command != Command.Place)
                    {
                        Console.WriteLine("Only PLACE command is allowed as first command");
                        continue;
                    }

                    // Process commands through switch case statements 
                    switch (command)
                    {
                        case Command.Place:
                            #region Guards
                            if (commandWithParameter.Length < 3)
                            {
                                Console.WriteLine("Please enter full parameters for PLACE command, for ex - PLACE 0, 0, North");
                                break;
                            }

                            if (!int.TryParse(commandWithParameter[1], out int x))
                            {
                                Console.WriteLine("Please enter positive integer value for Position X");
                                break;
                            }

                            if (!int.TryParse(commandWithParameter[2], out int y))
                            {
                                Console.WriteLine("Please enter positive integer value for Position Y");
                                break;
                            }

                            Enum.TryParse(commandWithParameter[3], true, out Direction direction);
                            #endregion

                            if (toyRobot == null)
                            {
                                //Initailising board as this seems to be first call to place command.
                                toyRobot = new ToyRobot(x, y, direction);
                            }
                            else
                            {
                                toyRobot.Place(x, y, direction);
                            }
                            break;
                        case Command.Move:
                            toyRobot.Move();
                            break;
                        case Command.Left:
                            toyRobot.Left();
                            break;
                        case Command.Right:
                            toyRobot.Right();
                            break;
                        case Command.Report:
                            Console.WriteLine(toyRobot.Report());
                            break;
                        default:
                            Console.WriteLine("Please enter valid command, Allowed values are: PLACE, MOVE, LEFT, RIGHT, REPORT or EXIT");
                            break;

                    }
                    
                    // Not asked in the requirements, Just displaying output after each 
                    // command for ease of use except when report command is given.
                    if (toyRobot != null && command != Command.Report)
                    {
                        Console.WriteLine(toyRobot.Report());
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Some unknown errror has happened exiting program");
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
