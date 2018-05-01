function isPalindome(input) {
    let reversedWord = input.split("").reverse().join("");

    return input === reversedWord;
}