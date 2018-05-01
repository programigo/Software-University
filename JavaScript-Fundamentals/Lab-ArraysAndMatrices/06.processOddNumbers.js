function getOdds(arr) {
    let result = arr.filter((num, index) => index % 2 != 0).map(n => n * 2).reverse();

    console.log(result.join(' '));
}

getOdds([10, 15, 20, 25]);