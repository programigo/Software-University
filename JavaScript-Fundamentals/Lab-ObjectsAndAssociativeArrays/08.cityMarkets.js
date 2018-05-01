function totalPricesByTowns(input) {
    let townsInfo = {};

    for (let i = 0; i < input.length; i++) {
        let elements = input[i].split(/\s*->\s*/);

        if (!townsInfo.hasOwnProperty(elements[0])) {
            townsInfo[elements[0]] = {};
        }

        let totalSum = elements[2].split(/\s*:\s*/).map(num => Number(num)).reduce((a, b) => a * b);

        if (!townsInfo[elements[0]].hasOwnProperty(elements[1])) {
            townsInfo[elements[0]][elements[1]] = totalSum;
        } else {
            townsInfo[elements[0]][elements[1]] += totalSum;
        }
    }

    for (let town in townsInfo) {
        console.log(`Town - ${town}`)
        for (let product in townsInfo[town]) {
            console.log(`$$$${product} : ${townsInfo[town][product]}`);
        }
    }
}

totalPricesByTowns(['Sofia -> Laptops HP -> 200 : 2000',
'Sofia -> Raspberry -> 200000 : 1500',
'Sofia -> Audi Q7 -> 200 : 100000',
'Montana -> Portokals -> 200000 : 1',
'Montana -> Qgodas -> 20000 : 0.2',
'Montana -> Chereshas -> 1000 : 0.3']);