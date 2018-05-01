function printOdds(number) {
    for (let currentNumber = 1; currentNumber <= number; currentNumber++) {
        if (currentNumber % 2 === 1){
            console.log(currentNumber);
        }
    }
}

printOdds(5);