| **Method**     | **Description**                                              |
| -------------- | ------------------------------------------------------------ |
| *AddTransient* | The caller receives a new instance of the specified type per call |
| *AddSingleton* | The caller receives the same instance of the specified type which was created the first time. Regardless of the type, every application gets its own instance |
| *AddScoped*    | Same as *AddSingleton*, except that it is scoped to the current request |