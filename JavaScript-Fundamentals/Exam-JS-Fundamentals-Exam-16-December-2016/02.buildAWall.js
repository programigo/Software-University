function getWallTotalCost(input) {
    let allSections = input.map(el => Number(el));
    let dailyConcrete = [];

    while (allSections.length > 0) {

        allSections = allSections.filter(n => n < 30);
        allSections = allSections.map(n => ++n);

        dailyConcrete.push(allSections.length * 195);
    }

    dailyConcrete.pop();

    let wallFinalCost = dailyConcrete.reduce((a, b) => a + b) * 1900;

    console.log(dailyConcrete.join(', '));
    console.log(`${wallFinalCost} pesos`);
}

getWallTotalCost(['17', '22', '17', '19', '17']);