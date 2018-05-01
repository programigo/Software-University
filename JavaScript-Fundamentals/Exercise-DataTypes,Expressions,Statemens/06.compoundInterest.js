function totalAccumulatedValue(input) {
    let sum = input[0];
    let interestRate = input[1] / 100;
    let frequency = 12 / input[2];
    let years = input[3];

    let power = frequency * years;

    let F = sum * Math.pow((1 + (interestRate / frequency)), power);

    console.log(Math.round(F * 100) / 100);
}

totalAccumulatedValue([1500, 4.3, 3, 6]);