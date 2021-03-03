--Triggers 
--Insted of Insert/Update/delete

--Instead of Insert -- which will perform on view table

select * from tblEmployee
select * from tblDepartment

create view vwGetEmployeeDetails
as
select e.ID, e.Name, e.Gender, d.DepartmentName
from tblEmployee e
join tblDepartment d
on e.DepartmentId =d.ID

select * from vwGetEmployeeDetails

--Instead of INsert
create trigger trg_vwEnployeeDetails_InsteadOfInsert
on vwGetEmployeeDetails
Instead of insert
as
begin

declare @DeptID int

select @DeptID = tblDepartment.ID
from tblDepartment
join inserted 
on inserted.DepartmentName =tblDepartment.DepartmentName

if(@DeptID is null)
begin
Raiserror('Invalid Department Name', 16, 1)
return
end

insert into tblEmployee(ID, Name, Gender, DepartmentId)
select ID, Name, Gender, @DeptID from inserted
end

insert into vwGetEmployeeDetails values(11, 'Samantha', 'Female', 'IT')

--Instead of Update
Create Trigger tr_vWEmployeeDetails_InsteadOfUpdate
on vwGetEmployeeDetails
instead of update
as
Begin
 -- if EmployeeId is updated
 if(Update(ID))
 Begin
  Raiserror('Id cannot be changed', 16, 1)
  Return
 End
 
 -- If DeptName is updated
 if(Update(DepartmentName)) 
 Begin
  Declare @DeptId int

  Select @DeptId = tblDepartment.ID
  from tblDepartment
  join inserted
  on inserted.DepartmentName = tblDepartment.DepartmentName
  
  if(@DeptId is NULL )
  Begin
   Raiserror('Invalid Department Name', 16, 1)
   Return
  End
  
  Update tblEmployee set DepartmentId = @DeptId
  from inserted
  join tblEmployee
  on tblEmployee.Id = inserted.id
 End
 
 -- If gender is updated
 if(Update(Gender))
 Begin
  Update tblEmployee set Gender = inserted.Gender
  from inserted
  join tblEmployee
  on tblEmployee.Id = inserted.id
 End
 
 -- If Name is updated
 if(Update(Name))
 Begin
  Update tblEmployee set Name = inserted.Name
  from inserted
  join tblEmployee
  on tblEmployee.Id = inserted.id
 End
End

----
Update vwGetEmployeeDetails
set DepartmentName = 'Payroll'
where Id = 1

select * from vwGetEmployeeDetails

--Instead of Delete
Create Trigger tr_vWEmployeeDetails_InsteadOfDelete
on vwGetEmployeeDetails
instead of delete
as
Begin
 Delete tblEmployee 
 from tblEmployee
 join deleted
 on tblEmployee.Id = deleted.Id
 
 --Subquery
 --Delete from tblEmployee 
 --where Id in (Select Id from deleted)
End

Delete from vwGetEmployeeDetails where Id = 1