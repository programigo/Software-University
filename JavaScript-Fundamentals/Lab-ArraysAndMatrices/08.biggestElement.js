function findBggest(matrix) {
    let min = Number.NEGATIVE_INFINITY;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
           if (matrix[row][col] > min) {
               min = matrix[row][col];
           }
        }
    }

    console.log(min);
}