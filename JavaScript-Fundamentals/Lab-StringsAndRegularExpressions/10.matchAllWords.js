function matchWords(text) {
    let pattern = /\w+/g;
    let match = pattern.exec(text);
    let result = [];

    while (match != null) {
        result.push(match[0]);

        match = pattern.exec(text);
    }

    console.log(result.join('|'));
}

matchWords('_(Underscores) are also word characters');