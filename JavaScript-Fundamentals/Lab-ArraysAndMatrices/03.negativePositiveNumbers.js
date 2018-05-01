function processElements(arr) {
    let result = [];

    for (let index = 0; index < arr.length; index++) {
        let currentNumber = arr[index];
        if (currentNumber >= 0) {
            result.push(currentNumber);
        } else {
            result.unshift(currentNumber);
        }
    }

    return result.join('\n');
}

console.log(processElements([3, -2, -0, -1]));;