function calcSum(matrix) {
    let mainDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = row; col < matrix.length; col++) {
            mainDiagonalSum += matrix[row][col];
            break;
        }
    }

    let colPosition = matrix.length - 1;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = colPosition; col >= 0; col--) {
            secondaryDiagonalSum += matrix[row][colPosition];
            colPosition--;
            break;
        }

    }

    console.log(mainDiagonalSum + ' ' + secondaryDiagonalSum);
}

calcSum([[20, 40], [10, 60]]);