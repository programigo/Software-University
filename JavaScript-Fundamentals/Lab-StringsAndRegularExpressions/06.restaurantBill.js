function printTotalBill(arr) {
    let pattern = /([A-Za-z]+\s*[A-Za-z]*),\s*([0-9]+\.*[0-9]*)/g;
    let products =[];
    let totalBill = 0;
    let match = pattern.exec(arr);

    while (match != null) {
        products.push(match[1]);
        totalBill += Number(match[2]);

        match = pattern.exec(arr);
    }

    console.log(`You purchased ${products.join(', ')} for a total sum of ${totalBill}`);
}

printTotalBill(['Cola', '1.35', 'Pancakes', '2.88']);