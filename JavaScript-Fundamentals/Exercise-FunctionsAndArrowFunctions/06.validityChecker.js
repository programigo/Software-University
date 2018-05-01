function checkDistances(input) {
    let x1 = input[0];
    let y1 = input[1];
    let x2 = input[2];
    let y2 = input[3];

    let firstPointToStart = (xOne, yOne) => Math.sqrt(Math.pow((xOne - 0), 2) + Math.pow((yOne - 0), 2));
    let secondPointToStart = (xTwo, yTwo) => Math.sqrt(Math.pow((xTwo - 0), 2) + Math.pow((yTwo - 0), 2));
    let firstPointToSecondPoint = (xOne, yOne, xTwo, yTwo) => Math.sqrt(Math.pow((xOne - xTwo), 2) + Math.pow((yOne - yTwo), 2));

    Number.isInteger(firstPointToStart(x1, y1)) ? console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
                                                : console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);


    Number.isInteger(secondPointToStart(x2, y2)) ? console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
        : console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);

    Number.isInteger(firstPointToSecondPoint(x1, y1, x2, y2)) ? console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        : console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}

checkDistances([3, 0, 0, 4]);