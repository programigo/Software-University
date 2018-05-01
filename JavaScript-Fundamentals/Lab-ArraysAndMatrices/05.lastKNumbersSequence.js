function printSequence(n, k) {
    let sequence = [1];

    for (let i = 1; i < n; i++) {
        sequence[i] = sequence.slice(Math.max(0, sequence.length - k), i + k).reduce((a, b) => {return a + b}, 0);
    }

    console.log(sequence);
}

printSequence(8, 2);