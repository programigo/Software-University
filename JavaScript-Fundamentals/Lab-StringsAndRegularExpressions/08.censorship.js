function censorText(text, censoredWords) {
    let pattern;

    for (let word of censoredWords) {
        pattern = new RegExp(word, 'g');
        text = text.replace(pattern, '-'.repeat(word.length));
    }

    console.log(text);
}

censorText('roses are red, violets are blue', [', violets are', 'red']);