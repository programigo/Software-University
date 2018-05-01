function countWords(input) {
    let allWords = input[0].split(/\W+/).filter(w => w != '');

    let wordsInfo ={};

    for (let i = 0; i < allWords.length; i++) {
        if (wordsInfo.hasOwnProperty(allWords[i])) {
            wordsInfo[allWords[i]] += 1;
        } else {
            wordsInfo[allWords[i]] = 1;
        }
    }

    console.log(JSON.stringify(wordsInfo));
}

countWords(['Far too slow, you\'re far too slow.']);