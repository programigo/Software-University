function splitString(string, delimiter) {
    string = string.split(delimiter);

    console.log(string.join('\n'));
}

splitString('One-Two-Three-Four-Five', '-');