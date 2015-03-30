var n = 1; // Номер в журнале
var m = 1; // Номер группы
var nk = 5;//4; // количество каналов

//var lambda = (10*m)/(n*nk);
//var v = (3*(m+n))/(n*nk);
var lambda = 0.1;
var v = 1;
var ro = lambda/v;

console.log('Количество каналов = ', nk);
console.log('Лямбда = ', lambda, '; v = ', v, '; ро = ', ro);

var pn = Potk(ro, nk);
console.log('Вероятность отказа = ', pn);
var mz = Mzan(ro, pn);
console.log('Среднее число занятых узлов = ', mz);
var ms = nk - mz;
console.log('Среднее число свободных узлов = ', ms);
var q = 1 - pn;
console.log('Относительная пропускная способность = ', q);
var a = q*lambda;
console.log('Абсолютная пропускная способность = ', a);
var k = mz/nk;
console.log('Коэффициент занятости = ', k);

var mas = [];
for(var k = 0; k < nk + 1; ++k) {
    var chisl = (Math.pow(ro, k)/factorial(k));
    var znam = 0;
    for(var i = 0; i < nk; ++i) {
        znam += Math.pow(ro, i)/factorial(i);   
    }
    mas[k] = chisl/znam;
}
console.log('График: ', mas);

function Mzan(ro, pn) {
    return ro*(1-pn);   
}
function Potk (ro, nk) {
    var chisl = Math.pow(ro, nk)/factorial(nk);
    var znam = 0;
    for(var i = 0; i < nk; ++i) {
        znam += Math.pow(ro, i)/factorial(i);   
    }
    return chisl/znam;
}

function factorial(n) {
    return n ? n*factorial(n-1) : 1;
}