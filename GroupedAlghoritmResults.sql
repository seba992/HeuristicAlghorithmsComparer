select tf.Name, a.Name, i.MaxTime, avg(rd.BestFunctionValue) as avgBestFunctionValue, avg(rd.iterations) as iterations, avg(rd.functionevaluations) as functionEvaluations, avg(rd.totaltime) as totaltime, ISNULL(i.SwarmSize,i.PopulationSize) as SwarmPopulationSize 
from dbo.results as r
join ResultDetails as rd on rd.id = r.ResultDetailsId
join InputParameters as i on i.id = r.InputParametersId
join Alghoritms as a on a.id = r.AlghoritmId
join TestFunctions as tf on tf.id = r.TestFunctionId
where i.MaxTime <> 11 and tf.name = 'Ackley'
group by tf.name, a.name, i.MaxTime, ISNULL(i.SwarmSize,i.PopulationSize)
order by tf.name, i.MaxTime

 -- do testow czasowych i rozne wielkosci populacji
select tf.Name, a.Name,i.maxtime, ISNULL(i.SwarmSize,i.PopulationSize), avg(rd.bestfunctionvalue),avg(rd.functionevaluations)
from dbo.results as r
join ResultDetails as rd on rd.id = r.ResultDetailsId
join InputParameters as i on i.id = r.InputParametersId
join Alghoritms as a on a.id = r.AlghoritmId
join TestFunctions as tf on tf.id = r.TestFunctionId
where i.MaxTime <> 11 and tf.name = 'Colville'-- and ISNULL(i.SwarmSize,i.PopulationSize) IS not NULL
group by tf.name, a.name, i.MaxTime, ISNULL(i.SwarmSize,i.PopulationSize)
order by tf.name, ISNULL(i.SwarmSize,i.PopulationSize)

/*
select tf.Name, a.Name,avg(rd.functionevaluations) as odwolandoFun, ISNULL(i.SwarmSize,i.PopulationSize)  as popul, avg(rd.bestfunctionvalue) as bestValue ,avg(rd.totaltime) as totaltime
,avg(rd.iterations) as iterations
from dbo.results as r
join ResultDetails as rd on rd.id = r.ResultDetailsId
join InputParameters as i on i.id = r.InputParametersId
join Alghoritms as a on a.id = r.AlghoritmId
join TestFunctions as tf on tf.id = r.TestFunctionId
where i.MaxTime = 11 and tf.name = 'Bochachevsky' --and ISNULL(i.SwarmSize,i.PopulationSize) IS not NULL
group by tf.name, a.name, i.MaxIterations, ISNULL(i.SwarmSize,i.PopulationSize)
order by tf.name, ISNULL(i.SwarmSize,i.PopulationSize)*/