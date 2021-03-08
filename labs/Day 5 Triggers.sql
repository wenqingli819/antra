
select * from Product
select * from Sales


create trigger tr_Sales_after_insert
on Sales
after insert
as
begin
declare @pid int, @sqty int
select @pid=ProdId, @sqty = soldQty from inserted --specail table
update Product set Qty = Qty-@sqty where ID = @pid
end

insert into Sales values(2, 7)


--Delete triggers

create trigger tr_sales_after_delete
on Sales
after delete
as
begin
declare @pid int, @sqty int
select @pid = ProdId, @sqty =soldQty  from deleted
update Product set Qty = Qty + @sqty where ID = @pid
end

delete Sales where id =2

--Update triggers 
create trigger tr_Sales_after_update
on Sales
for Update
as
begin
declare @pid int, @sqty int, @oqty int
select @pid = ProdId, @oqty = soldQty from deleted
select @sqty=soldQty from inserted
update Product set Qty = Qty + @oqty-@sqty where ID =@pid
end

update Sales set soldQty = 15 where id = 1

--triggers instead of insert

create view vwGetEmployeeDetails
as
select e.ID, e.Name, e.Gender, d.DepartmentName from tblEmployee e
inner join tblDepartment d
on e.DepartmentId = d.ID

create trigger tr_vwGetEmployeeDetails_InsteadOfInsert
on vwGetEmployeeDetails
instead of insert--update--delete
as
begin
declare @DepId int

select @DepId = tblDepartment.ID from tblDepartment
join inserted
on inserted.DepartmentName = tblDepartment.DepartmentName

if(@DepId is null)
begin
raiserror('Invalid DepartmentName, statement terminated', 16, 1)
return
end

insert into tblEmployee(ID, Name, Gender, DepartmentId)
select ID, Name, Gender, @DepId from inserted
end

insert into vwGetEmployeeDetails values(13, 'Adam', 'Male', 'HR')

select * from vwGetEmployeeDetails

select * from tblDepartment
select * from tblEmployee

--DML triggers/ DDL triggers

drop trigger [tr_sales_after_delete]


