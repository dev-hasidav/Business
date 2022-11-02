use [ASynchro]

-- Для настройки SQL express 2017
-- show advanced options  - 1
-- clr enabled            - 1
-- lightweight pooling    - 0
-- CLR strict security    - 0

--  расширенные опции
EXEC sp_configure 'show advanced options'; 
GO
--RECONFIGURE;
GO
-- clr опция
EXEC sp_configure 'clr enabled'; 
GO
-- включение CLR
--EXEC sp_configure 'clr enabled', 1; 
GO
--  перезагрузка опций
--RECONFIGURE;
GO
--  облегчённый пул = 0-выключить
EXEC sp_configure 'lightweight pooling'; 
GO
--  выключение облегчённого пула
--EXEC sp_configure 'lightweight pooling', 0; 
--GO
-- 
EXEC sp_configure 'CLR strict security'; 
GO





