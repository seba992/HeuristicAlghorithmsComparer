% Bochachevsky function - minimum=0 at 0,0
% https://www.sfu.ca/~ssurjano/boha.html, 81.75%,  min=[0,0]
function res = BochachevskyFun(x)
% fprintf('Bochachevsky function 81.75%% min=[0,0]')

x1 = x(1);
x2 = x(2);

term1 = x1^2;
term2 = 2*x2^2;
term3 = -0.3 * cos(3*pi*x1);
term4 = -0.4 * cos(4*pi*x2);

res = term1 + term2 + term3 + term4 + 0.7;
end