function sortArray(array) {
    array.sort((a, b) => {return a.toLowerCase().localeCompare(b.toLowerCase())})
        .sort((a, b) => {return a.length-b.length});


    console.log(array.join('\n'));
}

sortArray(['test', 'Deny', 'omen', 'Default']);