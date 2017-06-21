function [x1,x2,fval,outGenerations,outFunccount,outTotaltime] = GeneticAlghoritmTestFun( maxTime, maxGenerations, Nvariables, populationSize, maxStallGenerations, funName, lowerBoundX, LowerBoundY, UpperBoundX, UpperBoundY )
ObjectiveFunction = str2func(funName);

lb = [lowerBoundX LowerBoundY];
ub = [UpperBoundX UpperBoundY];

options = optimoptions(@ga, ...
    'MaxTime', maxTime, ...
    'MaxGenerations', maxGenerations, ...
    'PopulationSize', populationSize, ...
    'MaxStallGenerations', maxStallGenerations);
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) %
tic              
[x,fval,exitflag,output] = ga(ObjectiveFunction,Nvariables,[],[],[],[],lb,ub,[],options);
elapsedTime = toc;
x1 = x(1);
x2 = x(2);
outGenerations  = output.generations;
outFunccount = output.funccount;
outTotaltime = elapsedTime;
end