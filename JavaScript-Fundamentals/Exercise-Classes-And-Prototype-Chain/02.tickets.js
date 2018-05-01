function solve(array, sorter) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    
    let resultArray = [];

    for (let description of array) {
        let arguments = description.split('|');
        let ticket = new Ticket(arguments[0], Number(arguments[1]), arguments[2]);
        resultArray.push(ticket);
    }

    resultArray.sort(function (a, b) {
        if (a[sorter] < b[sorter]) return -1;
        if (a[sorter] > b[sorter]) return 1;
        return 0;
    });

    return resultArray;
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
));

