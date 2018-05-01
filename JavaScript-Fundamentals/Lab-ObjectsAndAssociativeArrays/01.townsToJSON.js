function toJson(input) {

    let result = [];

    input.shift();

    for (let i = 0; i < input.length; i++) {
        let arguments = input[i].split(/\|\s*/).filter(e => e != '');
        for (let j = 0; j < arguments.length; j+=3) {
            let town = arguments[j];
            let latitude = Number(arguments[j+1]);
            let longitude = Number(arguments[j+2]);
            let currentObject = {Town: town.trim(), Latitude: latitude, Longitude: longitude};

            result.push(currentObject);
        }
    }

    console.log(JSON.stringify(result));
}

toJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);