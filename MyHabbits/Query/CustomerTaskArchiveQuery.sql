USE [aspnet-MyHabbits-20170925025517]
GO

--SELECT [Id]
--      ,[Title]
--      ,[time_completed]
--      ,[time_goal]
--      ,[is_done]
--      ,[completed_date]
--      ,[customer_Id]
--      ,[ApplicationUserId]
--  FROM [dbo].[CustomerTasks]
--GO

--	TEST QUERIES

--QUERY TO SELECT DATA FROM CustomerTasks 
--SELECT t.Id AS task_id, t.completed_date, t.time_completed, t.time_goal, t.is_done, t.ApplicationUserId, t.customer_Id
--FROM CustomerTasks t
--WHERE t.is_done = 1






--PRODUCTION QUERIES
--Copies completed CustomerTasks to CustomerTaskHistories
INSERT INTO CustomerTaskHistories (task_id, Title, completed_date, time_completed, time_goal, is_done, ApplicationUserId, Customer_Id)
SELECT t.Id AS task_id, t.Title, t.completed_date, t.time_completed, t.time_goal, t.is_done, t.ApplicationUserId, t.customer_Id
FROM CustomerTasks t
WHERE t.is_done = 1


--Resets each task
UPDATE CustomerTasks
SET time_completed='00:00:00.0000000',
	is_done=0,
	completed_date=NULL

SELECT * FROM CustomerTasks
