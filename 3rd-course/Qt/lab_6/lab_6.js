var n = 1; // Номер в журнале
var m = 1; // Номер группы
var nk = 3; // количество каналов
var h = 44/60; // Время обслуживания (среднее)

var lambda = (12*m)/(n*nk);
var t1 = n + 1, t2 = n + 200;
var ro = lambda*h;

console.log('Количество каналов: ' + nk + ", Время обслуживания: " + h + " мин.");
console.log('Интенсивность поступления требований: ' + lambda + '; Ро: ' + ro);

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
var sum_z = 0;
var chas_zv = [];
var chanal_mas = [];
var nakopitel = [];
var size_nakopitel = [];

console.info("R"  + '\t' + "Z" + '\t' + 'T (пост.)' + '\t' + 'Время обсл.' + '\t' + 'T (освоб.)' + '\t' + 'Канал' + '\t' + 'Разм. очереди');
for(var i = 0; i < len; ++i) {
    if(nakopitel.length > 0) {
        nakopitel[nakopitel.length] = e[i];
        var noFree = false;
        var k;
        while(nakopitel.length > 0 && !noFree) {
            for(k = 0; k < nk; ++k) {
                if(chas_zv[k] < t_post[i]) {
                    chas_zv[k] += nakopitel[0];
                    nakopitel.splice(0,1);
                    break;
                } else if((k + 1) === nk) {
                    k_zag++;
                    noFree = true;
                }
            }
        }
        if(nakopitel.length === 0) {
            chas_zv[k] = t_zvil[i];
            chanal_mas[i] = k; 
        }
    } else {
        for(var k = 0; k < nk; ++k) {
            if(chas_zv[k] === undefined || chas_zv[k] < t_post[i]) {
                chas_zv[k] = t_zvil[i];
                chanal_mas[i] = k;
                break;
            } else if((k + 1) === nk) {
                k_zag++;
                nakopitel[nakopitel.length] = e[i];
            }
        }
    }
    size_nakopitel[i] = nakopitel.length;
    
    var str = r[i] + ',' + z[i].toFixed(6) + ',' + t_post[i].toFixed(6) + ',' + e[i].toFixed(6) + ',' + t_zvil[i].toFixed(6) + ',' + (chanal_mas[i] === undefined ? 'очер.' : chanal_mas[i] + 1) + ',' + size_nakopitel[i];
    for(var k = 0; k < nk; ++k) {
        str += ',' + (chas_zv[k] > t_post[i] ? 1 : 0);
    }
    console.info(str);
}

console.info("Всего требований: " + t_post.length);
console.info("В накопителе: " + k_zag);

console.info("Pочереди (мод): " + k_zag/t_post.length);
console.info("Pочереди: " + Potk(ro, nk));

function Potk(ro, nk) {
    var sum = 0;
    for(var k = 0; k <= nk; ++k) {
        sum += Math.pow(ro, k)/factorial(k);   
    }
    var temp = Math.pow(ro, nk + 1)/(factorial(nk)*(nk-ro));
    
    var p0 = 1/(sum + temp);
    return (Math.pow(ro, nk + 1)/(factorial(nk)*(nk-ro)))*p0;
}

function factorial(n) {
    return n ? n*factorial(n-1) : 1;
}
function getRandomArbitary(min, max) {
    return parseFloat((Math.random() * (max - min) + min).toFixed(4));
}