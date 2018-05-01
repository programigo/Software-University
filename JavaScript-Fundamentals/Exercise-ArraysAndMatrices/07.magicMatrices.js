function isMagicMatrix(matrix) {
    let currentRowSum = 0;
    let currentColSum = 0;
    let isMagic = true;

    for (let mainRow = 0; mainRow < matrix.length; mainRow++) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (col < matrix.length) {
                    currentRowSum += matrix[mainRow][col];
                }

                currentColSum += matrix[col][row];
            }

            if (currentRowSum !== currentColSum) {
                isMagic = false;
                break;
            }

            currentRowSum = 0;
            currentColSum = 0;
        }
    }

    console.log(isMagic);
}

isMagicMatrix([[4, 5, 6],
    [6, 5, 4],
);