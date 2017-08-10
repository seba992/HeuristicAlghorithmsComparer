% Eggholder function
% https://www.sfu.ca/~ssurjano/egg.html, 18.92%, min=-959.6407 at [512,404.2319]
function res = EggholderFun(x)
% fprintf('Eggholder function 18.92%%, min=[512,404.2319]')
x1 = x(1);
x2 = x(2);

term1 = -(x2+47) * sin(sqrt(abs(x2+x1/2+47)));
term2 = -x1 * sin(sqrt(abs(x1-(x2+47))));

res = term1 + term2;
end