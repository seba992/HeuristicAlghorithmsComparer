% Griewank function
% https://www.sfu.ca/~ssurjano/griewank.html, 6.08%, min=0 at [0,0]
function res = GriewankFun(x)
d = length(x);
sum = 0;
prod = 1;

for ii = 1:d
	xi = x(ii);
	sum = sum + xi^2/4000;
	prod = prod * cos(xi/sqrt(ii));
end

res = sum - prod + 1;
end