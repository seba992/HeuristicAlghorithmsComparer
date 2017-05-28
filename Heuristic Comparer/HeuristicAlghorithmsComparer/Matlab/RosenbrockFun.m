% Rosenbrock function
% https://www.sfu.ca/~ssurjano/rosen.htmlm 44.17%, min=[1,1]
function res = fun3(x)
% fprintf('Rosenbrock function 44.17%%, min=[1,1]')
x1 = x(1);
x2 = x(2);

res = 100*(x2-x1^2)^2 + (1-x1)^2;
end