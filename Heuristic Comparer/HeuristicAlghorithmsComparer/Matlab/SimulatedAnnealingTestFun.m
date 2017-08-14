function [resultPointLoc,fval,outIterations,outFunccount,outTotaltime] = SimulatedAnnealingTestFun(maxTime, maxIterations, maxFunctionEvaluations, maxStallIterations, funName, boundRange, dimension)
ObjectiveFunction = str2func(funName);

lb(1,1:dimension) = -boundRange; % = [boundRange boundRange];
ub(1,1:dimension) = boundRange; % = [boundRange boundRange];

startingPoint = randi([-boundRange,boundRange],1,dimension); %[79 79]

options = optimoptions(@simulannealbnd, ...
    'AnnealingFcn', @annealingboltz, ... % or @annealingfast
    'MaxTime', maxTime, ...
	'ReannealInterval', 35, ...
    'MaxIterations', maxIterations, ...
    'MaxFunctionEvaluations', maxFunctionEvaluations, ...
    'MaxStallIterations', maxStallIterations);%, ...
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) 
                 
[x,fval,exitflag,output] = simulannealbnd(ObjectiveFunction,startingPoint,lb,ub,options);
resultPointLoc = x;
%startLoc = startingPoint
outIterations = output.iterations;
outFunccount = output.funccount;
outTotaltime = output.totaltime;
end

