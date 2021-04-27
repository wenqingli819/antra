# Session Cookies Vs. JWT for Authentication

we want our states to be remembered during the entire shopping operation. so when we go to another product page, we would not lose the data we have in the shopping cart page.

Since HTTP is a stateless protocol, to overcome this, we can use either session or tokens.

| Session-Based Authentication                                 | JWT                                                          |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| ![img](https://hackernoon.com/images/pazJZnCJTqSZxQS4tltZo4Gatbo1-fy453y0e.jpg) | ![img](https://hackernoon.com/images/pazJZnCJTqSZxQS4tltZo4Gatbo1-fo8h3yl1.jpg) |
| session uses the server memory to store user data, and this might be an issue when a large number of users are accessing the application at once. |                                                              |
| https://www.learmoreseekmore.com/2020/05/dotnet-core-session.html |                                                              |

