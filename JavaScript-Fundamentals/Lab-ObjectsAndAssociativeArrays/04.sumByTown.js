function sumTownsIncome(input) {
    let townsInfo = {};

    for (let i = 0; i < input.length; i += 2) {
       if (townsInfo.hasOwnProperty(input[i])) {
           townsInfo[input[i]] += Number(input[i + 1]);
       } else {
           townsInfo[input[i]] = Number(input[i + 1]);
       }
    }

    console.log(JSON.stringify(townsInfo));
}

sumTownsIncome(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);