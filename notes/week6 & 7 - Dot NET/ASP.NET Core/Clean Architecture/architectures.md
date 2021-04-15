## Clean Architecture

### `ApplicationCore` (Domain Model) 

minimal dependencies - none on Infrastructure

![image-20210405151637364](../../../../resources/image-20210405151637364.png)

- Domain Model

  a model of the problem space composed of Entities, Interfaces, Services, and more

  *specification pattern* (customized queries, how to query each different entity a different way), related to *repository pattern* (thin)

All projects depend on the Core project; dependencies point inward toward this core

inner projects define interfaces; outer projects implement them



avoid direct dependency on the infrastructure project (except from Integration Tests and possibly Startup.cs)



### `Infrastructure` Project

![image-20210405152035838](../../../../resources/image-20210405152035838.png)

other services:

3rd party SDK like AWS s3, Azure blob storage SDK

interface:

Azure blob object



### `web` Project

![image-20210405152438302](../../../../resources/image-20210405152438302.png)



### Shared Kernel

shared by multiple different applications

ideally distributed as Nuget Packages

![image-20210405152722260](../../../../resources/image-20210405152722260.png)



![image-20210405153004915](../../../../resources/image-20210405153004915.png)



![image-20210405153049305](../../../../resources/image-20210405153049305.png)



## Onion architecture

![image-20210405145928699](../../../../resources/image-20210405145928699.png)



## hexagonal architecture

![image-20210405150037442](../../../../resources/image-20210405150037442.png)