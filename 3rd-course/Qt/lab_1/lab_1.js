var n = 1; // Номер в журнале
var m = 1; // Номер группы
var t1 = n+1, t2 = n+5;

var lambda = (10*m)/n;

simulationFlow(lambda, t1, t2);

function simulationFlow(lambda, t1, t2) {
    function getRandomArbitary(min, max) {
      return parseFloat((Math.random() * (max - min) + min).toFixed(4));
    }
    
    console.log('------------------------------------------------------|');
    console.log('Begin with lambda = ', lambda);
    var z = [];
    var size = 2*lambda*(t2-t1);
    for(var i = 0; i < size; ++i) {
        z[i] = getRandomArbitary(0, 1);
    }
    console.log('Mass r (random numbers):', z.length, z);

    var len = z.length;
    for(var i = 0; i < len; ++i) {
        z[i] = (-1/lambda)*Math.log(z[i]);
    }
    console.log('Mass Z:', z.length, z);

    var tk = [];
    var len = z.length;
    for(var i = 0; i < len; ++i) {

        var lenS = i + 1, sum = 0;
        for(var s = 0; s < lenS; ++s)
        sum += z[s]

        tk[i] = t1 + sum;

        if(tk[i] > t2) {
            tk.splice(i);
            break;
        }
    }
    console.info('Mass t:', tk.length, tk);

    var len = 25;
    var tao_original = (t2-t1)/len, tao_mas = [], current_tao = t1;

    for(var i = 0; i < len; ++i) {
        var sum = 0, len_tk = tk.length;
        for(var k = 0; k < len_tk; ++k)
            if(tk[k] > current_tao && tk[k] < (current_tao + tao_original)) sum++;
        tao_mas[i] = sum;
        current_tao += tao_original;
    }
    console.info('Mass tao:', tao_mas.length, tao_mas);

    var count_tao = [];
    for(var i = 0; i < len; ++i) {
        if(!count_tao[tao_mas[i]]) count_tao[tao_mas[i]] = 1;
        else count_tao[tao_mas[i]]++;
    }

    console.log('Kol-vo trebovaniy v intervale: kov-vo intervalov');
    var sum = 0, Nk = 0;
    for(tao in count_tao) {
        sum +=tao*count_tao[tao];
        Nk += count_tao[tao];
        console.log(tao, count_tao[tao]);
    }

    console.log('sum = ', sum, ', tao = ', tao_original);
    var a = (1/Nk)*sum, lambda_m = a/tao_original;
    console.log('Nk = ', Nk, ', a = ', a, ', lambda (model) = ', lambda_m);
    
    var t = t2-t1;
    
    /* П. 3.7 */
    outputProbability(t, lambda);
    outputProbability(t, lambda_m);
}

function outputProbability(t, lambda) {
    function factorial(n) {
        return n ? n*factorial(n-1) : 1;
    }
    function P(k, t, lambda) {
        return (Math.pow((lambda/t), k)/factorial(k))*Math.exp(-lambda*t);
    }
    function F(t, lambda) {
        return 1-Math.exp(-lambda*t);
    }
    
    console.log('***************************************');
    console.log('For lambda = ', lambda);
    console.log('P(0, t): ', P(0, t, lambda));
    console.log('P(1, t): ', P(1, t, lambda));
    console.log('P(4, t): ', P(4, t, lambda));
    console.log('P(>=5, t): ', 1-(P(0, t, lambda)+P(1, t, lambda)+P(2, t, lambda)+P(3, t, lambda)+P(4, t, lambda)));
    console.log('P(<3, t): ', P(0, t, lambda)+P(1, t, lambda)+P(2, t, lambda));
    console.log('P(<=7, t): ', P(0, t, lambda)+P(1, t, lambda)+P(2, t, lambda)+P(3, t, lambda)+P(4, t, lambda)+P(5, t, lambda)+P(6, t, lambda)+P(7, t, lambda));
    console.log('F(0.5)-F(0.1): ', F(0.5, lambda)-F(0.1, lambda));
}