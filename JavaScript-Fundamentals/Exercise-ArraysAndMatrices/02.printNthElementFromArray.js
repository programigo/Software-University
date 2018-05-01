function printelement(array) {
    let step = Number(array.pop());

    for (let i = 0; i < array.length; i += step) {
        console.log(array[i]);
    }
}

printelement([1, 2, 3, 4, 5, 6]);