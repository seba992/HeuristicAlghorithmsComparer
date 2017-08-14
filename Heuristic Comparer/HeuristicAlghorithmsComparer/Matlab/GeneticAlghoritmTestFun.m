function [resultPointLoc,fval,outGenerations,outFunccount,outTotaltime] = GeneticAlghoritmTestFun( maxTime, maxGenerations, populationSize, maxStallGenerations, funName, boundRange, dimension)
ObjectiveFunction = str2func(funName);

lb(1,1:dimension) = -boundRange; % = [boundRange boundRange];
ub(1,1:dimension) = boundRange; % = [boundRange boundRange];

options = optimoptions(@ga, ...
    'MaxTime', maxTime, ...
    'MaxGenerations', maxGenerations, ...
    'PopulationSize', populationSize, ...
    'MaxStallGenerations', maxStallGenerations)
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) %
tic              
[x,fval,exitflag,output] = ga(ObjectiveFunction,dimension,[],[],[],[],lb,ub,[],options);
elapsedTime = toc;
resultPointLoc = x;

outGenerations  = output.generations;
outFunccount = output.funccount;
outTotaltime = elapsedTime;
end