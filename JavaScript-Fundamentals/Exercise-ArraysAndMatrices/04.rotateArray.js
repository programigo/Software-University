function rotate(array) {
    let numberOfRotations = Number(array.pop());

    for (let i = 0; i < numberOfRotations % array.length; i++) {
        let currentElement = array.pop();
        array.unshift(currentElement);
    }

    console.log(array.join(' '));
}

rotate(['Banana', 'Orange', 'Coconut', 'Apple', 15000865]);