function manipulateArray(input) {
    let array = [];

    let initialNumber = 1;

    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'add') {
            array.push(initialNumber);
            initialNumber++;
        } else if (input[i] === 'remove') {
            array.pop();
            initialNumber++;
        }
    }

    if (array.length > 0) {
        console.log(array.join('\n'));
    } else {
        console.log('Empty');
    }
}

manipulateArray(['remove', 'remove', 'remove']);