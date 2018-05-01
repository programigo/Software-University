function calculateSpiceAmount(input) {
    let startYield = Number(input);
    let totalDays = 0;
    let totalSpiceAmount = 0;

    while (startYield >= 100) {
        totalSpiceAmount += startYield;

        if (totalSpiceAmount > 26) {
            totalSpiceAmount -= 26;
            startYield -= 10;
            totalDays++;
        }
    }

    if (totalSpiceAmount > 26) {
        totalSpiceAmount -= 26;
    }

    console.log(totalDays);
    console.log(totalSpiceAmount);
}

calculateSpiceAmount(['200']);