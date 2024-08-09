# FanDuel Depth Chart Challenge

This is my attempt at the Fanduel NFL Depth Chart coding challenge - thanks for taking a look!

The goal of the coding challenge is to implement functionality that will allow us to manage and work with the depth charts.
For an example of what a depth chart looks like - see the following link: https://www.ourlads.com/nfldepthcharts/depthchart/TB

## How to use 

Once you have the application up and running ( see [Getting Started](#getting-started)) you can manage your depth chart by using the following commands:

### Commands

- `add <Player Position> <Player Number> <Player Name>` - Adds a player to the depth chart at the specified position
- `remove <Player Position> <Player Number> <Player Name>` - Removes a player from the depth chart at the specified position
- `getbackups <Player Position> <Player Number> <New Position>` - Returns the list of Player Backups for the specified player
- `fulldepthchart` - Displays the full depth chart

### Example Usage

```bash
add QB 1 Tom Brady
add QB 2 Drew Brees
add QB 3 Aaron Rodgers

getbackups QB 1 Tom Brady
# Output:
# #2 - DrewBrees
# #3 - AaronRodgers

remove QB 2 Drew Brees

getbackups QB 1 TomBrady
# Output:
#3 - AaronRodgers

fulldepthchart
```

## Getting Started

### Prerequisites

- NET6.0
- This repository cloned to your local machine

### Running the application

1. Open a terminal and navigate to the root of the repository
2. Run the following command to build and run the application:
```bash
cd src/FanDuel.DepthChart
dotnet run
```
3. Build up and manage your depth chart using the commands listed above.

### Running the tests

1. Open a terminal and navigate to the root of the repository
2. Run the following command to build and run the application:
```bash
cd test/FanDuel.DepthChart.Tests
dotnet test
```

