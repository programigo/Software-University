function modifyNumber(elements) {
    let number = Number(elements[0]);
    let chop = (num) => num / 2;
    let dice = (num) => Math.sqrt(num);
    let spice = (num) => num + 1;
    let bake  = (num) => num * 3;
    let fillet = (num) => num - (num * 0.20);

    let output = '';

    for (let i = 1; i < elements.length; i++) {
        let command = elements[i];

        switch (command){
            case 'chop': number = chop(number); break;
            case 'dice': number =  dice(number) ; break;
            case 'spice': number = spice(number); break;
            case 'bake': number = bake(number); break;
            case 'fillet': number = fillet(number); break;
        }

        output += number;
        output += '\n';
    }

    return output;
}

console.log(modifyNumber([9, 'dice', 'spice', 'chop', 'bake', 'fillet']));