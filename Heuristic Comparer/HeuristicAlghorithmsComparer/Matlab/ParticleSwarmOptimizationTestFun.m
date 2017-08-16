function [resultPointLoc,fval,outIterations,outFunccount,outTotaltime] = ParticleSwarmOptimizationTestFun( maxTime, maxIterations, swarmSize, maxStallIterations, funName, boundRange, dimension)
ObjectiveFunction = str2func(funName);

lb(1,1:dimension) = -boundRange; % = [boundRange boundRange];
ub(1,1:dimension) = boundRange; % = [boundRange boundRange];

options = optimoptions(@particleswarm, ...
    'MaxTime', maxTime, ...
    'MaxIterations', maxIterations, ...
    'SwarmSize', swarmSize, ...
    'MaxStallIterations', maxStallIterations)
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) %
tic              
[x,fval,exitflag,output] = particleswarm(ObjectiveFunction,dimension,lb,ub,options)
elapsedTime = toc;
resultPointLoc = x;

outIterations  = output.iterations;
outFunccount = output.funccount;
outTotaltime = elapsedTime;
end