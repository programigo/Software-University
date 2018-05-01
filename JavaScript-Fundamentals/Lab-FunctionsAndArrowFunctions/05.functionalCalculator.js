function calculate(a, b, operator) {
    let add = function (c, d) {return c + d};
    let subtract = function (c, d) {return c - d};
    let multiply = function (c, d) {return c * d};
    let divide = function (c, d) {return c / d};

    switch (operator){
        case '+': return add(a, b);
        case '-': return subtract(a, b);
        case '*': return multiply(a, b);
        case '/': return divide(a, b);
    }
}