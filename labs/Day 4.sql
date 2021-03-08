create table Employee(ID int primary key nonclustered , EmpName varchar(30) Not NUll, age int check(age>20 and age<50), contact_no varchar(11) Not null unique)

insert into Employee values(1, 'Adam', 123, '867864332')
insert into Employee values(4, 'James', -53, '987434334')
insert into Employee values(2, 'Kim', 35, '9878334')
insert into Employee values(3, 'Tim', 43, Null)


select *from Employee
--Not NUll
drop table Employee

--unique key + Not Null = Primary Key default clustered index

--Candidate Key unique and not null

--Composite Key 

create table Couresetable(ID int, coursename varchar(20) Not Null unique, consultantname varchar(20), primary key(coursename, consultantname))

drop table Dept
insert into Couresetable values(1, 'SQL', 'Adam'),
                               (2, 'C#', 'Tim'),
							   (3, 'SQL', 'Tim')

--check constraint
alter table Employee
add constraint check_age check(age between 20 and 50)

--Foregin key 
create table Dept(ID int identity(1,1) primary key, DeptName varchar(10) Not Null unique)

insert into Dept values('Accounts'),
                       ('HR'),
					   ('IT')

create table Emp(ID int identity(1,1) primary key, EmpName varchar(10), DeptID int foreign key references Dept(ID) on delete cascade) -- on delete set null 
insert into Emp values('Adam', Null),
                      ('Tim', 2)					  

select * from Dept
select * from Emp

delete Dept
where ID =1

--Exception Handling

begin try
insert into Couresetable values(1, 'SQL', 'Adam')
end try
begin catch
 select ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_LINE()
end catch

select * from Couresetable