function townsAndTotalIncome(arr) {
    let pattern = /\|\s(\w+\s*\w+)\s*\|\s([0-9]+,*\.*[0-9]*)/g;
    let towns =[];
    let incomeSum = 0;
    let match;

    for (let townInfo of arr) {
        while(match = pattern.exec(townInfo)) {
            towns.push(match[1].trim());
            incomeSum += Number(match[2]);
        }
    }

    console.log(towns.join(', '));
    console.log(incomeSum);
}

townsAndTotalIncome(['| Sofia           | 300',
    '| Veliko Tarnovo  | 500',
    '| Yambol          | 275']
);