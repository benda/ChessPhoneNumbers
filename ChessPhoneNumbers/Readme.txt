See PhoneNumberServiceTests for result summary

Solution Explanation:

1. Represent keypad as graph (edge list), simple notation in text file (keypad.txt). "1 E 2" means can move from 1 to 2 in East direction. (Design Goal #4)
2. Base Piece class then subtype for each chess piece (Design Goal #2)
3. With keypad graph and piece specific behavior we determine possible moves for combination of piece and position
4. Represent path as a tree, iterating through all start positions (each keypad key), 1 tree per start position
5. Prune invalid paths as we go, with all validity rules encapsulated in implementation of single interface (IPathValidator). (Design Goal #4)
5. Find all leaf nodes, then backtrack to root to determine unique path set for each start position
7. Allow user to select piece and show results in WPF UI. (Design Goal #3)
8. General OOP throughout (Design Goal #1)
9. Isolate different layers (graph library, tree library, path library, chess specific domain, utility, etc., and they all build on each other)

Other:

Everything in Utility folder is just old helper code from other projects (so it is all previously written) - not necessarily up to date with latest C# version feature
changes due to time constraints. All other code was written specifically for this project.

Performance enhancements / features if I had more time:

-parallel processing (1 thread per start position in PathFinder class), since this runs almost instantly for me though no real reason to bother (maybe for Queen)
-lazy load UI tree nodes (load only when clicked)
-don't recalculate all moves for a piece at position (dynamic programming)


Notes:

    [DebuggerDisplay] attribute doesn't handle drilling down multiple levels / generics well, so overrode ToString() in various places, normally you shouldn't use ToString() this way
	-Would normally use commands not click event handler

