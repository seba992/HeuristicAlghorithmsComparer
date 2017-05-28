function [ x1,x2,fval,outIterations,outFunccount] = SimulatedAnnealingTestFun( maxTime, maxIterations, maxFunctionEvaluations, maxStallIterations, funName )
ObjectiveFunction = str2func(funName);
startingPoint = randi([-20,20],1,2); %[79 79];
lb = [-20 -20];
ub = [20 20];

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
outIterations = output.iterations;
outFunccount = output.funccount;
end

