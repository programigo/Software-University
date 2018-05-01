function printNumbers(number) {
    let concatenatedValues = '';

    for (let i = 1; i <= number; i++) {
       concatenatedValues += i;
    }

    console.log(concatenatedValues);
}

printNumbers(11);