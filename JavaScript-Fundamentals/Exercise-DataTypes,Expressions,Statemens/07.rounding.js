function roundNumber(input) {
    let number = input[0];
    let precision = input[1];
    let factor = Math.pow(10, precision);

    return Math.round(number * factor) / factor;
}

console.log(roundNumber([3.1415926535897932384626433832795, 2]));