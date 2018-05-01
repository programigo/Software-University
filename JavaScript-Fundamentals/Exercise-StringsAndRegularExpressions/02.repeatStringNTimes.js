function repeatStr(string, times) {
    let result = '';

    for (let i = 0; i < times; i++) {
        result += string;
    }

    console.log(result);
}

repeatStr('magic is real', 3);