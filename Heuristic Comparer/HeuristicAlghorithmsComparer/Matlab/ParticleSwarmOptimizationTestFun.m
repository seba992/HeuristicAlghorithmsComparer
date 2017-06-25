function [x1,x2,fval,outIterations,outFunccount,outTotaltime] = ParticleSwarmTestFun( maxTime, maxIterations, Nvariables, swarmSize, maxStallIterations, funName, lowerBoundX, LowerBoundY, UpperBoundX, UpperBoundY )
ObjectiveFunction = str2func(funName);

lb = [lowerBoundX LowerBoundY];
ub = [UpperBoundX UpperBoundY];

options = optimoptions(@particleswarm, ...
    'MaxTime', maxTime, ...
    'MaxIterations', maxIterations, ...
    'SwarmSize', swarmSize, ...
    'MaxStallIterations', maxStallIterations);
                     %'PlotFcn',{@saplotbestf,@saplottemperature,@saplotf,@saplotstopping}) %
tic              
[x,fval,exitflag,output] = particleswarm(ObjectiveFunction,Nvariables,lb,ub,options);
elapsedTime = toc;
x1 = x(1);
x2 = x(2);
outIterations  = output.iterations;
outFunccount = output.funccount;
outTotaltime = elapsedTime;
end