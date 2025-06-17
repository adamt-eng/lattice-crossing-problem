# Lattice Crossing Problem

## Description
Given an n×n point lattice (intersection points of n consecutive horizontal and n consecutive vertical lines on common graph paper), where n > 2, cross out all the points by 2n − 2 straight lines without lifting your pen from the paper.
You may cross the same point more than once, but you cannot redraw any portion of the same line. (A solution for n =4, shown in the Figure, has seven lines instead of the six required by the puzzle.) 

## Initial Comment
The original problem requires covering all points of an n×n lattice (n > 2) using 2n − 2 straight lines without lifting the pen.
However, empirical testing and geometric analysis show that this constraint is too restrictive and often impossible to satisfy for arbitrary grid sizes. To ensure feasibility, we updated the constraint to 2n−1 lines.

## Dynamic Programming Solution

### Approach
The dynamic programming solution decomposes the problem recursively:
1. For the base case (grids ≤ 2 units), it follows a simple back-and-forth pattern
2. For larger grids, it:
   - Traces the outer perimeter in a clockwise spiral pattern
   - Recursively solves the inner (n-2)×(n-2) grid
   - Combines these solutions to form the complete path

### Key Features
- **Memoization**: Stores solutions for subproblems (specific grid sizes) to avoid redundant computations
- **Offset Handling**: Maintains correct coordinates when combining solutions from different recursion levels
- **Perimeter-First Strategy**: Ensures all outer points are visited before proceeding inward

### Algorithm Steps
1. Check if solution for current grid size exists in memoization table
2. For small grids (≤ 2 units), generate a simple back-and-forth path
3. For larger grids:
   - Trace right along the top row
   - Trace down the right column
   - Trace left along the bottom row
   - Trace up the left column
4. Recursively solve the inner grid (offset by 1 unit in x and y)
5. Combine and memoize the solution

### Complexity
- Time: O(n²) due to memoization and perimeter traversal
- Space: O(n²) for storing solutions to subproblems

## Greedy Spiral Solution

### Approach
The greedy spiral solution follows a fixed outward-in spiral pattern:
1. Starts at the top-left corner (0,0)
2. Alternates between four directional phases:
   - Right until hitting the eastern boundary
   - Down until hitting the southern boundary
   - Left until hitting the western boundary
   - Up until hitting the northern boundary
3. Shrinks the boundaries after completing each full spiral loop
4. Continues until all points are visited

### Key Features
- **Deterministic Path**: Follows a predictable, fixed pattern
- **Boundary Shrinking**: Reduces the effective grid size after each full loop
- **Single Pass**: Visits each point exactly once in a continuous path

### Algorithm Steps
1. Initialize boundaries (minRow, maxRow, minCol, maxCol)
2. While boundaries haven't crossed:
   - Move right along top boundary
   - Move down along right boundary
   - Move left along bottom boundary
   - Move up along left boundary
3. Adjust boundaries inward after each complete loop
4. Terminate when all points are visited

### Complexity
- Time: O(n²) as it visits each point exactly once
- Space: O(n²) due to storing each point in the path list

## Comparison
- **DP Solution**: More flexible, can adapt to different traversal patterns, but slightly more complex due to recursion and memoization
- **Greedy Solution**: Simpler implementation, more predictable path, but follows a fixed pattern
- Both solutions guarantee complete coverage of all lattice points in O(n²) time
