### concurrency scenarios:

suppose we have multicore machines

##### Writing a responsive user interface





##### Allowing requests to process simultaneously

On a server, client requests can arrive concurrently and so must be handled in parallel to maintain scalability. **ASP.NET Core or Web API, the runtime does this for you automatically.**

However, you still need to be aware of shared state (for instance, the effect of using static variables for caching).



##### Parallel programming

divide tasks(intensive calculations) into different cores/processors to get fast result



##### Speculative execution

can sometimes improve performance by **predicting something that might need to be done and then doing it ahead of time.** LINQPad uses this technique to speed up the creation of new queries. A variation is to run a number of different algorithms in parallel that all solve the same task. Whichever one finishes first “wins”—this is effective when you can’t know ahead of time which algorithm will execute fastest.