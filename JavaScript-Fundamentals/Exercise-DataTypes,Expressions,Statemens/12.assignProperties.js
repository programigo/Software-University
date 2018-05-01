function composeObject(input) {
    let firstElementKey = input[0];
    let firstElementValue = input[1];

    let secondElementValue = input[3];

    let thirdElementValue = input[5];

    let result = '{\n';

    let obj = {
        firstElementKey: firstElementValue,
        age: secondElementValue,
        gender: thirdElementValue
    };

    for (let currentElement in obj) {
        result += currentElement + ': ' + obj[currentElement] + '\n';
    }

    result += '}';

    return result;
}

console.log(composeObject(['name', 'Pesho', 'age', '23', 'gender', 'male']));