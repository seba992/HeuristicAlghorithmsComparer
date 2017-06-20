function [x1,x2,fval,outIterations,outFunccount,outTotaltime,stX,stY] = SimulatedAnnealingTestFun( maxTime, maxIterations, maxFunctionEvaluations, maxStallIterations, funName, lowerBoundX, LowerBoundY, UpperBoundX, UpperBoundY )
ObjectiveFunction = str2func(funName);

lb = [lowerBoundX LowerBoundY];
ub = [UpperBoundX UpperBoundY];

startingPoint = randi([lowerBoundX,UpperBoundX],1,2); %[79 79];

options = optimoptions(@simulannealbnd, ...
    'AnnealingFcn', @annealingboltz, ... % or @annealingfast
    'MaxTime', maxTime, ...
    'MaxIterations', maxIterations, ...
    'MaxFunctionEvaluations', maxFunctionEvaluations, ...
    'MaxStallIterations', maxStallIterations);
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) %
                 
[x,fval,exitflag,output] = simulannealbnd(ObjectiveFunction,startingPoint,lb,ub,options);
x1 = x(1);
x2 = x(2);
stX = startingPoint(1);
stY = startingPoint(2);
outIterations = output.iterations;
outFunccount = output.funccount;
outTotaltime = output.totaltime;
end

