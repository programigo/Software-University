function calcDivisor(a, b) {

    function gcd(a, b) {
        if (b === 0){
            return a;
        } else{
            return gcd(b, a % b);
        }
    }

    return gcd(a, b);
}

calcDivisor(252, 105);