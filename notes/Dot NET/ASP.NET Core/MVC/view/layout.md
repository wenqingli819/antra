#### How many layout page(s) should you have?

At least one. 

A recommended rule for determining layouts is to have one for each macro area of the site.

For example,one layout for the home page, and you could then realistically have internal pages that are quite different. The number of internal pages depends on how those pages can be grouped. If your application needs to have a back office for admin users to enter data and configuration, well, that likely makes for another required layout.



#### Passing Data to Layouts

When the view engine figures out that the view being rendered has a layout, the content of the layout is parsed first and then merged with the view template.

for each layout you plan to have you define an ad hoc view model base class and derive specific view model classes for actual views just from there.

all layout view model classes would inherit from a single parent class—***ViewModelBase***

| **View model**              | **Layout**         | **Description**                                |
| --------------------------- | ------------------ | ---------------------------------------------- |
| *HomeLayoutViewModel*       | *HomeLayout*       | View model for the *HomeLayout* template       |
| *InternalLayoutViewModel*   | *InternalLayout*   | View model for the *InternalLayout* template   |
| *BackofficeLayoutViewModel* | *BackofficeLayout* | View model for the *BackofficeLayout* template |



The *RenderSection* method accepts an optional Boolean argument that denotes whether the section is required. 

`RenderSection("footer", false)`