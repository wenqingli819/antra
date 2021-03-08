use Company


create view vwEmployeeByDepartment
as
select e.ID, e.Name, e.Gender, e.Salary, d.DepartmentName from tblEmployee e
inner join tblDepartment d
on e.DepartmentID = d.ID

select * from vwEmployeeByDepartment



alter view vwEmployeeByDepartment
as
select e.ID, e.Name, e.Gender, e.Salary, d.DepartmentName from tblEmployee e
inner join tblDepartment d
on e.DepartmentID = d.ID

Go

select * from vwEmployeeByDepartment

---Manger want IT depatarment Employees
alter view vwEmployeeITDEpartment
as
select e.Name, e.Gender, d.DepartmentName from tblEmployee e --column security
join tblDepartment d
on e.DepartmentId = d.ID
where d.DepartmentName = 'IT' 


select * from vwEmployeeITDEpartment

--Employees in each department

create view vwSummarizedData
as
select d.DepartmentName, COUNT(e.ID) as TotalEmployee from tblEmployee e
inner join tblDepartment d
on e.DepartmentId =d.ID
group by d.DepartmentName

select * from vwSummarizedData


---Single Table
update vwEmployeeByDepartment
set Name = 'Tommy' where ID = 1

select * from tblEmployee
select * from tblDepartment

--Multiple Table --trigger insead of insert/update/delete
update vwEmployeeByDepartment
set DepartmentName= 'IT' where Name ='Sara'

select * from vwEmployeeByDepartment

use Northwind


alter view vwOrderDetails
with encryption 
as
select e.FirstName, p.ProductName, p.UnitPrice, o.ShipAddress, o.ShipCity
from Orders o
inner join Customers c
on o.CustomerID = c.CustomerID
inner join Employees e
on o.EmployeeID = e.EmployeeID
inner join [Order Details] od
on o.OrderID = od.OrderID
inner join Products p
on od.ProductID = p.ProductID

select * from vwOrderDetails
order by UnitPrice 

sp_helptext vwOrderDetails

--Stored Procedure
use Company
create proc spEmployeeDetails
as
begin
   select Name, Gender, Salary from tblEmployee
end

exec spEmployeeDetails

-- Example on Stored Procedure with input parameter

--Employee by Gender and department
drop proc spGetEmployeeGenderwithDepartment
create proc spGetEmployeeGenderwithDepartment (@Gender varchar(30),@DeptID int)
as
begin
 select * from tblEmployee where Gender =@Gender and DepartmentId = @DeptID

 end

 exec spGetEmployeeGenderwithDepartment 'Female', 3

 -- Stored Procedure with Output paramter
 -- Employee Count by Gender

 create proc spGetEmployeeCountbyGender
 @Gender varchar(20),
 @EmployeeCount int output
 with encryption
 as
 begin
 select @EmployeeCount = COUNT(ID) from tblEmployee where Gender = @Gender
 end


declare @EmployeeTotal int
 exec spGetEmployeeCountbyGender 'Male', @EmployeeTotal out
if(@EmployeeTotal is null)
print '@EmplyeeTotal is null'
else
print '@EmployeeTotal is not null'
print @EmployeeTotal

sp_helptext spGetEmployeeCountbyGender


drop proc spGetEmployeeCountbyGender


---Insert in Department using Store Procedure

create proc spInsertDept
@ID int,
@DeptName varchar(20),
@Loc varchar(20),
@DeptHead varchar(20)
as
begin
 insert into tblDepartment values(@ID, @DeptName, @Loc, @DeptHead)
 end
 select * from tblDepartment

 exec spInsertDept 5, 'manufacuture', 'Washington', 'Adam'


 select LOWER(Name) from tblEmployee
  select * from tblEmployee

 select * from Employee

 alter table Employee
 add Comm int

 create function getTotalSalary(@Salary int, @comm int)
 returns int
 begin
 if @comm is null
 return @Salary
 else
 return @salary + @comm
 return 0
 end

 update Employee
 set Comm =1000 where id in (1,3,5,7,9)

 select Name, Gender, Salary, Comm, dbo.getTotalSalary(Salary,Comm) as 'Total Salary' from Employee

 DROP TABLE Employee
 select ID, Name, Gender, Salary into Employee from tblEmployee

 sp_depends vwEmployeeByDepartment
