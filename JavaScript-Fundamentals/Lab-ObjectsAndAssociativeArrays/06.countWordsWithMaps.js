function countWords(input) {
    let allWords = input[0].split(/\W+/).filter(w => w != '').map(w => w.toLowerCase());

    let myMap = new Map();

    for (let i = 0; i < allWords.length; i++) {
        let currentWord = allWords[i];
        if (!myMap.has(currentWord)) {
            myMap.set(currentWord, 1);
        } else {
            myMap.set(currentWord, myMap.get(currentWord) + 1);
        }
    }

    let sortedWords = Array.from(myMap.keys()).sort();

    for (let key of sortedWords) {
        console.log(`'${key}' -> ${myMap.get(key)} times`);
    }
}

countWords(['Far too slow, you\'re far too slow.']);