function extractText(text) {
    let pattern = /\((.*?)\)/g;
    let result = [];
    let match = pattern.exec(text);

        while (match != null) {
            result.push(match[1]);
            match = pattern.exec(text)
        }

    return result.join(', ');
}
