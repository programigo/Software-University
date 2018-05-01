function capitalize(text) {
    let pattern = /[a-zA-Z?!\.\,_-]+/g;
    let match = pattern.exec(text);
    let result = '';

    while (match != null) {
        result += match[0].charAt(0).toUpperCase() + match[0].slice(1).toLowerCase() + ' ';
        match = pattern.exec(text);
    }

    console.log(result);
}

capitalize('Was that Easy? tRY thIs onE for SiZe!');