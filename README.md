# PathFinder
This project is developed using Visual Studio 2019 to Find a way between 2 word from dictionary
How to run in command prompt:
BP words-english.txt Spin Spot output.txt

The projec first read dictionary from file, the try to find the path between the 2 given word and finally will write the results in another text file.
To find the path it will find all words the have just on character difference with the current word and will pick the one that has the least difference with final word.
If in one step it cannot find any candidate it will remove the last word and try to search again (always the used word have a flag set).

This is a simple solution but more complete solution should be implemented using A* or Depth Itereative Deepening Search alghorithms.
