# Async-tasks
## Description
The application runs 5 identical threads (Task), each of which increments its number from 1 to infinity with a delay of 1 second in a cycle. The result of each increment is output to the console in the format:

`"{Stream number} - {Value of the incremented number in the stream}"`

You can shut down the application by pressing any keyboard key. Threads are terminated using CancellationTokenSource.

