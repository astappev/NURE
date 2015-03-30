var n = 1; // Номер в журнале
var m = 1; // Номер группы
var nk = 3; // количество каналов

var lambda = (15*m)/(n*nk);
var v = 3*((m+n))/(n*nk);
var ro = lambda/v;

console.log('Количество каналов: ' + nk);
console.log('Интенсивность поступления требований: ' + lambda + '; Интенсивность обслуживания: ' + v);

var Pk = [];
for(var k = 0; k <= 50; ++k) {
    if(k === 0) {
        var sum = 0;
        for(var i = 0; i <= nk; ++i) {
            sum += Math.pow(ro, i)/factorial(i);   
        }
        Pk[k] = 1/(Math.pow(ro, nk + 1)/(factorial(nk)*(nk-ro)) + sum);
    } else if(k <= nk) {
        Pk[k] = Math.pow(ro, k)/factorial(k) * Pk[0];
    } else {
        Pk[k] = Math.pow(ro, k)/(Math.pow(nk, k - nk)*factorial(nk)) * Pk[0];
    }
}



for(var i = 0; i<Pk.length; ++i) {
    console.log(Pk[i].toFixed(8));
}
var Poch = (Math.pow(ro, nk+1)*Pk[0])/(factorial(nk)*(nk-ro));
console.log("Вероятность очереди: " + Poch);
var Pzan = (Math.pow(ro, nk)*Pk[0])/(factorial(nk-1)*(nk-ro));
console.log("Вероятность занятости всех узлов: " + Pzan);

console.log("Среднее количество требований в системе: " + Mtreb(Pk, nk, ro));
console.log("Средняя длина очереди: " + Moch(Pk, nk, ro));
console.log("Среднее количество свободных узлов: " + (nk-ro));
console.log("Среднее количество занятых узлов: " + ro);
console.log("Среднее время ожидания: " + Toz(Pk, nk, ro, v));
console.log("Общее время перебивания требований в очереди за единицу времени: " + Tzoch(Pk, nk, ro, v));
console.log("Среднее время перебивания требований в системе: " + (Toz(Pk, nk, ro, v)+1/v));
console.log("Общее время, которое все требования проводят в системе за единицу времени: " + (Tzoch(Pk, nk, ro, v)+ro));

function factorial(n) {
    return n ? n*factorial(n-1) : 1;
}

function Mtreb(Pk, nk, ro) {
    var sum = 0;
    for(var i = 0; i < nk; ++i) {
        sum += Math.pow(ro, i)/factorial(i);  
    }
    return Pk[0]*(ro*sum+((Math.pow(ro, nk + 1)*(nk+1-ro))/(factorial(nk-1)*Math.pow(nk-ro, 2))));
}

function Moch(Pk, nk, ro) {
    return (Math.pow(ro, nk + 1)*Pk[0])/(factorial(nk-1)*Math.pow(nk-ro, 2));
}
function Toz(Pk, nk, ro, v) {
    return (Math.pow(ro, nk)*Pk[0])/(v*factorial(nk-1)*Math.pow(nk-ro, 2));
}
function Tzoch(Pk, nk, ro, v) {
    return (Math.pow(ro, nk + 1)*Pk[0])/(factorial(nk-1)*Math.pow(nk-ro, 2));
}