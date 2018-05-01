function parseData(input) {
    let pattern = /^([A-Z][A-Za-z]*)\s+-\s+([1-9][0-9]*)\s+-\s+([a-zA-Z0-9 -]+)$/g;
    let match;

    for (let employeeInfo of input) {
        while (match = pattern.exec(employeeInfo)) {
            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}

parseData(['Isacc - 1000 - CEO',
'Ivan - 500 - Employee',
'Peter - 500 - Employee']);