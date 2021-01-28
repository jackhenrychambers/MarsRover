# Mars Rover

Mars Rover is a .NET Core 3.1 project for dealing with the navigation of multiple rovers on a curiously rectangle plateau of Mars.
This project uses a unit testing approach to run and makes use of the NUnit 3.12.0 testing framework

## Installation

Prerequisites: 
Microsoft Visual Studio 2019
.NET Core SDK
.NET Core Runtime

Download this repository and open the MarsRover.sln file in Visual Studio.

## Usage

Run unit tests from Test Explorer in Visual Studio.

Test: MarsRover_ExpectedOutput 
Produces expected output from test data:
```
Test Input: 
5 5 
1 2 N 
LMLMLMLMM 
3 3 E 
MMRMMRMRRM 

Expected Output: 
1 3 N 
5 1 E 
```
## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests where appropriate.

## Author

Jack Henry Chambers
