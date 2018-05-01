function getPopulations(input) {
    let townsInfo = {};

    for (var i = 0; i < input.length; i++) {
        let pair = input[i].split(/\s<->\s/);
        if (!townsInfo.hasOwnProperty(pair[0])) {
            townsInfo[pair[0]] = Number(pair[1]);
        } else {
            townsInfo[pair[0]] += Number(pair[1]);
        }
    }

    for (let key in townsInfo) {
        if (townsInfo.hasOwnProperty(key)){
            console.log(`${key} : ${townsInfo[key]}`);
        }
    }
}

getPopulations(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);