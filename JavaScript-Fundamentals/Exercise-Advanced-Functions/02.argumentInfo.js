function getParamsInfo() {
    let summary = {};
    let sortedTypes = [];

    for (let i = 0; i < arguments.length; i++) {
        let currentObj = arguments[i];
        let type = typeof currentObj;
        console.log(`${type}: ${currentObj}`);

        if (!summary[type]) {
            summary[type] = 1;
        } else {
            summary[type]++;
        }
    }

    for (let currentType in summary) {
        sortedTypes.push([currentType, summary[currentType]]);
    }

    function orderTypes(a, b) {
        if (a[1] < b[1]) return 1;
        if (a[1] > b[1]) return -1;
    }

    sortedTypes = sortedTypes.sort(orderTypes);

    for (let pair of sortedTypes) {
        console.log(`${pair[0]} = ${pair[1]}`)
    }
}

getParamsInfo('cat', 'dog', 'three', 34, 42, function () { console.log('Hello world!'); });