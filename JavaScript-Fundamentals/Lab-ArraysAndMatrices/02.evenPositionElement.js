function evenPositions(arr) {
    let result =[];
    for (var currentPos = 0; currentPos < arr.length; currentPos++) {
        if (currentPos % 2 === 0) {
            result.push(arr[currentPos]);
        }
    }

    return result.join(' ');
}

console.log(evenPositions(['20', '30', '40']));