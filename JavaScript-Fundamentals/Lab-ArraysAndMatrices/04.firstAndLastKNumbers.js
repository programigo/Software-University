function printNumbers(arr) {
    let k = arr.shift();

    let firstKElemens = arr.slice(0, k);
    let lastKElements = arr.slice(arr.length - k, arr.length);

    console.log(firstKElemens.join(' '));
    console.log(lastKElements.join(' '));
}

printNumbers([3, 6, 7, 8, 9]);