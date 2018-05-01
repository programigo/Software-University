function printDna(size) {

    let pattern = 'ATCGTTAGGG';

    for (let i = 0; i < size; i++) {
        for (let j = 0; j < pattern.length * 2; j+=7) {
            let currentPosition = j;
            if (j == 9){
                currentPosition = 0;
            }
            console.log(`**${pattern[currentPosition]}${pattern[currentPosition + 1]}**`);
            console.log(`*${pattern[currentPosition + 2]}--${pattern[currentPosition + 3]}*`);
            console.log(`${pattern[currentPosition + 4]}----${pattern[currentPosition + 5]}`);
            console.log(`*${pattern[currentPosition + 6]}--${pattern[currentPosition + 7]}*`);
        }
    }
}

printDna(10);