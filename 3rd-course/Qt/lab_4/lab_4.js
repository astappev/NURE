var n = 1; // Номер в журнале
var m = 1; // Номер группы
var nk = 5; // количество каналов
var h = 40/60; // Время обслуживания (среднее)

var lambda = (10*m)/(n*nk);
var t1 = n + 1, t2 = n + 200;
var ro = lambda*h;

console.log('Количество каналов: ' + nk + ", Время обслуживания: " + h + " мин.");
console.log('Лямбда: ' + lambda + '; Ро: ' + ro);

var r = [];
var size = 2*lambda*(t2-t1);
for(var i = 0; i < size; ++i) {
    r[i] = getRandomArbitary(0, 1);
}
//console.log('Mass r (random numbers):', r.length, r);

var len = r.length;
var z = [];
for(var i = 0; i < len; ++i) {
    z[i] = (-1/lambda)*Math.log(r[i]);
}
//console.log('Mass Z:', z.length, z);
var t_post = [];
var len = z.length;
for(var i = 0; i < len; ++i) {

    var lenS = i + 1, sum = 0;
    for(var s = 0; s < lenS; ++s)
    sum += z[s]

    t_post[i] = t1 + sum;

    if(t_post[i] > t2) {
        t_post.splice(i);
        break;
    }
}
//console.info('Mass T (пост):', t_post.length, t_post);

len = t_post.length;
var e = [];
for (var i = 0; i < len; ++i) {
    e[i] = (-h * Math.log(r[i]));
}
//console.info('Mass E:', e.length, e);

var t_zvil = [];
for (var k = 0; k < len; ++k) {
    t_zvil[k] = (t_post[k] + e[k]);
}
//console.info('Mass T (освб):', t_zvil.length, t_zvil);

var k_zag = 0;
var flags = [];
var chanal_mas = [];

for (var i = 0; i < len; ++i) {
    for(var k = 0; k < nk; ++k) {
        if(flags[k] === undefined || t_zvil[flags[k]] < t_post[i]) {
            chanal_mas[i] = k;
            flags[k] = i;
            break;
        } else if((k + 1) === nk) {
            k_zag++;
        }
    }
}

console.info("R"  + '\t' + "Z" + '\t' + 'T (поступления)' + '\t' + 'Время обслуживания' + '\t' + 'T (освобождения)' + '\t' + 'Канал');
for (var i = 0; i < len; ++i) {
    console.info(r[i] + '\t' + z[i].toFixed(6) + '\t' + t_post[i].toFixed(6) + '\t' + e[i].toFixed(6) + '\t' + t_zvil[i].toFixed(6) + '\t' + (chanal_mas[i] === undefined ? 'не обслужен' : chanal_mas[i]));
}

console.info("Kвыз: " + t_post.length);
console.info("Kотк: " + k_zag);

console.info("Pотк (мод): " + k_zag/t_post.length);
console.info("Pотк: " + Potk(ro, nk));

function Potk(ro, nk) {
    var chisl = Math.pow(ro, nk)/factorial(nk);
    var znam = 0;
    for(var i = 0; i <= nk; ++i) {
        znam += Math.pow(ro, i)/factorial(i);   
    }
    return chisl/znam;
}
function factorial(n) {
    return n ? n*factorial(n-1) : 1;
}
function getRandomArbitary(min, max) {
    return parseFloat((Math.random() * (max - min) + min).toFixed(6));
}