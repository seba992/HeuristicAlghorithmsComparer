use Metaheuristic

-- Insert tested alghoritms --
SET IDENTITY_INSERT dbo.Alghoritms ON
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (1,'Simulated Annealing');
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (2, 'Particle Swarm Optimization');
INSERT INTO dbo.Alghoritms (Id,Name) VALUES (3, 'Genetic Alghoritm');
SET IDENTITY_INSERT dbo.Alghoritms OFF

-- Insert test functions --
SET IDENTITY_INSERT dbo.TestFunctions ON
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (1,'Bohachevsky',1,'https://www.sfu.ca/~ssurjano/boha.html'		,100,2) -- 81.75%
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (2,'Colville'	,3,'https://www.sfu.ca/~ssurjano/colville.html'	,10	,4); -- 72%
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (3,'Rosenbrock'	,4,'https://www.sfu.ca/~ssurjano/rosen.html'	,10	,4); -- 44.17% dla 2(tu 4) (zakres -5,10)
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (4,'Eggholder'	,6,'https://www.sfu.ca/~ssurjano/egg.html'		,600,2); -- 18.92%
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (5,'Griewank'	,7,'https://www.sfu.ca/~ssurjano/griewank.html'	,600,3); -- 6.08%
INSERT INTO dbo.TestFunctions (Id, Name, DifficultyLevel, FunctionGraphLink, BoundRange, Dimension) VALUES (6,'Ackley'		,8,'https://www.sfu.ca/~ssurjano/ackley.html'	,32,3); -- 48.25% dla 2(tu 3)
SET IDENTITY_INSERT dbo.TestFunctions OFF 