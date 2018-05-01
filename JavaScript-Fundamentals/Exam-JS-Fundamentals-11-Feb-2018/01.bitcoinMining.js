function calculateAmount(input) {
    let numbers = input.map(el => Number(el));
    let totalMoney = 0;
    let boughtBitcoins = 0;
    let firstDayBoughtCoin;

    for (let i = 0; i < numbers.length; i++) {
        let currentDay = i + 1;
        let currentAmountOfGold;

        if (currentDay % 3 === 0) {
            currentAmountOfGold = numbers[i] * 0.70;
        } else {
            currentAmountOfGold = numbers[i];
        }

        totalMoney += currentAmountOfGold * 67.51;

        if (totalMoney >= 11949.16) {
            while (true) {
                if (totalMoney < 11949.16) {
                    break;
                }

                totalMoney -= 11949.16;
                boughtBitcoins++;

                if (boughtBitcoins === 1) {
                    firstDayBoughtCoin = currentDay;
                }
            }
        }
    }

    console.log(`Bought bitcoins: ${boughtBitcoins}`);
    if (boughtBitcoins >= 1) {
        console.log(`Day of the first purchased bitcoin: ${firstDayBoughtCoin}`)
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`)
}

calculateAmount(['50', '100']);