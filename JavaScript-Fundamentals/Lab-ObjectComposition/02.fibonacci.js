function getFibonator() {
    let firstNum = 0;
    let secondNum = 1;
    
   return function fibonator() {
        let temp = firstNum + secondNum;
        firstNum = secondNum;
        secondNum = temp;
        return firstNum;
    }
}

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());