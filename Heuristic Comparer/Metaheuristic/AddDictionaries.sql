use Metaheuristic

-- Insert tested alghoritms --
SET IDENTITY_INSERT dbo.Alghoritms ON
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (1,'Simulated Annealing');
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (2, 'Particle Swarm Optimization');
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (3, 'Genetic Alghoritm');
SET IDENTITY_INSERT dbo.Alghoritms OFF

-- Insert test functions --
SET IDENTITY_INSERT dbo.TestFunctions ON
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (1,'Bochachevsky',1,'https://www.sfu.ca/~ssurjano/boha.html',100,2)
-- INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (2,'Beale',2,'https://www.sfu.ca/~ssurjano/beale.html',5,2);
 INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (3,'Colville',3,'https://www.sfu.ca/~ssurjano/colville.html',10,4);
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (4,'Rosenbrock',4,'https://www.sfu.ca/~ssurjano/rosen.html',10,4); -- -5,10
--INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (5,'Easom',5,'https://www.sfu.ca/~ssurjano/easom.html',20,2);
 INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (6,'Eggholder',6,'https://www.sfu.ca/~ssurjano/egg.html',600,2);
 INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (7,'Griewank',7,'https://www.sfu.ca/~ssurjano/griewank.html',600,3);
 INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (8,'Ackley',8,'https://www.sfu.ca/~ssurjano/ackley.html',200,3);
SET IDENTITY_INSERT dbo.TestFunctions OFF 