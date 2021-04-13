### When we use cache?

1. data that is less frequently changed but use often

2. user session data, like cookies

3. Data that is expensive or takes long to calculate can be put in cache

   A report of average annual sales by store location. 

   Some server side pages take a long time to render, so they are put in a cache, the whole cshtml file is cached, or refactor the code to SPA 

4. API call to web services can be cached locally to avoid a network round trip again



### What is Cache?

key-value pair

Everything has cache:

- sql database caches queries in memory
- hard drive caches data pages in a special disk cache
- OS caches disk data in RAM
- CPU caches Ram data in L2 cache and L1 cache
  - L1 cache, L2 cache
- web front end developer, cache data on the client



### Cache rules

- If you don't need to use cache, don't.
- When cache is used, design a simple mechanism for the cache to expire, or be notified when there are new values.