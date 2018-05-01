function numberOfOccurences(sentence, word) {
    let regex = '\\b' + `${word}` + '\\b';
    let pattern = new RegExp(regex, 'gi');
    let counter = 0;
    let match = pattern.exec(sentence);

    while (match) {
        counter++;
        match = pattern.exec(sentence);
    }

    console.log(counter);
}

numberOfOccurences('The waterfall was so high, that the child couldn’t see its peak.', 'the');