Created a robot that is able to make different kind of operations on numerical arrays. 
We don't know which operations, but you want your robot to be extensible via chips. 
Plug in a chip for sorting an array and now your robot can sort, plug in another one and it can find max element.

Requirement:

Implement a type "Robot" with the following requirements
  Robot must support pluggable chips that allow him to do different operations on numeric arrays
  Only one chip can be plugged at a time and robot can't function without a chip
  Chips can be swapped at runtime, since you have only one robot instance
  
  Robot should have only two functions/methods
      A function that executes current chip's logic and returns result, it should accept an array and return whatever current chip is returning
      A function that installs a chip into a robot, it should accept a chip and should not return anything
      
  Implement two chips
      "Chip of Sorts" — sorts an array in the order and can have an option to specify ascending or descending type of sorting. (Sorting algorythm is not important, use standard one from any library you want.)
      "Total Chip" — finds a total sum of all elements of an array

Add a property to your robot that represents total number of different chips installed through robot's lifetime. It should only count unique chips being installed.
Write one simple test function that tests logic from 4, you don't have to use any Unit Testing framework, just a simple function would be fine
