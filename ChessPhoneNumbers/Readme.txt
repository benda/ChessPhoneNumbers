11/30: 8 - 10 PM
12/1: 10:30 - 11:#0
12/1: 5:30 - 

Everything in Utility folder is just old helper code from other projects (so it is all previously written) - not necessarily up to date with latest C# version feature changes due to time constraints

    [DebuggerDisplay] doesn't handle drilling down multiple levels / generics well
	Enhancements : parallel processing (1 thread per start position)
	show all paths on UI as they are generated, count increments in real time
	factor out rules to common class so they can be easily changed
	read graph once per app launch
	show piece icons in dropdown
	rather than using hashset / overriding equals/hashcode on Path to store all unique paths per piece, could implement a tree structure where you have set of trees for each start position (start is root), then build this tree