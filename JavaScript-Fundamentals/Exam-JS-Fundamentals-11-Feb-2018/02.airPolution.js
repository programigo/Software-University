function checkForPollution(matrix, forces) {
    let mapOfSofia = [];

    for (var row = 0; row < matrix.length; row++) {
        mapOfSofia[row] = matrix[row].split(' ').map(num => Number(num));
    }

    for (let force of forces) {
        let commandArgs = force.split(/\s+/);
        let command = commandArgs[0];
        let value = Number(commandArgs[1]);

        if (command === 'breeze') {

            for (let col = 0; col < mapOfSofia.length; col++) {
                if (mapOfSofia[value][col] < 0) {
                    mapOfSofia[value][col] = 0;
                }
                mapOfSofia[value][col] -= 15;
            }

        } else if (command === 'gale') {

            for (let row = 0; row < mapOfSofia.length; row++) {
                if (mapOfSofia[row][value] < 0) {
                    mapOfSofia[row][value] = 0;
                }
                mapOfSofia[row][value] -= 20;
            }

        } else if (command === 'smog') {
            for (let row = 0; row < mapOfSofia.length; row++) {
                for (let col = 0; col < mapOfSofia.length; col++) {
                    if (mapOfSofia[row][col] < 0) {
                        mapOfSofia[row][col] = 0;
                    }
                    mapOfSofia[row][col] += value;
                }
            }
        }
    }

    let result = [];

    for (let row = 0; row < mapOfSofia.length; row++) {
        for (let col = 0; col < mapOfSofia.length; col++) {
            if (mapOfSofia[row][col] >= 50){
                result.push(`[${row}-${col}]`);
            }
        }
    }

    if (result.length === 0) {
        console.log(`No polluted areas`);
    } else {
        console.log(`Polluted areas: ${result.join(', ')}`);
    }
}

checkForPollution(["5 7 72 14 4",
    "41 35 37 27 33",
    "23 16 27 42 12",
    "2 20 28 39 14",
    "16 34 31 10 24"
], 
    ["breeze 1", "gale 2", "smog 25"])