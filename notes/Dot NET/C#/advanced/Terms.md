### NuGet

- it is a <u>**package manager**</u> for .NET
- **package manager** = platform + tool to create, publish, and consume packages
- **package** = complied library + descriptive metadata



### Yield

Yield is a multithreaded syntactic sugar for starting a new thread when something happens

- yield return should work on iterating through some collection. We use that because it has the performance benefits.
- When the value matches our condition. the yield return will show that value, and keep to go to the next for loop, until the condition is no longer satisfied. so we can have the result immediately available for us to see.
- It's like subscribing to an event, **But to a collection of future events**. However, It's a loop that might never end.
- Every individual event ends immediately, but the yield keeps listening for new events
- it creates new delegates and threads under the hood

