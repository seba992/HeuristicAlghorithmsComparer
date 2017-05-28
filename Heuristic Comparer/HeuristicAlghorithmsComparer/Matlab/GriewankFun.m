% Griewank function
% https://www.sfu.ca/~ssurjano/griewank.html, 6.08%, min=[0,0]
function res = fun6(x)
% fprintf('Griewank function 6.08%%, min=[0,0]')
x1 = x(1);
x2 = x(2);

res = 1 + (1/4000*x1^2) + (1/4000*x2^2) - (cos(x1)*cos(1/2*x2*sqrt(2)));
end