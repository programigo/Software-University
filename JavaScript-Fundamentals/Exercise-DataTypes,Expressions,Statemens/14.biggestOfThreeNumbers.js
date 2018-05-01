function biggestNumber(numbers) {
    let firstNumber = numbers[0];
    let secondNumber = numbers[1];
    let thirdNumber = numbers[2];

    let firstNumberIsBiggest = firstNumber > secondNumber && firstNumber > thirdNumber;
    let secondNumberIsBiggest = secondNumber > firstNumber && secondNumber > thirdNumber;

    if (firstNumberIsBiggest){
        return firstNumber;
    }else if (secondNumberIsBiggest){
        return secondNumber;
    }else {
        return thirdNumber;
    }
}