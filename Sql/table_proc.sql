create table Employeeinfo
(
empno int identity,
empusername varchar(150),
empemail varchar(150),
empdob datetime,
empphono varchar(15)
)

create proc EmployeeRead
(
@empno varchar(150)
)
as
begin
if(@empno='View')
begin
select empno,empusername,empemail,FORMAT(empdob, 'yyyy-MM-dd') AS empdob,empphono,'Edit'Edit,'Delete'[Delete] from Employeeinfo
end
if(@empno <> 'View')
begin
select empno,empusername,empemail,empdob,empphono from Employeeinfo where empno=@empno
end
end

create proc EmployeeDelete
(
@empno int
)
as
begin
if(@empno<>0)
begin
delete from Employeeinfo where empno=@empno
if(@@ROWCOUNT>0)
select 'Deleted Successfully' as Result return 
end
end


create proc EmployeeInsert
(
@empusername varchar(150),
@empemail varchar(150),
@empdob varchar(150),
@empphoneno varchar(15),
@empno int
)
as
begin
if(@empno = 0)
begin
Insert into Employeeinfo (empusername,empemail,empdob,empphono) values(@empusername,@empemail,@empdob,@empphoneno)
select 'Inserted Successfully' as Result return 
end
else
begin
update Employeeinfo set empusername=@empusername,empemail=@empemail,empdob=@empdob,empphono=@empphoneno where empno=@empno
select 'Updated Successfully' as Result return 
end
end



select * from Employeeinfo
truncate table Employeeinfo
drop table Employeeinfo
drop proc EmployeeRead
drop proc EmployeeDelete
drop proc EmployeeInsert