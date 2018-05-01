function getSubsequence(array) {
    let currentBiggest = array[0];
    for (let i = 1; i < array.length; i++) {
        array.filter(n => n < currentBiggest ? array.pop(): n = currentBiggest);
    }

    console.log(array);
}

getSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]);