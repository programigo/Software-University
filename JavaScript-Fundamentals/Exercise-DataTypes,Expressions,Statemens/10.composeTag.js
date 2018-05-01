function compose(input) {
    let fileLocation = input[0];
    let alternateText = input[1];

    return `<img src="${fileLocation}" alt="${alternateText}">`;
}

console.log(compose(['smiley.gif', 'Smiley Face']));