function isPrime(number){
    let prime = true;

    for (let i = 2; i <= Math.sqrt(number); i++) {
        if (number % i === 0){
            prime = false;
            break;
        }
    }

    return prime && (number > 1);
}

binaryLogarithm(1024, 1048576, 256, 1, 2);