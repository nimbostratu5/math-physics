function Xs = BisectionRoot(Fun,a,b,TolMax)
% BisectionRoot finds the root of Fun = 0.

Fa=feval(Fun,a);
Fb=feval(Fun,b);

if Fa*Fb >0
    Xs = ('Error: The function has the same sign at points a and b.');
else
    n = ceil((log10(b-a)-log10(TolMax))/log10(2));
    for i=1:n
    Xs=(a+b)/2;
    FXs=feval(Fun,Xs);
    if FXs ==0
        break
    end
    if Fa*FXs <0
        b=Xs;
    else
        a=Xs;
        Fa=FXs;
    end 
end 
end


%Xs = fzero('Fun',4)
%fplot('Fun',[1,10])