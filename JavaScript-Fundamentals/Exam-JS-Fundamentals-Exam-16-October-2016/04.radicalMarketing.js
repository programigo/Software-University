function getMostImportantPerson(arr) {
    let database = {};

    for (let command of arr) {
        if (command.length === 1) {
            if (!database.hasOwnProperty(command)) {
                database[command] = [];
            }
        } else if (command.length >= 2) {
            let commandArgs = command.split('-');
            let firstPerson = commandArgs[0];
            let secondPerson = commandArgs[1];

            if (database.hasOwnProperty(firstPerson) || database.hasOwnProperty(secondPerson)) {
                if (database.hasOwnProperty(secondPerson)) {
                    if (secondPerson != firstPerson) {
                        if (database[secondPerson].indexOf(firstPerson) == -1) {
                            database[secondPerson].push(firstPerson);
                        }
                    }
                }
            }
        }
    }

    let result = Object.keys(database).sort((a, b) => database[b].length - database[a].length)[0];

    let winner = database[result];

    console.log(result);

    for (let i = 0; i < winner.length; i++) {
        console.log(`${i + 1}. ${winner[i]}`);
    }

}

getMostImportantPerson(['Z',
'O',
'R',
'D',
'Z-O',
'R-O',
'D-O',
'P',
'O-P',
'O-Z',
'R-Z',
'D-Z'
]);