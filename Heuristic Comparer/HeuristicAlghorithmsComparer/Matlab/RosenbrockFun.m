% Rosenbrock function
% https://www.sfu.ca/~ssurjano/rosen.htmlm 44.17%, min=0 at [1,1,1,]
function res = RosenbrockFun(x)
% fprintf('Rosenbrock function 44.17%%, min=[1,1]')
d = length(x);
sum = 0;
for ii = 1:(d-1)
	xi = x(ii);
	xnext = x(ii+1);
	new = 100*(xnext-xi^2)^2 + (xi-1)^2;
	sum = sum + new;
end

res = sum;
end