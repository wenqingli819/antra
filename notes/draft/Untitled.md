1) Get each employee name and department 

select first_name, last_name, d.name 

from employees e

join departments d

on e.department_id = d.id;

2) Department Name and number of employees belong to that department.

select d.name, count(e.id)

from departments

join employees e

on e.department_id = d.id

group by d.name;

![image-20210227212532206](../../resources/images/image-20210227212532206.png)



--------------

![image-20210301121211191](../../resources/image-20210301121211191.png)

### view 

view is for user

==only select==

security

- row level security

- column level security

can only perform select statement

create view viewName

as 

select ...

![image-20210301111551166](../../resources/images/image-20210301111551166.png)

to insert/update/ delete data on multiple table in a view -> will get inconsistant data 

![image-20210301112712848](../../resources/image-20210301112712848.png)

![image-20210301113543281](../../resources/image-20210301113543281.png)

![image-20210301150514722](../../resources/image-20210301150514722.png)

sp_helptext

sp_depends

drawbacks of view



##### Why to use triggers on views?

when we update table, and we have a View that joining multiple tables,

if we update, the view will be wrong.

 so resolve this, we need to use trigger  for updating operation 

![image-20210302111629002](../../resources/image-20210302111629002.png)

create a insert trigger to view

![image-20210302111832531](../../resources/image-20210302111832531.png)

![image-20210302111934252](../../resources/image-20210302111934252.png)

when insert, sql automatically trigger the trigger



![image-20210302120327297](../../resources/image-20210302120327297.png)



### Stored Procedures

use exec to run the stored producer

![image-20210301114357574](../../resources/image-20210301114357574.png)

![image-20210301115123586](../../resources/image-20210301115123586.png)

![image-20210301120039780](../../resources/image-20210301120039780.png)

![image-20210301151520957](../../resources/image-20210301151520957.png)



![image-20210302120212709](../../resources/image-20210302120212709.png)

### Function

suppose we want to add two columns together and make a new column, we need to use function

![image-20210301120749862](../../resources/image-20210301120749862.png)



![image-20210301144041467](../../resources/image-20210301144041467.png)

![image-20210301150417365](../../resources/image-20210301150417365.png)

### Trigger

two types of Triggers

- DML triggers     -- system admin
- DDL triggers     -- dev

Use trigger Qty = Qty - soldQty

<img src="../../resources/image-20210301144313381.png" alt="image-20210301144313381" style="zoom:50%;" />

![image-20210301144757355](../../resources/image-20210301144757355.png)

![image-20210301144915058](../../resources/image-20210301144915058.png)

##### Delete Trigger

![image-20210301145250457](../../resources/image-20210301145250457.png)



##### Update Trigger

![image-20210301145854370](../../resources/image-20210301145854370.png)

after / for



![image-20210301150934940](../../resources/image-20210301150934940.png)



![image-20210301151807335](../../resources/image-20210301151807335.png)



what is the difference between trigger and stored procedure?

what is the drawback of view

- to insert/update/ delete data on multiple table in a view -> will get inconsistent data 

  

------------------------------------------------------------------------------------------------------

query optimization

index

![image-20210302112551040](../../resources/image-20210302112551040.png)

![image-20210302112641111](../../resources/image-20210302112641111.png)

![image-20210302112717100](../../resources/image-20210302112717100.png)



select will be fast, insert/delete/update will be slow.

| clustered index | non-clustered index |
| --------------- | ------------------- |
| sorted          | not sorted          |
| 1 per table     | 1-N per table       |

![image-20210302113115241](../../resources/image-20210302113115241.png)

![image-20210302113323197](../../resources/image-20210302113323197.png)



Join

nested join/ merge join/ hash join

nested join  - for small table

![image-20210302113838436](../../resources/image-20210302113838436.png)

for larger tables

**merge join                               vs                hash join** (avoid)

join clustered indexes                             join non-clustered indexes

data will be sorted                                    no sort data

![image-20210302114201750](../../resources/image-20210302114201750.png)

how to read the execution plan?

right to left



if join using non-clustered index, then it is hash join.

![image-20210302114527822](../../resources/image-20210302114527822.png)

case when

![image-20210302115922419](../../resources/image-20210302115922419.png)