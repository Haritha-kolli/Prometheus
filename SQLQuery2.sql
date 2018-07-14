use [16MayCHN]




--Creation of Student Table
	create table haritha.student(StudentID integer IDENTITY(1500,1)  not null Primary Key,
	FName varchar(30),LName varchar(30),DOB date,City varchar(40),Pasword varchar(20),
	MobileNo varchar(10));

--Inserting Student Records

CREATE PROCEDURE [haritha].[SPX_Insert_150913_Student]
	
	@FName varchar(30),
	@LNAme varchar(30),
	@DOB date,
	@City varchar(40),
	@Password varchar(20),
	@MobileNo varchar(10)
	
AS

	insert into haritha.Student(FName,LName,DOB,City,Pasword,MobileNo) 
	values(@FName,@LNAme,@DOB,@City,@Password,@MobileNo)

RETURN 0;

select *from haritha.teacher;

--Student Data
	insert into haritha.student(FName,LName,DOB,City,Pasword,MobileNo)
	values('Haritha','Kolli','11/15/1996','Vizag','Haritha123','9090881234');

	insert into haritha.student(FName,LName,DOB,City,Pasword,MobileNo)
	values('Kritya','Sharma','01/01/1988','Delhi','Kritya123','9911234563');

	insert into haritha.student(FName,LName,DOB,City,Pasword,MobileNo)
	values('Rohan','Jiyaar','10/15/1990','Pune','Rohan123','9090810009');

	insert into haritha.student(FName,LName,DOB,City,Pasword,MobileNo)
	values('Arjun','Shetty','09/25/1989','Vizag','Arjun123','9888881234');

--View Student Data
	select * from haritha.student;
--View Student My Profile

CREATE PROCEDURE [haritha].[SPX_Student_150913_MyProfile]

@studentID int

AS
	select * from haritha.student where StudentID=@studentID

RETURN 0;

select *from haritha.Student
--LOGIN CREDENTIALS

--Student Login Check

CREATE PROCEDURE [haritha].[SPX_Student_150913_LoginCheck]

@studentID int,
@password varchar(20)

AS
	
	select * from haritha.student where StudentID=@studentID AND ( Pasword like @password )

RETURN 0;

select *from haritha.teacher
--Teacher Login Check

CREATE PROCEDURE [haritha].[SPX_Teacher_150913_LoginCheck]

@teacherID int,
@password varchar(20)

AS
	
	select * from haritha.Teacher where TeacherID=@teacherID AND Pasword=@password 

RETURN 0;

--Admin Check

CREATE PROCEDURE [haritha].[SPX_Admin_150913_Check]

@teacherID int

AS
	
	select * from haritha.Teacher where TeacherID=@teacherID AND IsAdmin='yes' 

RETURN 0;

--Granting Admin Rights
CREATE PROCEDURE [haritha].[SPX_Grant_150913_AdminRight]

@teacherID int

AS
	
	update haritha.Teacher set IsAdmin='yes' WHERE TeacherID=@teacherID

RETURN 0;

drop procedure [haritha].[SPX_Revoke_150913_AdminRight]
--Revoke Admin Rights
CREATE PROCEDURE [haritha].[SPX_Revoke_150913_AdminRight]

@teacherID int

AS
	
	update haritha.Teacher set IsAdmin='no' WHERE TeacherID=@teacherID

RETURN 0;
--Creation of Course Table
	create table haritha.Course(CourseID integer IDENTITY(1,1) Primary Key,
	CourseName varchar(50),StartDate date,EndDate date);

--Course Data
	insert into haritha.Course(CourseName,StartDate,EndDate) 
	values('Mechanics','06/30/2018','07/30/2018')

	insert into haritha.Course(CourseName,StartDate,EndDate) 
	values('.NetFramework','05/30/2018','07/15/2018')

	insert into haritha.Course(CourseName,StartDate,EndDate) 
	values('Android','05/30/2018','06/29/2018')

	insert into haritha.Course(CourseName,StartDate,EndDate) 
	values('C','07/01/2018','08/01/2018')

	insert into haritha.Course(CourseName,StartDate,EndDate) 
	values('BigData','07/02/2018','08/01/2018')

--View Course Data
	select *from haritha.Course;

	select *from HARITHA.student

	select *from haritha.Enrollment;

	insert into HARITHA.Enrollment values(1,1500);
	insert into HARITHA.Enrollment values(2,1500);
	insert into HARITHA.Enrollment values(3,1500);
	insert into HARITHA.Enrollment values(1,1505);

--creating Teaches Table
	create table haritha.Teaches(TeacherID integer,CourseID integer,
	foreign key(TeacherID) references haritha.Teacher(TeacherID),
	foreign key(CourseID) references haritha.Course(CourseID));

--Teaches Data
	insert into haritha.Teaches(TeacherID,CourseID) values(1202,1);
	insert into haritha.Teaches(TeacherID,CourseID) values(1202,2);
	insert into haritha.Teaches(TeacherID,CourseID) values(1203,3);


--Creating Enrollment Table
	create table haritha.Enrollment(CourseID integer,StudentID integer,
	foreign key(CourseID) references haritha.Course(CourseID),
	foreign key(StudentID) references haritha.Student(StudentID));

--Inserting Enrollment Records
	insert into haritha.Enrollment(CourseID,StudentID) values(1,1500);
	insert into haritha.Enrollment(CourseID,StudentID) values(2,1500);
	insert into haritha.Enrollment(CourseID,StudentID) values(3,1500);
	insert into haritha.Enrollment(CourseID,StudentID) values(1,1501);
	insert into haritha.Enrollment(CourseID,StudentID) values(1,1504);
	insert into haritha.Enrollment(CourseID,StudentID) values(3,1503);

--Enrollment Data
	select * from haritha.Enrollment;
	

--creation of Homework Table
	create table haritha.Homework(HomeworkID integer IDENTITY(1,1) Primary key,Description varchar(200),DeadLine date,
	ReqTime integer,LongDescription varchar(500));

--Inserting Homework Data
	insert into haritha.Homework(Description,DeadLine,ReqTime,LongDescription)
	values('Design Layouts','06/05/2018',5,'Apply Styles')

	insert into haritha.Homework(Description,DeadLine,ReqTime,LongDescription)
	values('Design LoginForm','02/05/2018',2,'Apply Styles and Validations')

	insert into haritha.Homework(Description,DeadLine,ReqTime,LongDescription)
	values('Design Application','02/16/2018',4,'Use Layered Architech')
--Homework Data
	select *from haritha.Homework;


--Creation of Assignment Table
	create table haritha.Assignment(HomeworkID integer,TeacherID integer,CourseID integer,
	foreign key(HomeworkID) references haritha.Homework(HomeworkID),
	foreign key(TeacherID) references haritha.Teacher(TeacherID),
	foreign Key(CourseID) references haritha.Course(CourseID));

--Inserting Assignment Data
	insert into haritha.Assignment(HomeworkID,TeacherID,CourseID)
	values(1,1202,3);

	insert into haritha.Assignment(HomeworkID,TeacherID,CourseID)
	values(2,1202,2);

	insert into haritha.Assignment(HomeworkID,TeacherID,CourseID)
	values(1,1203,3);

	insert into haritha.Assignment(HomeworkID,TeacherID,CourseID)
	values(7,1203,3);

	select * from haritha.Assignment


--Teacher Table Creation

	create table haritha.Teacher(TeacherID integer IDENTITY(1200,1) not null Primary Key,
	FName varchar(30),LName varchar(30),DOB date,City varchar(40),
	Pasword varchar(20),MobileNo varchar(10),IsAdmin varchar(10));

--Inserting Sample Values 
	insert into haritha.Teacher(FName,LName,DOB,City,Pasword,MobileNo,IsAdmin) 
	values('Harika','Kolli','11/30/1996','Hyderabad','Haarika','9087654312','yes');

	insert into haritha.Teacher(FName,LName,DOB,City,Pasword,MobileNo,IsAdmin) 
	values('Karthik','Varma','07/04/1989','Hyderabad','Karthik123','9900011234','no');

--Teacher Data
	select *from haritha.teacher;
--
--
--
-- Procedure Add new Teacher Record 

CREATE PROCEDURE [haritha].[SPX_Insert_150913_Teacher]
	
	@FName varchar(30),
	@LNAme varchar(30),
	@DOB date,
	@City varchar(40),
	@Password varchar(20),
	@MobileNo varchar(10),
	@IsAdmin varchar(10)
AS
	insert into haritha.Teacher(FName,LName,DOB,City,Pasword,MobileNo,IsAdmin) 
	values(@FName,@LNAme,@DOB,@City,@Password,@MobileNo,@IsAdmin)
RETURN 0
--
--
--
--
--view all the teacher details
CREATE PROCEDURE [haritha].[SPX_View_150913_AllTeachers]

AS

	select * from haritha.Teacher

RETURN 0
--Viewing the Available Courses

CREATE PROCEDURE [haritha].[SPX_View_150913_AvailableCourses]

AS

	select * from haritha.Course where EndDate > CAST(CURRENT_TIMESTAMP AS DATE)

RETURN 0




--Taking a course

CREATE PROCEDURE [haritha].[SPX_Teaches_150913_Course]

@CID int,
@TID int

AS

	Insert into haritha.Teaches(TeacherID,CourseID) values(@TID,@CID)

return 0;

DROP PROCEDURE [haritha].[SPX_Teaches_150913_Course];
--Viewing the List of the Courses he is teaching
CREATE PROCEDURE [haritha].[SPX_Teacher_150913_MyCourses]

@teacherID int

AS

	select * from haritha.Course c inner join HARITHA.teaches t 
	on c.CourseID=t.CourseID where t.TeacherID=@teacherID

return 0;


--Viewing Student Details in a specific course

CREATE PROCEDURE [haritha].[SPX_View_150913_MyCourseStudents]

@CourseID int

AS

	select s.StudentID,s.FName,s.LName,s.City,s.MobileNo 
	from haritha.student s
	inner join haritha.Enrollment e 
	on s.StudentID=e.StudentID where e.CourseID=@CourseID

return 0;



--Creating Homework for a Course
CREATE PROCEDURE [haritha].[SPX_Create_150913_Homework]

@HDescrip varchar(200),
@HDeadLine date,
@HTimeRequired int,
@HLongDescrip varchar(500)

AS

	insert into haritha.Homework(Description,DeadLine,ReqTime,LongDescription)
	values(@HDescrip,@HDeadLine,@HTimeRequired,@HLongDescrip)

return 0;

DROP PROCEDURE [haritha].[SPX_Create_150913_Homework]
--Updating the Assignment Table

CREATE PROCEDURE [haritha].[SPX_Updating_150913_Assignment]

@HhomeworkID int,
@HteacherID int,
@HcourseID int
 
AS
	insert into haritha.Assignment(HomeworkID,TeacherID,CourseID)
	VALUES(@HhomeworkID,@HteacherID,@HcourseID)
RETURN 0

drop procedure [haritha].[SPX_Updating_150913_Assignment]

CREATE PROCEDURE [haritha].[SPX_Get_M3_150913_homeworkID]

AS
	select max(HomeworkID) FROM haritha.Homework
	
RETURN 0

select *from haritha.Homework
select max(HomeworkID) from haritha.Homework
--Viewing Homeworks 
--(Teacher->View Courses->coursID->onSelectCourse()->btn_View_Homework()->Display())

CREATE PROCEDURE [haritha].[SPX_View_150913_CourseAssignment]

@teacherID int,
@courseID int

AS
	
		select h.HomeworkID,h.Description,h.DeadLine,h.ReqTime,h.LongDescription from haritha.Homework h inner join haritha.Assignment a
		on h.HomeworkID=a.HomeworkID where a.CourseID=@courseID and a.TeacherID=@teacherID

RETURN 0;

drop procedure [haritha].[SPX_View_150913_CourseAssignment]



--Student Functions:

--Viewing the List of the Courses student is taking
CREATE PROCEDURE [haritha].[SPX_Student_150913_MyCourses]

@studentID int

AS

	select * from haritha.Course c inner join HARITHA.Enrollment e 
	on c.CourseID=e.CourseID where e.StudentID=@studentID

return 0;

drop procedure [haritha].[SPX_Student_150913_MyCourses]

--Viewing Course Details
CREATE PROCEDURE [haritha].[SPX_Student_150913_CourseDetails]

@courseID int

AS

	select * from haritha.Course c
	where c.CourseID=@courseID

return 0;


--View My(student) Assignments in my course;
CREATE PROCEDURE [haritha].[SPX_Student_150913_CourseAssignment]

@courseID int

AS
	
		select distinct h.HomeworkID,h.Description,h.DeadLine,h.ReqTime,h.LongDescription from haritha.Homework h inner join haritha.Assignment a 
		on h.HomeworkID=a.HomeworkID where a.CourseID=@courseID

RETURN 0;

drop procedure [haritha].[SPX_Student_150913_CourseAssignment]

--View My(student) Assignments in my course;
CREATE PROCEDURE [haritha].[SPX_Teacher_150913_CourseAssignment]

@courseID int

AS
	
		select distinct h.HomeworkID,h.Description,h.DeadLine,h.ReqTime,h.LongDescription from haritha.Homework h inner join haritha.Assignment a 
		on h.HomeworkID=a.HomeworkID where a.CourseID=@courseID

RETURN 0;

--student Course Enrollment
CREATE PROCEDURE [haritha].[SPX_Enrolling_150913_Course]

@courseID int,
@studentID int

AS

	Insert into haritha.Enrollment(CourseID,StudentID) values(@courseID,@studentID)

return 0;

drop procedure [haritha].[SPX_Enrolling_150913_Course]
--Checking whether the student already enrolled for the course or not

CREATE PROCEDURE [haritha].[SPX_StudentCheck_150913_Course]
@cID int,
@sID int

AS
	select *from haritha.Enrollment where StudentID=@sID and CourseID=@cID

RETURN 0;

drop procedure [haritha].[SPX_StudentCheck_150913_Course]
--
--
--
--
--Checking whether the teacher already enrolled for the course or not

CREATE PROCEDURE [haritha].[SPX_TeacherCheck_150913_Course]
@cID int,
@tID int

AS
	select *from haritha.Teaches where TeacherID=@tID and CourseID=@cID

RETURN 0;


--
--
--
--
--View Teacher My Profile

CREATE PROCEDURE [haritha].[SPX_Teacher_150913_MyProfile]

@teachID int

AS
	select * from haritha.Teacher where TeacherID=@teachID

RETURN 0;

--Updating Teacher Details


CREATE PROCEDURE [haritha].[SPX_Update_150913_Teacher]

	@Tid int,
	@TFName varchar(30),
	@TLNAme varchar(30),
	@TDOB date,
	@TCity varchar(40),

	@TMobileNo varchar(10)

AS
	update haritha.Teacher set FName=@TFName,LName=@TLName,
	DOB=@TDOB,City=@TCity,MobileNo=@TMobileNo where TeacherID=@Tid

RETURN 0

drop procedure [haritha].[SPX_Update_150913_Teacher]

select *from haritha.Teacher
--Updating Student Details
CREATE PROCEDURE [haritha].[SPX_Update_150913_Student]

	@id int,
	@FName varchar(30),
	@LNAme varchar(30),
	@DOB date,
	@City varchar(40),
	
	@MobileNo varchar(10)

AS
	update haritha.Student set FName=@FName,LName=@LName,
	DOB=@DOB,City=@City,MobileNo=@MobileNo where StudentID=@id

RETURN 0

select *from haritha.Student