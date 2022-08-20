# OrderedListProject

## Description
The project contains implantations in C# for a generic ordered list. 
The ordered list includes the functions: Push, Pop, Peek, and IsEmpty.
There are two implementations at this moment:

* QuickPopOrderedList:
    * Pop takes O(1)
    * Push takes O(n) 

* QuickPushOrderedList<T>	
    * Pop takes O(n)
    * Push takes O(1) 
    
    
## Tests
The project contains Console tests and Unit tests.

The tests checking:
* Correctness of pushing and popping.
* Correct complexity time.
Currently, the tests check int array with a standard sorting algorithm.

## To do
* Make the functions in the OrderedListTests project generic (accept T instead of int).
* Add more tests - 
  * Check different classes than T with different ordering algorithms for that classes.
  * Make the tests more complex than inserting all the values and popping them all.
  * Add tests for multithreading.
* Dockerize the project and add an explanation of how to run it.
