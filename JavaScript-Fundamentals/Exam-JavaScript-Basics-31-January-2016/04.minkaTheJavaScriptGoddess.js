function getTasks(input) {
    let json = {};

    for (let row of input) {
        let arguments = row.split(/\s*&\s*/);
        let name = arguments[0];
        let type = arguments[1];
        let taskNumber = Number(arguments[2]);
        let score = Number(arguments[3]);
        let linesOfCode = Number(arguments[4]);

        if (!json.hasOwnProperty(`Task ${taskNumber}`)) {
            json[`Task ${taskNumber}`] = {};
        }

        if (!json[`Task ${taskNumber}`].hasOwnProperty('tasks')) {
            json[`Task ${taskNumber}`]['tasks'] = [];
        }

        if (!json[`Task ${taskNumber}`].hasOwnProperty('average')) {
            json[`Task ${taskNumber}`]['average'] = [];
        }

        if (!json[`Task ${taskNumber}`].hasOwnProperty('lines')) {
            json[`Task ${taskNumber}`]['lines'] = [];
        }

        json[`Task ${taskNumber}`]['tasks'].push({name: `${name}`, type: `${type}`});

        json[`Task ${taskNumber}`]['average'].push(score);

        json[`Task ${taskNumber}`]['lines'].push(linesOfCode);
    }

    for (let task of Object.keys(json)) {
        let currentTaskAverageLength = json[task]['average'].length;
        let sum = json[task]['average'].reduce((a, b) => a + b);
        json[task]['average'] = sum / currentTaskAverageLength;
        json[task]['lines'] = json[task]['lines'].reduce((a, b) => a + b);

    }

    let sortedJsonTasks = Object.keys(json).sort(function (a, b) {
        let firstAverage = json[a]['average'];
        let secondAverage = json[b]['average'];

        let result = secondAverage - firstAverage;

        if (result === 0) {
            let firstNumberOfLines = json[a]['lines'];
            let secondNumberOfLines = json[b]['lines'];

            result = firstNumberOfLines - secondNumberOfLines;
        }

        return result;
    });

    for (let currentTask of sortedJsonTasks) {
        json[currentTask]['tasks'] = json[currentTask]['tasks'].sort(function (firstObj, secondObj) {
            let firstName = firstObj['name'];
            let secondName = secondObj['name'];

            if (firstName < secondName) {
                return -1;
            }

            if (firstName > secondName) {
                return 1;
            }

            return 0;
        });


        let b = 6;
    }

    console.log(1);

}

getTasks(['Array Matcher & strings & 4 & 100 & 38',
'Magic Wand & draw & 3 & 100 & 15',
'Dream Item & loops & 2 & 88 & 80',
'Knight Path & bits & 5 & 100 & 65',
'Basket Battle & conditionals & 2 & 100 & 120',
'Torrent Pirate & calculations & 1 & 100 & 20',
'Encrypted Matrix & nested loops & 4 & 90 & 52',
'Game of bits & bits & 5 &  100 & 18',
'Fit box in box & conditionals & 1 & 100 & 95',
'Disk & draw & 3 & 90 & 15',
'Poker Straight & nested loops & 4 & 40 & 57',
'Friend Bits & bits & 5 & 100 & 81']);