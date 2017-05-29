% Easom function
% https://www.sfu.ca/~ssurjano/easom.html, 26.08%, min=[pi,pi]
function res = EasomFun(x)
% fprintf('Easom function 26.08%%, min=[pi,pi]')
x1 = x(1);
x2 = x(2);

fact1 = -cos(x1)*cos(x2);
fact2 = exp(-(x1-pi)^2-(x2-pi)^2);

res = fact1*fact2;
end