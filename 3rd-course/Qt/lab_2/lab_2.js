var n = 1; // Номер в журнале
var m = 1; // Номер группы
var interval = 25;
var t1 = n+1, t2 = n+5;
var t = t2-t1; 
var tao_interval = (t2-t1)/interval;

var lambda = (10*m)/n;
var lambda_2_1 = (9*m)/n;
var lambda_2_2 = (13*m)/n;

var x1 = getXtao(lambda_2_1, t1, t2);
var x2 = getXtao(lambda_2_2, t1, t2);
var x = [];
for(var i = 0; i < interval; ++i) {
   x[i] = x1[i] + x2[i];
}

console.log('Потоки x1, x2 + суммарный');
console.log('x1(tao): ', x1);
console.log('x2(tao): ', x2);
console.log('x1 + x2: ', x);

var count_tao = [];
for(var i = 0; i < interval; ++i) {
    if(!count_tao[x[i]]) count_tao[x[i]] = 1;
    else count_tao[x[i]]++;
}

console.log('Количество требований в интервале: количество интервалов');
var sum = 0, Nk = 0;
for(tao in count_tao) {
    sum +=tao*count_tao[tao];
    Nk += count_tao[tao];
    console.log(tao, count_tao[tao]);
}

var a = (1/Nk)*sum, lambda_m = a/tao_interval;
console.log('Лямбда (1) = ', lambda_2_1);
console.log('Лямбда (2) = ', lambda_2_2);
console.log('Лямбда (сум) = ', lambda_m);

var mat_o = 0;
for(var i = 0; i < interval; ++i) {
    mat_o += x[i];
}
mat_o /= interval;
console.log('Математическое ожидание = ', mat_o);

var mat_d = 0;
for(var i = 0; i < interval; ++i) {
    mat_d += Math.pow(x[i] - mat_o, 2);
}
mat_d /= interval - 1;
console.log('Дисперсия = ', mat_d);
//outputProbability(t, lambda);

function getXtao(lambda, t1, t2) {
    function getRandomArbitary(min, max) {
      return parseFloat((Math.random() * (max - min) + min).toFixed(4));
    }
    
    var z = [];
    var size = 2*lambda*(t2-t1);
    for(var i = 0; i < size; ++i) {
        z[i] = getRandomArbitary(0, 1);
    }
    //console.log('Mass r (random numbers):', z.length, z);

    var len = z.length;
    for(var i = 0; i < len; ++i) {
        z[i] = (-1/lambda)*Math.log(z[i]);
    }
    //console.log('Mass Z:', z.length, z);

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
    //console.info('Mass t:', tk.length, tk);

    var tao_mas = [], current_tao = t1;

    for(var i = 0; i < interval; ++i) {
        var sum = 0, len_tk = tk.length;
        for(var k = 0; k < len_tk; ++k)
            if(tk[k] > current_tao && tk[k] < (current_tao + tao_interval)) sum++;
        tao_mas[i] = sum;
        current_tao += tao_interval;
    }
    return tao_mas;
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