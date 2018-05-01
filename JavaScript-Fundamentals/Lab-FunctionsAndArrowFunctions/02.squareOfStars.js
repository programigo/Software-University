function printSquare(n) {
    for (let i = 1; i <= n; i++) {
        printStars(n);
    }

    function printStars(count) {
        console.log("* ".repeat(count));
    }
}

printSquare(4);