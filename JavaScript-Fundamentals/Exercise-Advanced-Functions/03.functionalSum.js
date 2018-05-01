let test = (function () {
    let sum = 0;

    function add(number) {
        sum += number;
        return add
    }
    add.toString = function () {
        return sum;
    };
    return add
}());

console.log(test(1)(6)(-3).toString());