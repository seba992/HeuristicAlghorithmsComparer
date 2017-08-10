% Colville function
% https://www.sfu.ca/~ssurjano/colville.html, 72.00%, min=0 at [1,1,1,1], dim =4
function res = ColvilleFun(x)
% fprintf('Colville function 72.00%%, min=[1,1,1,1]')
x1 = x(1);
x2 = x(2);
x3 = x(3);
x4 = x(4);

term1 = 100 * (x1^2-x2)^2;
term2 = (x1-1)^2;
term3 = (x3-1)^2;
term4 = 90 * (x3^2-x4)^2;
term5 = 10.1 * ((x2-1)^2 + (x4-1)^2);
term6 = 19.8*(x2-1)*(x4-1);

res = term1 + term2 + term3 + term4 + term5 + term6;

end