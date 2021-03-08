select * from tblDepartment
select * from tblEmployee

select Salary from tblEmployee
where Salary > 5000 and Salary <9000


create clustered index IX_tblEmployee_Salary on tblEmployee(ID DESC)

drop index tblEmployee.IX_tblEmployee_Salary


create table Course(ID int, CourseName varchar(20))

select * from Course

select * from tblEmployee


--Nested Join/Merge Join/Hash Join

select Name, Gender, Salary, DepartmentName from tblDepartment
 join tblEmployee
on tblDepartment.ID = tblEmployee.ID

--Merge Join
select o.ShipCity, o.ShipCountry, od.Quantity from Orders o
inner join [Order Details] od
on o.OrderID=od.OrderID


--Hash Join
select c.CompanyName, o.OrderDate from Customers c
inner join Orders o
on c.CustomerID = o.CustomerID
where c.ContactName = 'Hanari Carnes'


exec sp_helpindex Orders

select * from tblEmployee

--Case 
select Name, Gender, Salary,
Case
when Salary >7100 and Salary< 9000 then 'Director'
when Salary >2000 and Salary< 7100 then 'Senior Consultant'
else 'Consultant'
end as Designation
from tblEmployee


