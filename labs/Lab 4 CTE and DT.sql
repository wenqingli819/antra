use Northwind


--Get total orders placed by customers using joins
select c.CompanyName, c.City, c.Country, COUNT(o.OrderID) as 'total' from Customers c
join Orders o
on c.CustomerID = o.CustomerID
group by c.CompanyName, c.City, c.Country

--How can you join the table with a result set
--derived tble
--cte

--Derived table 

select Firstname, lastname  from (select * from Employees) dt


--Get total orders placed by customers using derived table

select c.CompanyName, c.City, c.Country, dt.total from customers c left join
(select COUNT(OrderID) as 'total', CustomerID from Orders group by CustomerID) dt
on c.CustomerID = dt.CustomerID

--Rank function/ window function

--show the details of 10th costliest product

select p.ProductID, p.ProductName, p.UnitPrice, p.SupplierID from Products p
order by p.UnitPrice DESC

select * from
(select p.ProductID, p.ProductName, p.UnitPrice, p.SupplierID, rank() over(order by UnitPrice DESC) as 'Rnk' from Products p) dt    ---dense_rank
where dt.Rnk = 10


--Get most costiest product by every supplier
select ProductID, SupplierID, UnitPrice, ProductName
from Products 


select p.ProductID, p.ProductName, p.UnitPrice, p.SupplierID, 
dense_rank() over(partition by supplierid order by UnitPrice DESC) as 'Rnk' from Products p ----Partition by

select * from
(select p.ProductID, p.ProductName, p.UnitPrice, p.SupplierID, 
dense_rank() over(partition by supplierid order by UnitPrice DESC) as 'Rnk' from Products p) dt    ---derived table
where dt.Rnk = 1

--find out the top 3 customer from every city, placed max number of orders

select * from 
(

select c.CustomerID, c.CompanyName, c.City, dt.total,
DENSE_RANK() over(partition by c.city order by dt.total desc) 'rnk'
from Customers c inner join
(select count(OrderID) as 'total', CustomerID from Orders 
group by CustomerID) dt
on c.CustomerID =dt.CustomerID

) dt2
where dt2.rnk <=3

--Homework Find top 3 products, ordered by customer from every city 


---CTE Common Table Expression
--12 most costliest product

with productsCostRanking
as
(
   select p.ProductID, p.ProductName, p.UnitPrice, p.SupplierID, dense_rank() over(order by UnitPrice DESC) as 'Rnk' from Products p
)
--select * from Employees

select * from productsCostRanking where Rnk =12

with cteCustomerOrderCount
as 
(
  select count(OrderID) as 'total', CustomerID from Orders group by CustomerID
), cteTopCutomerbyCity
as
(
  select c.CustomerID, c.CompanyName, c.City, dt.total,
DENSE_RANK() over(partition by c.city order by dt.total desc) 'rnk'
from Customers c inner join cteCustomerOrderCount dt
on c.CustomerID = dt.CustomerID
)

select * from cteTopCutomerbyCity where rnk <=3

--Recursive CTE-- which can be called function it self again and again

with cteEmpHierarchy
as
(
select EmployeeID, FirstName, ReportsTo, 1 'lvl' from Employees
where ReportsTo is null
union all
select e.EmployeeID, e.FirstName, e.ReportsTo, c.lvl+1 from Employees e 
inner join cteEmpHierarchy c
on e.ReportsTo = c.EmployeeID
)
select * from cteEmpHierarchy