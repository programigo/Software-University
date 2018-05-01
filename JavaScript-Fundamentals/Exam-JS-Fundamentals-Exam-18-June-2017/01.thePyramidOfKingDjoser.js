function calculateMaterials(size, increment) {
    let totalHeight = Math.ceil(size / 2);
    let[stone, marble, lapis,] = [0, 0, 0];

    for (let i = 1; i < totalHeight; i++) {

        for (let currentRow = 0; currentRow < size; currentRow++) {
            if (currentRow === 0 || currentRow === size - 1) {
                if (i % 5 === 0) {
                    lapis += size * increment;
                } else {
                    marble += size * increment;
                }
            } else {
                stone += (size - 2) * increment;

                if (i % 5 === 0) {
                    lapis += 2 * increment;
                } else {
                    marble += 2 * increment;
                }
            }
        }

        size -= 2;
    }

    let gold = Math.ceil(size * size * increment);
    let finalHeight = Math.floor(totalHeight * increment);

    console.log(`Stone required: ${Math.round(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${gold}`);
    console.log(`Final pyramid height: ${finalHeight}`);
}

calculateMaterials(5000, 1);