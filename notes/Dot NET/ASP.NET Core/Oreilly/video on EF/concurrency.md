https://learning.oreilly.com/videos/mastering-entity-framework/9781788398527/9781788398527-video4_1

### Concurrency handling

#### what is concurrency?

multiple users cannot make conflicting changes to the same entity. 

an entire object graph is protected by concurrency checks at the top level

#### Two types of concurrency

1. optimistic (mostly used)

   check for update conflicts as part of update queries

   a concurrency column is added to a table, and its value becomes the part of the where clause for both delete  and update queries.

   use timestamp (row version) column

   ![image-20210402193812871](../../../../../resources/image-20210402193812871.png)

2. pessimistic

   the system has to lock the data upon retrieval that only one user can start making edits at a time

   it does not scale well!!

#### configure concurrency fields



how transactions are implemented in EF Core

how to customize transaction process

repository pattern on EF API

