function calcAggregates(someArr) {
    function reduce(array, func) {
        let result = array[0];
        for (let nextElement of array.slice(1))
            result = func(result, nextElement);
        return result;
    }

    console.log(`Sum = ${reduce(someArr, (a, b) => a + b)}`);
    console.log(`Min = ${reduce(someArr, (a, b) => a < b ? a : b)}`);
    console.log(`Max = ${reduce(someArr, (a, b) => a > b ? a : b)}`);
    console.log(`Product = ${reduce(someArr, (a, b) => a * b)}`);
    console.log(`Join = ${reduce(someArr, (a, b) => a.toString() + b.toString())}`);
}

calcAggregates([2, 3, 10, 5]);




